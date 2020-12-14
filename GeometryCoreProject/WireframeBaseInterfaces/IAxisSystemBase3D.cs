namespace GeometryCoreProject.WireframeBaseInterfaces
{
    public interface IAxisSystemBase3D
    {
        IPointBase3D Origin { get; set; }
        IVectorBase3D XAxis { get; set; }
        IVectorBase3D YAxis { get; set; }
        IVectorBase3D ZAxis { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}
