using GeometryCoreProject.WireframeBaseInterfaces;

namespace GeometryTypesProject.GeometryTypesInterfaces
{
    public interface IPointByCoordinates : IPointBase3D
    {
        IPointBase3D RefPoint { get; set; }
        IAxisSystemBase3D RefAxisSystem { get; set; }
        void SetX(double iX);
        void SetY(double iY);
        void SetZ(double iZ);
        void SetXYZ(double iX,double iY, double iZ);
        void AddRefPoint(IPointBase3D iRefPoint);
        void RemoveRefPoint();
        void AddRefAxisSystem(IAxisSystemBase3D iRefAxisSystem);
        void RemoveRefAxisSystem();
    }
}
