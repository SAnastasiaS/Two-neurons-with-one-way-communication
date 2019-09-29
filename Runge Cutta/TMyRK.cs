using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LabWork1
{
    public class TMyRK : RungeKutta
    {
        private double gamma, d, sigma;
        public TMyRK(double _gamma, double _d, double _sigma, uint N)
        {
            gamma = _gamma;
            d = _d;
            sigma = _sigma;
            Init (N);
        }

        /// <param name="t">Время</param>
        /// <param name="V">Решение</param>
        /// <returns>Правая часть</returns>
        public override Matrix<double> systF (double t, Matrix<double> XY)
        {
            if ((XY[1, 0] > Math.PI/2-sigma && XY[1, 0] < Math.PI/2+sigma && Math.PI/2-sigma>0)||(Math.PI / 2 - sigma < 0 && (XY[1, 0] > 2 * Math.PI - sigma + Math.PI/2 || XY[1, 0] < Math.PI / 2 + sigma)))//если в области
            {
                F[0, 0] = gamma - Math.Sin(XY[0, 0]);//!!!проверить систему!
                F[1, 0] = gamma - Math.Sin(XY[1, 0]);
            }
            else
            {
                F[0, 0] = gamma - Math.Sin(XY[0, 0]) + d ;//!!!проверить систему!
                F[1, 0] = gamma - Math.Sin(XY[1, 0]);
            }
            return F;
        }

        /// Пример использования
    }
}
