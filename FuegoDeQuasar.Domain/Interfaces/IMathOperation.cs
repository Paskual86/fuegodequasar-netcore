using FuegoDeQuasar.Domain.Entities;

namespace FuegoDeQuasar.Domain.Interfaces
{
    public interface IMathOperation
    {
        decimal CalculateDistance(Location position1, Location postion2);
        decimal GetAngle(decimal a, decimal b, decimal c);
        Location DividePoint(Location point, decimal divider);
        Location MultiplyPoint(Location point, decimal multiplier);
        Location AddPoint(Location point1, Location point2);
        Location SubstractPoint(Location point1, Location point2);
        decimal Dot(Location point1, Location point2);
        decimal Normalize(Location point);
        byte GetGuadrant(Location location);
        decimal Square(decimal value);
    }
}
