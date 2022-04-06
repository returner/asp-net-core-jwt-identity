using SharedModel.Interfaces.Configuration;

namespace AspNetCoreJwtIdentity.Properties
{
    public class TokenSetting : ITokenSetting
    {
        public int DefaultExpireIntervalMinutes {get;set;}
    }
}
