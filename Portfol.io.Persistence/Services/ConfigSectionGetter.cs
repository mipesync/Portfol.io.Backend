using Microsoft.Extensions.Configuration;
using Portfol.io.Application.Interfaces;

namespace Portfol.io.Persistence.Services
{
    public class ConfigSectionGetter : IConfigSectionGetter
    {
        public string GetSection(string key)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();
            var value = config.GetSection(key).Value;

            if (value == null) throw new Exception($"The value of the \"{key}\" section is null.");

            return value;
        }
    }
}
