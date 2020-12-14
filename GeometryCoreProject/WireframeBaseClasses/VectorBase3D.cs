using GeometryCoreProject.AbstractClasses;
using GeometryCoreProject.WireframeBaseInterfaces;

using System;

namespace GeometryCoreProject.WireframeBaseClasses
{
    public class VectorBase3D : GeometryBase, IVectorBase3D
    {
        public double I { get; set; }
        public double J { get; set; }
        public double K { get; set; }

        public double Magnitude => Math.Sqrt(Math.Pow(this.I,2)+ Math.Pow(this.J,2) + Math.Pow(this.K,2));
        public IVectorBase3D UnitVector
        {
            get
            {
                IVectorBase3D UnitVector = new VectorBase3D();
                UnitVector.I = (this.I / this.Magnitude);
                UnitVector.J = (this.J / this.Magnitude);
                UnitVector.K = (this.K / this.Magnitude);
                return UnitVector;
            }
        }
        public IVectorBase3D InverseVector
        {
            get
            {
                IVectorBase3D InverseVector = new VectorBase3D();
                InverseVector.I = (-this.I);
                InverseVector.J = (-this.J);
                InverseVector.K = (-this.K);
                return InverseVector;
            }
        }

        public VectorBase3D() { }
        public VectorBase3D(double iI, double iJ, double iK) 
        {
            this.I = iI;
            this.J = iJ;
            this.K = iK;
        }

        public override bool Equals(object obj)
        {
            return false;
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
