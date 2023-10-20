using NetworkMonitor.Common.Dto;

namespace NetworkMonitor.Common.Interfaces
{
    /// <summary> Получение информации об узле сети. </summary>
    public interface IHostInformationService
    {
        /// <summary> Получение информации об узле сети. </summary>
        HostInformation GetHostInformation();
    }
}