using FuegoDeQuasar.Domain.Entities;

namespace FuegoDeQuasar.Domain.Interfaces
{
    public interface IMathOperation
    {
        Location GetLocation(decimal? distanceTransmiterKenobi, decimal? distanceTransmiterSkywalker, decimal? distanceTransmiterSato);
        decimal CalculateDistance(Location position1, Location postion2);
    }
}
