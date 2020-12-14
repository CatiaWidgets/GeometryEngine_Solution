using GeometryCoreProject.WireframeBaseInterfaces;
using GeometryTypesProject.GeometryTypesInterfaces;

namespace GeometryFactoriesProject.FactoryBaseInterfaces
{
    public interface IWireframeFactory
    {
        IPointByCoordinates AddNewPointCoord(double iX, double iY, double iZ);
        IPointByCoordinates AddNewPointCoordWithReference(double iX, double iY, double iZ, IPointBase3D iRefPoint = null, IAxisSystemBase3D iRefAxisSystem = null);
    }
}
