using GeometryCoreProject.WireframeBaseInterfaces;
using GeometryFactoriesProject.FactoryBaseInterfaces;
using GeometryTypesProject.GeometryTypesClasses;
using GeometryTypesProject.GeometryTypesInterfaces;

namespace GeometryFactoriesProject.FactoryBaseClasses
{
    public class WireframeFactory : IWireframeFactory
    {
        public WireframeFactory()
        {

        }

        public IPointByCoordinates AddNewPointCoord(double iX, double iY, double iZ)
        {
            return new PointByCoordinates(iX,iY,iZ);
        }
        public IPointByCoordinates AddNewPointCoordWithReference(double iX, double iY, double iZ, IPointBase3D iRefPoint = null, IAxisSystemBase3D iRefAxisSystem = null)
        {
            if(iRefPoint == null && iRefAxisSystem ==null)
            {
                return new PointByCoordinates(iX, iY, iZ);
            }
            else
            {
                if (iRefPoint == null)
                {
                    return new PointByCoordinates(iX, iY, iZ, iRefAxisSystem);
                }
                else if (iRefAxisSystem == null)
                {
                    return new PointByCoordinates(iX, iY, iZ, iRefPoint);
                }
                else
                {
                    return new PointByCoordinates(iX, iY, iZ, iRefPoint, iRefAxisSystem);
                }
            }
        }
    }
}
