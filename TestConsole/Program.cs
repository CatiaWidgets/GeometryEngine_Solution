using GeometryCoreProject.WireframeBaseClasses;
using GeometryCoreProject.WireframeBaseInterfaces;
using GeometryFactoriesProject.FactoryBaseClasses;
using GeometryTypesProject.GeometryTypesInterfaces;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create an Instance of the Factory
            WireframeFactory WireframeFactory = new WireframeFactory();

            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = WireframeFactory.AddNewPointCoord(10,10,10);

            // Create ReferencePoint
            IPointByCoordinates RefPointByCoordinates = WireframeFactory.AddNewPointCoord(20, 20, 20);

            //Set the ReferencePoint
            PointByCoordinates.AddRefPoint(RefPointByCoordinates);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12, 23, 34 });

            // Remove Reference Point
            PointByCoordinates.RemoveRefPoint();

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 10, 10, 10 });

            // Create ReferenceAxisSystem
            IAxisSystemBase3D RefAxisSystem = new AxisSystemBase3D();
            RefAxisSystem.Origin = WireframeFactory.AddNewPointCoord(20, 20, 20);
            RefAxisSystem.XAxis = new VectorBase3D(0.707106781, 0.707106781, 0);
            RefAxisSystem.YAxis = new VectorBase3D(-0.707106781, 0.707106781, 0);
            RefAxisSystem.ZAxis = new VectorBase3D(0, 0, 1);

            // Set the ReferenceAxisSystem
            PointByCoordinates.AddRefAxisSystem(RefAxisSystem);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12, 23, 34 });

            try
            {
                //Set the ReferencePoint
                PointByCoordinates.AddRefPoint(RefPointByCoordinates);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

            // Remove the Referene AxisSystem
            PointByCoordinates.RemoveRefAxisSystem();

            //Set the ReferencePoint
            PointByCoordinates.AddRefPoint(RefPointByCoordinates);

            try
            {
                // Set the ReferenceAxisSystem
                PointByCoordinates.AddRefAxisSystem(RefAxisSystem);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
