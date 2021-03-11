using FuegoDeQuasar.Domain.Entities;
using System.Collections.Generic;

namespace FuegoDeQuasar.Domain.Interfaces
{
    public interface ICommunicationBusiness
    {
        SatelliteResponse GetMessage(List<SatelliteRequest> payload);
    }
}