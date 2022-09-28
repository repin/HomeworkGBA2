using MetricsManager.Models.Requests;

namespace MetricsManager.Services.Client
{
    public interface IMetricsAgentClient
    {
        CpuMetricsResponse GetCpuMetrics(CpuMetricsRequest request);
        RamMetricsResponse GetRamMetrics(RamMetricsRequest request);
        HddMetricsResponse GetHddMetrics(HddMetricsRequest request);
        NetworkMetricsResponse GetNetworkMetrics(NetworkMetricsRequest request);
        DotnetMetricsResponse GetDotnetMetrics(DotnetMetricsRequest request);
    }
}
