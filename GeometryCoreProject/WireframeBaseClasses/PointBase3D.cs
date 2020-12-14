using GeometryCoreProject.AbstractClasses;
using GeometryCoreProject.WireframeBaseInterfaces;

namespace GeometryCoreProject.WireframeBaseClasses
{
    public class PointBase3D : GeometryBase , IPointBase3D
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 0;

        public PointBase3D() { }
        public PointBase3D(double iX, double iY, double iZ) { this.X = iX; this.Y = iY;this.Z = iZ; }

        public IPointBase3D TranslatePointAlongVector(IPointBase3D iRefPoint, IVectorBase3D iRefVector, double iOffset)
        {          
            double X = (iRefVector.UnitVector.I * iOffset) + iRefPoint.X;
            double Y = (iRefVector.UnitVector.J * iOffset) + iRefPoint.Y;
            double Z = (iRefVector.UnitVector.K * iOffset) + iRefPoint.Z;

            IPointBase3D ReturnPoint = new PointBase3D();
            ReturnPoint.SetCoordinates(new double[]{ X,Y,Z});

            return ReturnPoint;
        }

        public virtual void SetCoordinates(double[] iCoordinates)
        {
            this.X = iCoordinates[0];
            this.Y = iCoordinates[1];
            this.Z = iCoordinates[2];
        }
        public double[] GetCoordinates()
        {
            return new double[] { this.X, this.Y, this.Z };
        }

        public static IPointBase3D operator +(PointBase3D iPoint1, PointBase3D iPoint2)
        {
            return new PointBase3D(iPoint1.X+iPoint2.X, iPoint1.Y + iPoint2.Y, iPoint1.Z + iPoint2.Z);
        }

        public static IPointBase3D operator -(PointBase3D iPoint1, PointBase3D iPoint2)
        {
            return new PointBase3D(iPoint1.X - iPoint2.X, iPoint1.Y - iPoint2.Y, iPoint1.Z - iPoint2.Z);
        }

        public override bool Equals(object obj)
        {
            bool ReturnBoolean = false;
            if((IPointBase3D)obj is IPointBase3D)
            {
                IPointBase3D ValidationPoint = (IPointBase3D)obj;
                if (this.X.Equals(ValidationPoint.X) && this.Y.Equals(ValidationPoint.Y) && this.Z.Equals(ValidationPoint.Z))
                {
                    ReturnBoolean = true;
                }
            }
            return ReturnBoolean;
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
