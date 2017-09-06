using EmitMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Xml.Linq;

namespace CVEVuln.Extensions
{
    public static class MappingExtensions
    {
        public static readonly MappingConfiguration MapConfigDefault = CreateMapConfigDefault();

        public static TTo MapToSingle<TTo>(this object objFrom, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return MapToSingleInternal(objFrom, default(TTo), mappingConfig);
        }

        public static TTo MapToSelfSingle<TTo, TFrom>(this TTo objTo, TFrom objFrom, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return MapToSingleInternal(objFrom, objTo, mappingConfig);
        }

        public static TTo Remap<TTo>(this TTo objTo, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return MapToSingleInternal(objTo, objTo, mappingConfig);
        }

        public static IEnumerable<TTo> MapToMany<TTo>(this IQueryable<object> objFrom, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return objFrom.ToArray().Select(item => item.MapToSingle<TTo>(mappingConfig));
        }

        public static TTo MapFromDatabase<TTo>(this TTo objTo, TimeZoneInfo timeZoneInfo, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return objTo.Remap(config => CreateMapConfigFromDatabase(mappingConfig, timeZoneInfo));
        }

        public static TTo MapToDatabase<TTo>(this TTo objTo, TimeZoneInfo timeZoneInfo, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return objTo.Remap(config => CreateMapConfigToDatabase(mappingConfig, timeZoneInfo));
        }

        public static TTo MapFromWcf<TTo>(this TTo objTo, TimeZoneInfo timeZoneInfo, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            return objTo.Remap(config => CreateMapConfigFromWcf(mappingConfig, timeZoneInfo));
        }

        private static TTo MapToSingleInternal<TTo, TFrom>(TFrom objFrom, TTo objTo, Func<MappingConfiguration, MappingConfiguration> mappingConfig = null)
        {
            if (objFrom == null)
            {
                return default(TTo);
            }

            // ToDo: try to use Expando object for anonymous types;
            var mappingConfiguration = mappingConfig == null ? MapConfigDefault : mappingConfig(CreateMapConfigDefault());
            var mapper = new ObjectsMapper<TFrom, TTo>(ObjectMapperManager.DefaultInstance.GetMapperImpl(objFrom.GetType(), typeof(TTo), mappingConfiguration));

            return objTo == null ? mapper.Map(objFrom) : mapper.Map(objFrom, objTo, null);
        }

        private static MappingConfiguration CreateMapConfigDefault()
        {
            return new MappingConfiguration()
                .NullSubstitution<Guid?, Guid>(item => Guid.Empty)
                .ConvertUsing<Guid, Guid?>(item => item)
                .ConvertUsing<bool?, bool>(item => item.HasValue && item.Value)
                .ConvertUsing<int, bool>(item => item == 1)
                .ConvertUsing<bool, int>(item => item ? 1 : 0)
                .ConvertUsing<TimeZoneInfo, string>(item => item == null ? TimeZoneInfo.Utc.Id : item.Id)
                .ConvertUsing<string, TimeZoneInfo>(item => item.IsNullOrEmpty() ? TimeZoneInfo.Utc : TimeZoneInfo.FindSystemTimeZoneById(item))
                .ConvertUsing<string, Guid?>(
                    item =>
                    {
                        Guid guid;
                        return Guid.TryParse(item, out guid) ? (Guid?)guid : null;
                    })
                .ConvertUsing<Binary, byte[]>(item => item.ToArray())
                .ConvertUsing<string, XDocument>(
                    item =>
                    {
                        try
                        {
                            return XDocument.Parse(item);
                        }
                        catch
                        {
                            return null;
                        }
                    })
                .SetConfigName(Guid.NewGuid().ToString());
        }

        private static MappingConfiguration CreateMapConfigToDatabase(Func<MappingConfiguration, MappingConfiguration> mappingConfig, TimeZoneInfo timeZoneInfo)
        {
            return CreateMapConfig(mappingConfig)
                .ConvertUsing<DateTime, DateTime>(item => ConvertToUtcSafely(item, timeZoneInfo))
                .ConvertUsing<DateTime?, DateTime?>(item => item == null ? (DateTime?)null : ConvertToUtcSafely(item.Value, timeZoneInfo))
                .ConvertUsing<DateTime, DateTime?>(item => ConvertToUtcSafely(item, timeZoneInfo))
                .ConvertUsing<TimeSpan, TimeSpan>(item => ConvertToUtcSafely(item, timeZoneInfo))
                .ConvertUsing<TimeSpan?, TimeSpan?>(item => item == null ? (TimeSpan?)null : ConvertToUtcSafely(item.Value, timeZoneInfo))
                .ConvertUsing<TimeSpan, TimeSpan?>(item => ConvertToUtcSafely(item, timeZoneInfo))
                .SetConfigName("ToDatabase" + timeZoneInfo.Id);
        }

        private static MappingConfiguration CreateMapConfigFromDatabase(Func<MappingConfiguration, MappingConfiguration> mappingConfig, TimeZoneInfo timeZoneInfo)
        {
            return CreateMapConfig(mappingConfig)
                .ConvertUsing<DateTime, DateTime>(item => TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(item, DateTimeKind.Unspecified), TimeZoneInfo.Utc, timeZoneInfo))
                .ConvertUsing<DateTime?, DateTime?>(item => item.HasValue ? TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(item.Value, DateTimeKind.Unspecified), TimeZoneInfo.Utc, timeZoneInfo) : (DateTime?)null)
                .ConvertUsing<DateTime, DateTime?>(item => TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(item, DateTimeKind.Unspecified), TimeZoneInfo.Utc, timeZoneInfo))
                .SetConfigName("FromDatabase" + timeZoneInfo.Id);
        }

        // ToDo: what is the purpose of this method ?
        private static MappingConfiguration CreateMapConfigFromWcf(Func<MappingConfiguration, MappingConfiguration> mappingConfig, TimeZoneInfo timeZoneInfo)
        {
            return CreateMapConfig(mappingConfig)
                .ConvertUsing<DateTime, DateTime>(item => item.Kind == DateTimeKind.Local ? TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(item.ToUniversalTime(), DateTimeKind.Unspecified), TimeZoneInfo.Utc, timeZoneInfo) : item)
                .ConvertUsing<DateTime?, DateTime?>(item => item.HasValue && item.Value.Kind == DateTimeKind.Local ? TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(item.Value.ToUniversalTime(), DateTimeKind.Unspecified), TimeZoneInfo.Utc, timeZoneInfo) : item)
                .ConvertUsing<DateTime, DateTime?>(item => item.Kind == DateTimeKind.Local ? TimeZoneInfo.ConvertTime(DateTime.SpecifyKind(item.ToUniversalTime(), DateTimeKind.Unspecified), TimeZoneInfo.Utc, timeZoneInfo) : item)
                .SetConfigName("FromWcf" + timeZoneInfo.Id);
        }

        private static MappingConfiguration CreateMapConfig(Func<MappingConfiguration, MappingConfiguration> mappingConfig)
        {
            return mappingConfig == null ? CreateMapConfigDefault() : mappingConfig(CreateMapConfigDefault());
        }

        private static TimeSpan ConvertToUtcSafely(TimeSpan timeSpan, TimeZoneInfo timeZoneInfo)
        {
            return ConvertToUtcSafely(new DateTime().Add(timeSpan), timeZoneInfo).TimeOfDay;
        }

        private static DateTime ConvertToUtcSafely(DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            if (timeZoneInfo.IsInvalidTime(dateTime))
            {
                dateTime = dateTime + timeZoneInfo.BaseUtcOffset;
            }

            return TimeZoneInfo.ConvertTime(dateTime, timeZoneInfo, TimeZoneInfo.Utc);
        }
    }
}
