namespace Tracker.Application.Abstractions
{
    public interface IDefaultQueryOptions
    {
        int PageSize { get; }
    }

    public interface ISettingsProvider
    {
        IDefaultQueryOptions DefaultQueryOptions { get; }
    }
}
