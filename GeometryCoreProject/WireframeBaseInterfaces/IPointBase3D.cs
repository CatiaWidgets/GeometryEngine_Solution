using GeometryCoreProject.AbstractClasses;

namespace GeometryCoreProject.WireframeBaseInterfaces
{
    public interface IPointBase3D : IGeometryBase
    {
        double X { get; }
        double Y { get; }
        double Z { get; }

        IPointBase3D TranslatePointAlongVector(IPointBase3D iRefPoint, IVectorBase3D iRefVector, double iOffset);

        void SetCoordinates(double[] iCoordinates);
        double[] GetCoordinates();
    }
}
