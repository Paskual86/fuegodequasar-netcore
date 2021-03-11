using FuegoDeQuasar.Domain.Entities;
using FuegoDeQuasar.Domain.Interfaces;
using System;

namespace FuegoDeQuasar.Core.Operations
{
    public class MathOperation : IMathOperation
    {

        public Location DividePoint(Location point, decimal divider) 
        {
            if (divider == 0) return point;
            return new Location()
            {
                X = point.X / divider,
                Y = point.Y / divider
            };
        }

        public Location MultiplyPoint(Location point, decimal multiplier)
        {
            return new Location()
            {
                X = point.X * multiplier,
                Y = point.Y * multiplier
            };
        }

        public Location AddPoint(Location point1, Location point2)
        {
            return new Location()
            {
                X = point1.X + point2.X,
                Y = point1.Y + point2.Y
            };
        }


        public Location SubstractPoint(Location point1, Location point2)
        {
            return new Location()
            {
                X = point1.X - point2.X,
                Y = point1.Y - point2.Y
            };
        }

        public decimal Dot(Location point1, Location point2)
        {
            return point1.X * point2.X + point1.Y * point2.Y;
        }

        public decimal Normalize(Location point)
        {
            return (decimal)(Math.Sqrt((double)(Square(point.X) + Square(point.Y))));
        }

        public decimal CalculateDistance(Location position1, Location postion2)
        {
            decimal X = position1.X - postion2.X;
            decimal Y = position1.Y - postion2.Y;
            return (decimal) Math.Sqrt((double)(Square(X) + Square(Y)));
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

        public decimal GetAngle(decimal a, decimal b, decimal c)
        {
            var powa = Square(a);
            var powb = Square(b);
            var powc = Square(c);

            var dividendo = powa - powb - powc;
            var divisor = -2 * b * c;
            if (divisor > 0)
            {
                return (decimal)Math.Acos((double)(dividendo / divisor));
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal Square(decimal value) 
        {
            return (decimal)Math.Pow((double)value, 2);
        }
    }
}
