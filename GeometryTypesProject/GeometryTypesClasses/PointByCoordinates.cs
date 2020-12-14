using GeometryCoreProject.WireframeBaseClasses;
using GeometryCoreProject.WireframeBaseInterfaces;
using GeometryTypesProject.GeometryTypesInterfaces;

using System;

namespace GeometryTypesProject.GeometryTypesClasses
{
    public class PointByCoordinates : PointBase3D, IPointByCoordinates
    {
        IPointBase3D _BasePoint { get; set; } = new PointBase3D();
        public IPointBase3D RefPoint { get; set; } = new PointBase3D();
        public IAxisSystemBase3D RefAxisSystem { get; set; } = null;
        
        public void SetX(double iX){this.X = iX;}
        public void SetY(double iY){this.X = iY;}
        public void SetZ(double iZ){this.X = iZ;}
        public void SetXYZ(double iX, double iY, double iZ)
        {
            this.X = iX;
            this.Y = iY;
            this.Z = iZ;
        }

        public override void SetCoordinates(double[] iCoordinates)
        {
            this._BasePoint.SetCoordinates(iCoordinates);
            if (this.RefAxisSystem == null)
            {
                base.SetCoordinates(((PointBase3D)this._BasePoint + (PointBase3D)this.RefPoint).GetCoordinates());
            }
            else
            {
                IPointBase3D TranslatedPoint = this.PointRelativeToAxisSystem(this.RefAxisSystem);
                base.SetCoordinates(((PointBase3D)TranslatedPoint + (PointBase3D)this.RefPoint).GetCoordinates());
            }
        }

        public PointByCoordinates() { }
        public PointByCoordinates(double iX, double iY,double iZ)
        {
            this.X = iX;
            this.Y = iY;
            this.Z = iZ;
        }
        public PointByCoordinates(double iX, double iY, double iZ, IPointBase3D iRefPoint)
        {
            this.X = iRefPoint.X + iX;
            this.Y = iRefPoint.Y + iY;
            this.Z = iRefPoint.Z + iZ;
        }
        public PointByCoordinates(double iX, double iY, double iZ, IAxisSystemBase3D iRefAxisSystem)
        {
            this.RefAxisSystem = iRefAxisSystem;
            IPointBase3D NewPoint = this.TranslatePointAlongVector(iRefAxisSystem.Origin, iRefAxisSystem.XAxis,iX);
            NewPoint = this.TranslatePointAlongVector(NewPoint, iRefAxisSystem.YAxis, iY);
            NewPoint = this.TranslatePointAlongVector(NewPoint, iRefAxisSystem.ZAxis, iZ);
            this.X = NewPoint.X;
            this.Y = NewPoint.Y;
            this.Z = NewPoint.Z;
        }
        public PointByCoordinates(double iX, double iY, double iZ, IPointBase3D iRefPoint, IAxisSystemBase3D iRefAxisSystem )
        {
            this.RefAxisSystem = iRefAxisSystem;
            this.RefPoint = iRefPoint;
        }

        public void RemoveRefPoint()
        {
            this.RefPoint = new PointBase3D();
            this.SetCoordinates(this._BasePoint.GetCoordinates());
        }
        public void RemoveRefAxisSystem()
        {
            this.RefPoint = new PointBase3D();
            this.RefAxisSystem = null;
            this.SetCoordinates(this._BasePoint.GetCoordinates());
        }

        public void AddRefPoint(IPointBase3D iRefPoint)
        {
            if (this.RefAxisSystem != null) { throw new Exception("The Point Already Uses a Reference AxisSystem."); }
            // Store the Original Coordinates
            this._BasePoint.SetCoordinates(this.GetCoordinates());

            // Set the Reference Point
            this.RefPoint = iRefPoint;

            // Update the Coordinates
            this.SetCoordinates(this._BasePoint.GetCoordinates());
        }
        public void AddRefAxisSystem(IAxisSystemBase3D iRefAxisSystem)
        {
            if (!this.RefPoint.Equals(new PointBase3D())) { throw new Exception("The Point Already Uses a Reference Point."); }
            // Store the Original Coordinates
            this._BasePoint.SetCoordinates(this.GetCoordinates());

            // Set the Reference Point
            this.RefPoint = iRefAxisSystem.Origin;

            // Set the Reference AxisSystem
            this.RefAxisSystem = iRefAxisSystem;

            // Update the Coordinates
            this.SetCoordinates(this._BasePoint.GetCoordinates());
        }

        IPointBase3D PointRelativeToAxisSystem(IAxisSystemBase3D iRefAxisSystem)
        {
            IPointBase3D ReturnPoint = new PointBase3D();
            ReturnPoint = this.TranslatePointAlongVector(ReturnPoint, iRefAxisSystem.XAxis, this._BasePoint.X);
            ReturnPoint = this.TranslatePointAlongVector(ReturnPoint, iRefAxisSystem.YAxis, this._BasePoint.Y);
            ReturnPoint = this.TranslatePointAlongVector(ReturnPoint, iRefAxisSystem.ZAxis, this._BasePoint.Z);
            return ReturnPoint;
        }
    }
}
