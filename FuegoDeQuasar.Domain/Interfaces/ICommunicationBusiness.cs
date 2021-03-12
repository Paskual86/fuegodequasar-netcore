using FuegoDeQuasar.Domain.Entities;
using System.Collections.Generic;

namespace FuegoDeQuasar.Domain.Interfaces
{
    public interface ICommunicationBusiness
    {
        bool GetMessage(List<SatelliteRequest> payload, out SatelliteResponse response);
    }
}