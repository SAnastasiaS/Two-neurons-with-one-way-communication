using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace LabWork1
{
    public abstract class RungeKutta
    {

        public double t;

        public Matrix<double> XY, k1, k2, k3, k4, F = Matrix<double>.Build.Dense(2, 1);
        public uint i;

        
        private uint order;

        public RungeKutta(uint N, uint _order)
        {
            Init(N);
            order = _order;
        }

        public RungeKutta() { }

        protected void Init(uint N)
        {
            i = 0;

            
    }

        public void SetInit(double t0, Matrix<double> XY0)
        {
            t = t0;
            XY = XY0;

        }

        abstract public Matrix<double> systF(double t, Matrix<double> XY);

        public void NextStep(double h)
        {
            
            //if (h < 0) return;

            k1 = systF(t, XY);

            k2 = systF(t + h / 2, XY + (h / 2) * k1);

            k3 = systF(t + h / 2, XY + (h / 2) * k2);

            k4 = systF(t + h, XY + h * k3);

            XY = XY + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);

            t = t + h;
            i = i + 1;
 
        }


    }


}
