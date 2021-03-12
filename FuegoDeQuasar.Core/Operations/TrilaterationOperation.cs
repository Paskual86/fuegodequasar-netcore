using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Domain.Interfaces;
using System;

namespace FuegoDeQuasar.Core.Operations
{
    public class TrilaterationOperation : ITrilaterationOperation
    {
        private readonly Location _satelliteKenobi;
        private readonly Location _satelliteSkywalker;
        private readonly Location _satelliteSato;
        private readonly IMathOperation _mathOperation;
        public TrilaterationOperation(IInitializatorHelper initializator, IMathOperation mathOperation)
        {
            _satelliteKenobi = initializator.GetLocationSatelliteKenobi();
            _satelliteSkywalker = initializator.GetLocationSatelliteSkywalker();
            _satelliteSato = initializator.GetLocationSatelliteSato();
            _mathOperation = mathOperation;
        }

        public Location GetLocation(decimal? distanceTransmiterKenobi, decimal? distanceTransmiterSkywalker, decimal? distanceTransmiterSato)
        {
            var locationResult = new Location();

            if (!distanceTransmiterKenobi.HasValue ||
                !distanceTransmiterSkywalker.HasValue ||
                !distanceTransmiterSato.HasValue) return null;


            var ex = _mathOperation.DividePoint(_mathOperation.SubstractPoint(_satelliteKenobi, _satelliteSato), _mathOperation.Normalize(_mathOperation.SubstractPoint(_satelliteKenobi, _satelliteSato)));

            var i = _mathOperation.Dot(ex, _mathOperation.SubstractPoint(_satelliteSkywalker, _satelliteKenobi));

            var a = _mathOperation.SubstractPoint(_mathOperation.SubstractPoint(_satelliteSkywalker, _satelliteKenobi), _mathOperation.MultiplyPoint(ex, i));

            var ey = _mathOperation.DividePoint(a, _mathOperation.Normalize(a));

            var d = _mathOperation.Normalize(_mathOperation.SubstractPoint(_satelliteKenobi, _satelliteSato));
            var j = _mathOperation.Dot(ey, _mathOperation.SubstractPoint(_satelliteSkywalker, _satelliteKenobi));


            locationResult.X = (_mathOperation.Square(distanceTransmiterKenobi.Value) - _mathOperation.Square(distanceTransmiterSato.Value) + _mathOperation.Square(d)) / (2 * d);

            locationResult.Y = (_mathOperation.Square(distanceTransmiterKenobi.Value) - _mathOperation.Square(distanceTransmiterSkywalker.Value) + _mathOperation.Square(i) + _mathOperation.Square(j)) / (2 * j) - (i / j) * locationResult.X;

            return locationResult;
        }

        public decimal CalculateDistance(Location position1, Location postion2)
        {
            decimal X = position1.X - postion2.X;
            decimal Y = position1.Y - postion2.Y;
            return (decimal)Math.Sqrt(Math.Pow((double)X, 2) + Math.Pow((double)Y, 2));
        }
    }
}
