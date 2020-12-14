using GeometryCoreProject.WireframeBaseInterfaces;

namespace GeometryTypesProject.GeometryTypesInterfaces
{
    public interface IPointBetween : IPointBase3D
    {
        IPointBase3D RefPoint1 { get;}
        IPointBase3D RefPoint2 { get;}
        bool Orientation { get; set; }

        void SetRefPoint1(IPointBase3D iRefPoint);
        void SetRefPoint2(IPointBase3D iRefPoint);
        void SetRefPoints(IPointBase3D iRefPoint1, IPointBase3D iRefPoint2);
        void SetRatio(double iRatio);
        double GetRatio();
    }
}
