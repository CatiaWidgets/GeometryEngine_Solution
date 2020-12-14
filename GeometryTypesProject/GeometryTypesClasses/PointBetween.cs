using GeometryCoreProject.WireframeBaseClasses;
using GeometryCoreProject.WireframeBaseInterfaces;
using GeometryTypesProject.GeometryTypesInterfaces;

using System;

namespace GeometryTypesProject.GeometryTypesClasses
{
    public class PointBetween : PointBase3D, IPointBetween
    {
        double _Ratio = 0.5;
        IVectorBase3D _RefVector
        {
            get
            {
                IVectorBase3D ReturnVector = new VectorBase3D();
                ReturnVector.I = (this.RefPoint2.X - this.RefPoint1.X);
                ReturnVector.J = (this.RefPoint2.Y - this.RefPoint1.Y);
                ReturnVector.K = (this.RefPoint2.Z - this.RefPoint1.Z);
                return ReturnVector;
            }
        }
        public IPointBase3D RefPoint1 { get; private set; } = null;
        public IPointBase3D RefPoint2 { get; private set; } = null;
        public bool Orientation { get; set; } = true;

        public PointBetween() { }
        public PointBetween(IPointBase3D iPoint1, IPointBase3D iPoint2) 
        {
            this.RefPoint1 = iPoint1;
            this.RefPoint2 = iPoint2;

            IPointBase3D TranslatedPoint = this.TranslatePointAlongVector(this.RefPoint1, this._RefVector, this._RefVector.Magnitude * this._Ratio);
            this.SetCoordinates(TranslatedPoint.GetCoordinates());
        }
        public PointBetween(IPointBase3D iPoint1, IPointBase3D iPoint2, double iRatio)
        {
            this.RefPoint1 = iPoint1;
            this.RefPoint2 = iPoint2;
            this.SetRatio(iRatio);

            IPointBase3D TranslatedPoint = this.TranslatePointAlongVector(this.RefPoint1, this._RefVector, this._RefVector.Magnitude * this._Ratio);
            this.SetCoordinates(TranslatedPoint.GetCoordinates());
        }


        public void SetRefPoint1(IPointBase3D iRefPoint)
        {
            this.RefPoint1 = iRefPoint;
            this.UpdateThis();

        }
        public void SetRefPoint2(IPointBase3D iRefPoint)
        {
            this.RefPoint2 = iRefPoint;
            this.UpdateThis();
        }
        public void SetRefPoints(IPointBase3D iRefPoint1, IPointBase3D iRefPoint2)
        {
            this.RefPoint1 = iRefPoint1;
            this.RefPoint2 = iRefPoint2;
            this.UpdateThis();
        }


        public double GetRatio()
        {
            return this._Ratio;
        }
        public void SetRatio(double iRatio)
        {
            if (Math.Abs(iRatio) > 1 || iRatio < 0) { throw new Exception("Ratio Value Must be Between 0 and 1."); }
            this._Ratio = (this.Orientation == true) ? iRatio : 1 - iRatio;
            this.UpdateThis();
        }

        void UpdateThis()
        {
            IPointBase3D RefPoint = (this.Orientation == true) ? this.RefPoint1 : this.RefPoint2;
            IPointBase3D TranslatedPoint = this.TranslatePointAlongVector(RefPoint, this._RefVector, this._RefVector.Magnitude * this._Ratio);
            this.SetCoordinates(TranslatedPoint.GetCoordinates());
        }   
    }
}
