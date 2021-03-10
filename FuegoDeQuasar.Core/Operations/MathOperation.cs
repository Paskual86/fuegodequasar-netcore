using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Domain.Interfaces;
using System;

namespace FuegoDeQuasar.Core.Operations
{
    public class MathOperation : IMathOperation
    {
        private readonly Location _satelliteKenobi;
        private readonly Location _satelliteSkywalker;
        private readonly Location _satelliteSato;

        public MathOperation(IInitializatorHelper initializator)
        {
            _satelliteKenobi = initializator.GetLocationSatelliteKenobi();
            _satelliteSkywalker = initializator.GetLocationSatelliteSkywalker();
            _satelliteSato = initializator.GetLocationSatelliteSato();
        }

        public decimal CalculateDistance(Location position1, Location postion2)
        {
            decimal X = position1.X - postion2.X;
            decimal Y = position1.Y - postion2.Y;
            return (decimal) Math.Sqrt(Math.Pow((double)X, 2) + Math.Pow((double)Y, 2));
        }

        public byte GetGuadrant(Location location) 
        {
            if (location == null) return 0;
            if (location.X < 0 && location.Y >= 0) return 1;
            if (location.X >= 0 && location.Y >= 0) return 2;
            if (location.X >= 0 && location.Y < 0) return 3;
            if (location.X < 0 && location.Y < 0) return 4;
            return 0;
        }

        public Location GetLocation(decimal? distanceTransmiterKenobi, decimal? distanceTransmiterSkywalker, decimal? distanceTransmiterSato)
        {
            var locationResult = new Location();

            /* Cosas a tener en cuenta en el calculo.
             * Si el satelite esta a la izquierda, en los cuadrantes 1 y 3:
             *                                                              Si el angulo es menor a Pi/2 quiere decir que la nave esta a la derecha
             *                                                              Si el angulo es mayor a pi/2 quiere decir que la nave esta a la izquierda
             * Si el Satelite esta a la derecha, en los cuadrantes 2 y 4: 
             *                                                              Si el angulo es menor a Pi/2 quiere decir que la nave esta a la izquierda
             *                                                              Si el angulo es mayor a pi/2 quiere decir que la nave esta a la derecha
             * Una vez obtenido el angulo principal, es necesario ver 
            */

            if ((!distanceTransmiterKenobi.HasValue) && (!distanceTransmiterSkywalker.HasValue) && (!distanceTransmiterSato.HasValue))
            {
                throw new Exception("There is not possible complete the operation");
            }

            if (distanceTransmiterKenobi.HasValue && distanceTransmiterSkywalker.HasValue) 
            {
                var distanceKenobiSkywalker = CalculateDistance(_satelliteKenobi, _satelliteSkywalker);

                //

            }

            if (distanceTransmiterSato.HasValue && distanceTransmiterSkywalker.HasValue)
            {
                var distanceSatoSkywalker = CalculateDistance(_satelliteSato, _satelliteSkywalker);

                //
                var angleSkywalker = GetAngle(distanceTransmiterSato.Value, distanceTransmiterSkywalker.Value, distanceSatoSkywalker);
                var angleSato = GetAngle(distanceTransmiterSkywalker.Value, distanceTransmiterSato.Value, distanceSatoSkywalker);
                var angleNave = GetAngle(distanceSatoSkywalker, distanceTransmiterSkywalker.Value, distanceTransmiterSato.Value);


                if (_satelliteSato.Y > _satelliteSkywalker.Y)
                {
                    // Como se cuanto vale el adyancente, calculo el angulo que hay entre el satellite skywalker y Sato
                    var angleSatoSky = Math.Acos((double)Math.Abs(_satelliteSkywalker.X - _satelliteSato.X) / (double)distanceSatoSkywalker);
                    var angleFinal = Math.PI - angleSatoSky + (double)angleSkywalker;
                    locationResult.X = (decimal)(Math.Cos(angleFinal) * (double)distanceTransmiterSkywalker);
                    locationResult.Y = (decimal)(Math.Sin(angleFinal) * (double)distanceTransmiterSkywalker);
                }

            }

            return new Location();
        }

        private decimal GetAngle(decimal a, decimal b, decimal c)
        {
            var powa = Math.Pow((double)a, 2);
            var powb = Math.Pow((double)b, 2);
            var powc = Math.Pow((double)c, 2);

            var dividendo = powa - powb - powc;
            var divisor = -2 * b * c;
            if (divisor > 0)
            {
                return (decimal)Math.Acos((dividendo / (double)divisor));
            }
            return 0;
        }
    }
}
