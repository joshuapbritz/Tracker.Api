using Tracker.Domain.Abstractions;

namespace Tracker.Domain.Settings
{
    public sealed class DefaultQueryOptions : IValidatedSettingsGroup
    {
        public const string SectionName = "DefaultQueryOptions";
        public int PageSize { get; init; } = 10;

        public bool ValidateSettings()
        {
            return PageSize > 0;
        }
    }
}
