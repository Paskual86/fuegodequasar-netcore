using FuegoDeQuasar.Domain.Entities;

namespace FuegoDeQuasar.Domain.Interfaces
{
    public interface ITrilaterationOperation
    {
        decimal CalculateDistance(Location position1, Location postion2);
        Location GetLocation(decimal? distanceTransmiterKenobi, decimal? distanceTransmiterSkywalker, decimal? distanceTransmiterSato);
    }
}