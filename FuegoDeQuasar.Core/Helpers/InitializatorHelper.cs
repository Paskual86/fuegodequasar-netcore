using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Domain.Interfaces;

namespace FuegoDeQuasar.Core.Helpers
{
    public class InitializatorHelper : IInitializatorHelper
    {
        public Location GetLocationSatelliteKenobi()
        {
            return new Location()
            {
                X = -500,
                Y = -200
            };
        }

        public Location GetLocationSatelliteSato()
        {
            return new Location()
            {
                X = 100,
                Y = -100
            };
        }

        public Location GetLocationSatelliteSkywalker()
        {
            return new Location()
            {
                X = 500,
                Y = 100
            };
        }
    }
}
