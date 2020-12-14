using GeometryFactoriesProject.FactoryBaseClasses;
using GeometryTypesProject.GeometryTypesInterfaces;
using GeometryCoreProject.WireframeBaseInterfaces;
using GeometryCoreProject.WireframeBaseClasses;

using System;
using Xunit;
using FluentAssertions;

namespace GeometryUnitTestsProject.PointByCoordinates
{
    public class PointByCoordinatesUnitTest
    {
        // Create an Instance of the Factory
        WireframeFactory _WireframeFactory = new WireframeFactory();

        [Fact] // Create Point at 10,10,10
        public void PointByCoordinatesTest1()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(10);
            PointByCoordinates.Y.Should().Be(10);
            PointByCoordinates.Z.Should().Be(10);
        }

        [Fact] // Create Point at 10,10,10 then Update the Values to 12,23,34
        public void PointByCoordinatesTest2()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12,23,34});

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(12);
            PointByCoordinates.Y.Should().Be(23);
            PointByCoordinates.Z.Should().Be(34);
        }

        [Fact] // Create a Point at 10,10,10 then Add a Reference Point at 20,20,20
        public void PointByCoordinatesTest3()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferencePoint
            IPointByCoordinates RefPointByCoordinates = this._WireframeFactory.AddNewPointCoord(20, 20, 20);

            //Set the ReferencePoint
            PointByCoordinates.AddRefPoint(RefPointByCoordinates);

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(30);
            PointByCoordinates.Y.Should().Be(30);
            PointByCoordinates.Z.Should().Be(30);
        }

        [Fact] 
        /* Create a Point at 10,10,10 
        then Add a Reference Point at 20,20,20, 
        then Update the Values to 12,23,34*/
        public void PointByCoordinatesTest4()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferencePoint
            IPointByCoordinates RefPointByCoordinates = this._WireframeFactory.AddNewPointCoord(20, 20, 20);

            //Set the ReferencePoint
            PointByCoordinates.AddRefPoint(RefPointByCoordinates);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12, 23, 34 });

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(32);
            PointByCoordinates.Y.Should().Be(43);
            PointByCoordinates.Z.Should().Be(54);
        }

        [Fact] 
        /* Create a Point at 10,10,10 
        then Add a Reference Point at 20,20,20, 
        then Update the Values to 12,23,34, 
        then Remove the Reference Point*/
        public void PointByCoordinatesTest5()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferencePoint
            IPointByCoordinates RefPointByCoordinates = this._WireframeFactory.AddNewPointCoord(20, 20, 20);

            // Set the ReferencePoint
            PointByCoordinates.AddRefPoint(RefPointByCoordinates);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12, 23, 34 });

            // Remove Reference Point
            PointByCoordinates.RemoveRefPoint();

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(12);
            PointByCoordinates.Y.Should().Be(23);
            PointByCoordinates.Z.Should().Be(34);
        }

        [Fact]
        /* Create a Point at 10,10,10 
        then Add a Reference AxisSystem*/
        public void PointByCoordinatesTest6()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferenceAxisSystem
            IAxisSystemBase3D RefAxisSystem = new AxisSystemBase3D();
            RefAxisSystem.Origin = this._WireframeFactory.AddNewPointCoord(20, 20, 20);
            RefAxisSystem.XAxis = new VectorBase3D(0.707106, 0.707106,0);
            RefAxisSystem.YAxis = new VectorBase3D(-0.707106, 0.707106, 0);
            RefAxisSystem.ZAxis = new VectorBase3D(0, 0, 1);

            // Set the ReferenceAxisSystem
            PointByCoordinates.AddRefAxisSystem(RefAxisSystem);

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(20);
            Math.Round(PointByCoordinates.Y,3).Should().Be(34.142);
            PointByCoordinates.Z.Should().Be(30);
        }

        [Fact]
        /* Create a Point at 10,10,10 
        then Add a Reference AxisSystem
        then then Update the Values to 12,23,34*/
        public void PointByCoordinatesTest7()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferenceAxisSystem
            IAxisSystemBase3D RefAxisSystem = new AxisSystemBase3D();
            RefAxisSystem.Origin = this._WireframeFactory.AddNewPointCoord(20, 20, 20);
            RefAxisSystem.XAxis = new VectorBase3D(0.707106, 0.707106, 0);
            RefAxisSystem.YAxis = new VectorBase3D(-0.707106, 0.707106, 0);
            RefAxisSystem.ZAxis = new VectorBase3D(0, 0, 1);

            // Set the ReferenceAxisSystem
            PointByCoordinates.AddRefAxisSystem(RefAxisSystem);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12, 23, 34 });

            // Test the Point X,Y,Z Values
            Math.Round(PointByCoordinates.X,3).Should().Be(12.222);
            Math.Round(PointByCoordinates.Y, 3).Should().Be(44.749);
            PointByCoordinates.Z.Should().Be(54);
        }

        [Fact]
        /* Create a Point at 10,10,10 
        then Add a Reference AxisSystem
        then then Update the Values to 12,23,34
        then Remove the Reference AxisSystem*/
        public void PointByCoordinatesTest8()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferenceAxisSystem
            IAxisSystemBase3D RefAxisSystem = new AxisSystemBase3D();
            RefAxisSystem.Origin = this._WireframeFactory.AddNewPointCoord(20, 20, 20);
            RefAxisSystem.XAxis = new VectorBase3D(0.707106, 0.707106, 0);
            RefAxisSystem.YAxis = new VectorBase3D(-0.707106, 0.707106, 0);
            RefAxisSystem.ZAxis = new VectorBase3D(0, 0, 1);

            // Set the ReferenceAxisSystem
            PointByCoordinates.AddRefAxisSystem(RefAxisSystem);

            // Update Point Locations
            PointByCoordinates.SetCoordinates(new double[] { 12, 23, 34 });


            // Remove the Referene AxisSystem
            PointByCoordinates.RemoveRefAxisSystem();

            // Test the Point X,Y,Z Values
            PointByCoordinates.X.Should().Be(12);
            PointByCoordinates.Y.Should().Be(23);
            PointByCoordinates.Z.Should().Be(34);
        }

        [Fact]
        /* Create a Point at 10,10,10 
        then Add a Reference Point at 20,20,20
        then Add a Reference AxisSystem, to Throw Exception
         */
        public void PointByCoordinatesTest9()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferencePoint
            IPointByCoordinates RefPointByCoordinates = this._WireframeFactory.AddNewPointCoord(20, 20, 20);

            //Set the ReferencePoint
            PointByCoordinates.AddRefPoint(RefPointByCoordinates);

            // Create ReferenceAxisSystem
            IAxisSystemBase3D RefAxisSystem = new AxisSystemBase3D();
            RefAxisSystem.Origin = this._WireframeFactory.AddNewPointCoord(20, 20, 20);
            RefAxisSystem.XAxis = new VectorBase3D(0.707106, 0.707106, 0);
            RefAxisSystem.YAxis = new VectorBase3D(-0.707106, 0.707106, 0);
            RefAxisSystem.ZAxis = new VectorBase3D(0, 0, 1);

            // Set the ReferenceAxisSystem
            Action comparison = () => { PointByCoordinates.AddRefAxisSystem(RefAxisSystem); };

            comparison.Should().Throw<Exception>();
        }

        [Fact]
        /* Create a Point at 10,10,10        
        then Add a Reference AxisSystem 
        then Add a Reference Point at 20,20,20, to Throw Exception
         */
        public void PointByCoordinatesTest10()
        {
            // Create an instance of the IPointByCoordinates
            IPointByCoordinates PointByCoordinates = this._WireframeFactory.AddNewPointCoord(10, 10, 10);

            // Create ReferenceAxisSystem
            IAxisSystemBase3D RefAxisSystem = new AxisSystemBase3D();
            RefAxisSystem.Origin = this._WireframeFactory.AddNewPointCoord(20, 20, 20);
            RefAxisSystem.XAxis = new VectorBase3D(0.707106, 0.707106, 0);
            RefAxisSystem.YAxis = new VectorBase3D(-0.707106, 0.707106, 0);
            RefAxisSystem.ZAxis = new VectorBase3D(0, 0, 1);

            // Set the ReferenceAxisSystem
            PointByCoordinates.AddRefAxisSystem(RefAxisSystem);

            // Create ReferencePoint
            IPointByCoordinates RefPointByCoordinates = this._WireframeFactory.AddNewPointCoord(20, 20, 20);

            //Set the ReferencePoint
            Action comparison = () => { PointByCoordinates.AddRefPoint(RefPointByCoordinates); };

            comparison.Should().Throw<Exception>();
        }
    }
}
