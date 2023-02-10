namespace LearningResourcesApi.Services;

public interface ISystemTime
{
    DateTimeOffset GetCurrent();
}
