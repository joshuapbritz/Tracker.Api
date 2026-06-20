using Microsoft.Extensions.Configuration;
using Tracker.Application.Abstractions;

namespace Tracker.Infrastructure.Settings
{
    public sealed record DefaultQueryOptions : IDefaultQueryOptions
    {
        public int PageSize { get; }

        public DefaultQueryOptions(IConfigurationSection configurationSection)
        {
            PageSize = configurationSection.GetValue<int>("PageSize", 10);
        }
    }

    public sealed class SettingsProvider(IConfiguration configuration) : ISettingsProvider
    {
        public IDefaultQueryOptions DefaultQueryOptions { get; } = new DefaultQueryOptions(configuration.GetSection("DefaultQueryOptions"));
    }
}
