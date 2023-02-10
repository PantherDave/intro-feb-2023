namespace LearningResourcesApi.Services;

public class SystemTime : ISystemTime
{
    public DateTimeOffset GetCurrent() => DateTimeOffset.Now;
}
