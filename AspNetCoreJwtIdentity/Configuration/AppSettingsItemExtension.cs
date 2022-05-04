namespace AspNetCoreJwtIdentity.Configuration
{
    public static class AppSettingsItemExtension
    {
        public static T Section<T>(this IConfiguration configuration, AppSettingsItem appSettingsItem, string? name)
        {
            if (name is null)
            {
                return configuration.GetSection($"AppSettings:{appSettingsItem}").Get<T>();
            }
            return configuration.GetSection($"AppSettings:{appSettingsItem}:{name}").Get<T>();
        }
    }
}
