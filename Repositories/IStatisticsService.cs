using Bimbrownik_API.Models.Dto;

namespace Bimbrownik_API.Services
{
    public interface IStatisticsService
    {
        Task<StatisticsDto> GetStatisticsAsync();
    }
}
