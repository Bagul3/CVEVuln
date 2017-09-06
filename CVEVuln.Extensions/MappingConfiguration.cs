using EmitMapper.MappingConfiguration;
using EmitMapper.MappingConfiguration.MappingOperations;
using EmitMapper.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CVEVuln.Extensions
{
    public class MappingConfiguration : MapConfigBase<MappingConfiguration>
    {
        private static readonly MappingConfiguration InstanceLocal;
        private static readonly Type[] NativeTypesToConvert =
            {
                typeof(bool),
                typeof(char),
                typeof(sbyte),
                typeof(byte),
                typeof(short),
                typeof(int),
                typeof(long),
                typeof(ushort),
                typeof(uint),
                typeof(ulong),
                typeof(float),
                typeof(double),
                typeof(decimal),
                typeof(DateTime),
                typeof(string)
            };

        private readonly List<string> shallowCopyMembers = new List<string>();
        private readonly List<string> deepCopyMembers = new List<string>();
        private bool shallowCopy;
        private Func<string, string, bool> membersMatcher;

        static MappingConfiguration()
        {
            InstanceLocal = new MappingConfiguration();
        }

        public MappingConfiguration()
        {
            Init(this);
            shallowCopy = true;
            membersMatcher = (m1, m2) => m1 == m2;
        }

        public static MappingConfiguration Instance
        {
            get { return InstanceLocal; }
        }

        public MappingConfiguration ShallowMap<T>()
        {
            return ShallowMap(typeof(T));
        }

        public MappingConfiguration ShallowMap(Type type)
        {
            shallowCopyMembers.Add(type.FullName);
            return this;
        }

        public MappingConfiguration ShallowMap()
        {
            shallowCopy = true;
            return this;
        }

        public MappingConfiguration DeepMap<T>()
        {
            return DeepMap(typeof(T));
        }

        public MappingConfiguration DeepMap(Type type)
        {
            deepCopyMembers.Add(type.FullName);
            return this;
        }

        public MappingConfiguration DeepMap()
        {
            shallowCopy = false;
            return this;
        }

        public MappingConfiguration MatchMembers(Func<string, string, bool> membersMatcher)
        {
            this.membersMatcher = membersMatcher;
            return this;
        }

        public override IMappingOperation[] GetMappingOperations(Type from, Type to)
        {
            return FilterOperations(from, to, GetMappingItems(new HashSet<TypesPair>(), from, to, null, null)).ToArray();
        }

        public override IRootMappingOperation GetRootMappingOperation(Type from, Type to)
        {
            var res = base.GetRootMappingOperation(from, to);
            res.ShallowCopy = IsShallowCopy(from, to);

            return res;
        }

        public override string GetConfigurationName()
        {
            return base.GetConfigurationName() + ToCsv(new[] { shallowCopy.ToString(), ToStr(membersMatcher), ToStrEnum(shallowCopyMembers), ToStrEnum(deepCopyMembers) }, ";");
        }

        protected virtual bool MatchMembers(string m1, string m2)
        {
            return membersMatcher(m1, m2);
        }

        private static bool IsNativeDeepCopy(Type typeFrom, Type typeTo, bool shallowCopy)
        {
            if (IsNativeConvertionPossible(typeFrom, typeTo))
            {
                return false;
            }

            if (IsSupportedType(typeFrom) || IsSupportedType(typeTo))
            {
                return false;
            }

            if (typeTo != typeFrom || !shallowCopy)
            {
                return true;
            }

            return false;
        }

        private static bool IsSupportedType(Type type)
        {
            return type.IsArray || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                   || type == typeof(ArrayList) || typeof(IList).IsAssignableFrom(type)
                   || typeof(IList<>).IsAssignableFrom(type);
        }

        private static bool IsNativeConvertionPossible(Type from, Type to)
        {
            if (from == null || to == null)
            {
                return false;
            }

            if (NativeTypesToConvert.Contains(from) && NativeTypesToConvert.Contains(to))
            {
                return true;
            }

            if (to == typeof(string))
            {
                return true;
            }

            if (from == typeof(string) && to == typeof(Guid))
            {
                return true;
            }

            if (from.IsEnum && to.IsEnum)
            {
                return true;
            }

            if (from.IsEnum && NativeTypesToConvert.Contains(to))
            {
                return true;
            }

            if (to.IsEnum && NativeTypesToConvert.Contains(from))
            {
                return true;
            }

            if (ReflectionUtils.IsNullable(from))
            {
                return IsNativeConvertionPossible(Nullable.GetUnderlyingType(from), to);
            }

            return ReflectionUtils.IsNullable(to) && IsNativeConvertionPossible(from, Nullable.GetUnderlyingType(to));
        }

        private static string ToCsv<T>(IEnumerable<T> collection, string delimiter)
        {
            if (collection == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            foreach (var current in collection)
            {
                stringBuilder.Append(current);
                stringBuilder.Append(delimiter);
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.Length -= delimiter.Length;
            }

            return stringBuilder.ToString();
        }

        private static string GetMapName(Type type, string mappedProperty)
        {
            return type.GetProperties()
                    .Where(item => item.Name == mappedProperty)
                    .SelectMany(item => item.GetCustomAttributes(typeof(MapAttribute), false).Cast<MapAttribute>().Select(attr => attr.Name))
                    .FirstOrDefault();
        }

        private bool TypeInList(IEnumerable<string> list, Type type)
        {
            return list.Any(l => MatchMembers(l, type.FullName));
        }

        private List<IMappingOperation> GetMappingItems(
            HashSet<TypesPair> processedTypes,
            Type fromRoot,
            Type toRoot,
            IEnumerable<MemberInfo> toPath,
            IEnumerable<MemberInfo> fromPath)
        {
            var toMembersInfo = toPath.CollectionOrEmpty().ToArray();
            var fromMembersInfo = fromPath.CollectionOrEmpty().ToArray();
            var from = fromMembersInfo.IsNullOrEmpty() ? fromRoot : ReflectionUtils.GetMemberType(fromMembersInfo.Last());
            var to = toMembersInfo.IsNullOrEmpty() ? toRoot : ReflectionUtils.GetMemberType(toMembersInfo.Last());
            var typesPair = new TypesPair(from, to);
            processedTypes.Add(typesPair);
            var toMembers = ReflectionUtils.GetPublicFieldsAndProperties(to);
            var fromMembers = ReflectionUtils.GetPublicFieldsAndProperties(from);
            var result = new List<IMappingOperation>();

            foreach (var toMemberInfo in toMembers)
            {
                if (toMemberInfo.MemberType == MemberTypes.Property)
                {
                    var setMethod = ((PropertyInfo)toMemberInfo).GetSetMethod();
                    if (setMethod == null || setMethod.GetParameters().Length != 1)
                    {
                        continue;
                    }
                }

                var fromMemberInfo = fromMembers.FirstOrDefault(mi => MatchMembers(mi.Name, toMemberInfo.Name) || MatchMembers(mi.Name, GetMapName(to, toMemberInfo.Name)) || MatchMembers(GetMapName(from, mi.Name), toMemberInfo.Name));
                if (fromMemberInfo == null)
                {
                    continue;
                }

                if (fromMemberInfo.MemberType == MemberTypes.Property)
                {
                    var getMethod = ((PropertyInfo)fromMemberInfo).GetGetMethod();
                    if (getMethod == null)
                    {
                        continue;
                    }
                }

                var op = CreateMappingOperation(processedTypes, toMembersInfo, fromMembersInfo, fromMemberInfo, toMemberInfo);
                if (op != null)
                {
                    result.Add(op);
                }
            }

            processedTypes.Remove(typesPair);

            return result;
        }

        private IMappingOperation CreateMappingOperation(
            HashSet<TypesPair> processedTypes,
            IEnumerable<MemberInfo> toPath,
            IEnumerable<MemberInfo> fromPath,
            MemberInfo fromMemberInfo,
            MemberInfo toMemberInfo)
        {
            var toMembersInfo = toPath.CollectionOrEmpty().ToArray();
            var fromMembersInfo = fromPath.CollectionOrEmpty().ToArray();
            var origDestMemberDescr = new MemberDescriptor(toMembersInfo.Concat(new[] { toMemberInfo }).ToArray());
            var origSrcMemberDescr = new MemberDescriptor(fromMembersInfo.Concat(new[] { fromMemberInfo }).ToArray());

            if (ReflectionUtils.IsNullable(ReflectionUtils.GetMemberType(fromMemberInfo)))
            {
                fromMembersInfo = fromMembersInfo.Concat(new[] { fromMemberInfo }).ToArray(); // ToDo: it might be optional. Try to comment.
                fromMemberInfo = ReflectionUtils.GetMemberType(fromMemberInfo).GetProperty("Value");
            }

            if (ReflectionUtils.IsNullable(ReflectionUtils.GetMemberType(toMemberInfo)))
            {
                toMembersInfo = fromMembersInfo.Concat(new[] { toMemberInfo }).ToArray(); // ToDo: it might be optional. Try to comment.
                toMemberInfo = ReflectionUtils.GetMemberType(toMemberInfo).GetProperty("Value");
            }

            var destMemberDescriptor = new MemberDescriptor(toMembersInfo.Concat(new[] { toMemberInfo }).ToArray());
            var srcMemberDescriptor = new MemberDescriptor(fromMembersInfo.Concat(new[] { fromMemberInfo }).ToArray());
            var typeFromMember = srcMemberDescriptor.MemberType;
            var typeToMember = destMemberDescriptor.MemberType;
            var shallowCopy = IsShallowCopy(srcMemberDescriptor, destMemberDescriptor);

            if (IsNativeDeepCopy(typeFromMember, typeToMember, shallowCopy) && !processedTypes.Contains(new TypesPair(typeFromMember, typeToMember)))
            {
                return new ReadWriteComplex
                {
                    Destination = origDestMemberDescr,
                    Source = origSrcMemberDescr,
                    ShallowCopy = shallowCopy,
                    Operations = GetMappingItems(processedTypes, srcMemberDescriptor.MemberType, destMemberDescriptor.MemberType, null, null)
                };
            }

            return new ReadWriteSimple
            {
                Source = origSrcMemberDescr,
                Destination = origDestMemberDescr,
                ShallowCopy = shallowCopy,
            };
        }

        private bool IsShallowCopy(Type from, Type to)
        {
            if (TypeInList(shallowCopyMembers, to) || TypeInList(shallowCopyMembers, from))
            {
                return true;
            }

            if (TypeInList(deepCopyMembers, to) || TypeInList(deepCopyMembers, @from))
            {
                return false;
            }

            return shallowCopy;
        }

        private bool IsShallowCopy(MemberDescriptor from, MemberDescriptor to)
        {
            return IsShallowCopy(from.MemberType, to.MemberType);
        }

        private class TypesPair
        {
            private readonly Type t1;

            private readonly Type t2;

            public TypesPair(Type t1, Type t2)
            {
                this.t1 = t1;
                this.t2 = t2;
            }

            public override bool Equals(object obj)
            {
                var rhs = (TypesPair)obj;
                return t1 == rhs.t1 && t2 == rhs.t2;
            }

            public override int GetHashCode()
            {
                return t1.GetHashCode() + t2.GetHashCode();
            }
        }
    }
}
