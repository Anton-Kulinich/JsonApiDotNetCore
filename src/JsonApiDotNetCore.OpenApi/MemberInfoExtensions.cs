using System;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JsonApiDotNetCore.OpenApi
{
    internal static class MemberInfoExtensions
    {
        public static TypeCategory ResolveDataTypeCategory(this MemberInfo source)
        {
            ArgumentGuard.NotNull(source, nameof(source));

            Type memberType = source.MemberType == MemberTypes.Field ? ((FieldInfo)source).FieldType : ((PropertyInfo)source).PropertyType;

            if (memberType.IsValueType)
            {
                return Nullable.GetUnderlyingType(memberType) != null ? TypeCategory.NullableValueType : TypeCategory.ValueType;
            }

            // Once we switch to .NET 6 lands, this should be replaced with the built-in reflection support for nullability.
            return source.IsNonNullableReferenceType() ? TypeCategory.ReferenceType : TypeCategory.NullableReferenceType;
        }
    }
}
