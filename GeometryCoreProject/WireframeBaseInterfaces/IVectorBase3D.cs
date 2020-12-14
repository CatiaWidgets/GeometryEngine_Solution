
namespace GeometryCoreProject.WireframeBaseInterfaces
{
    public interface IVectorBase3D
    {
        double I { get; set; }
        double J { get; set; }
        double K { get; set; }

        double Magnitude { get; }
        IVectorBase3D UnitVector { get; }
        IVectorBase3D InverseVector { get; }

        bool Equals(object obj);
        int GetHashCode();
    }
}
