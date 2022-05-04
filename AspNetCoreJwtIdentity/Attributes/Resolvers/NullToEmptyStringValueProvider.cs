using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace AspNetCoreJwtIdentity.Attributes.Resolvers
{
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }

        public object GetValue(object target)
        {
            object? result = _MemberInfo.GetValue(target);
            if (result == null)
            {
                result = string.Empty;
            }

            return result;
        }

        public void SetValue(object target, object? value)
        {
            _MemberInfo.SetValue(target, value);
        }
    }
}