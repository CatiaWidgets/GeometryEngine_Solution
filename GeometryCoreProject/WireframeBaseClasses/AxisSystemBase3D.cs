using GeometryCoreProject.AbstractClasses;
using GeometryCoreProject.WireframeBaseInterfaces;

namespace GeometryCoreProject.WireframeBaseClasses
{
    public class AxisSystemBase3D : GeometryBase, IAxisSystemBase3D
    {
        public IPointBase3D Origin { get; set; }
        public IVectorBase3D XAxis { get; set; }
        public IVectorBase3D YAxis { get; set; }
        public IVectorBase3D ZAxis { get; set; }

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
