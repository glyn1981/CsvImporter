using CsvImporter.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CsvImporter.Test
{
    /// <summary>
    /// Tests for the database operations.
    /// </summary>
    public class DatabaseTests
    {

        /// <summary>
        /// Tests that adding one vehicle to the database results in the database containing one vehicle.
        /// </summary>
        [Fact]
        public void TestAddingOneVehicle_DBShouldContainOneVehicle()
        {
            // Create dependencies
            IDbHandler dbHandler = new DbHandler();
            List<Vehicle> vehicleList = new List<Vehicle>();

          
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Color = "red", Make = "Audi", Model = "S3", Reg = "S3 4ME" }
            };
            // Use the helper to create mocks and get the vehicle list
            MockSet mockSet = CreateMocks(vehicleList);

            if(mockSet.ContextMock == null )
            {
                throw new InvalidOperationException("Mocks were not created correctly.");
            }

            VEHICLESContext context = mockSet.ContextMock.Object;
            dbHandler.SaveVehicles(vehicles, context);
            Assert.Equal(context.Vehicles.Count(), vehicles.Count());
            Assert.Equal(vehicles, vehicleList, new VehicleComparer());

        }

        /// <summary>
        /// Tests that adding two vehicles to the database results in the database containing two vehicles.
        /// </summary>
        [Fact]
        public void TestAddingTwoVehicles_DBShouldContainTwoVehicles()
        {
            // Create dependencies
            IDbHandler dbHandler = new DbHandler();
            List<Vehicle> vehicleList = new List<Vehicle>();

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Color = "red", Make = "Audi", Model = "S3", Reg = "S3 4ME" },
                new Vehicle { Id = 1, Color = "white", Make = "BMW", Model = "M5", Reg = "M5 4ME" }
            };

            // Use the helper to create mocks and get the vehicle list
            MockSet mockSet = CreateMocks(vehicleList);

            if (mockSet.ContextMock == null)
            {
                throw new InvalidOperationException("Mocks were not created correctly.");
            }

            VEHICLESContext context = mockSet.ContextMock.Object;
            dbHandler.SaveVehicles(vehicles, context);
            Assert.Equal(context.Vehicles.Count(), vehicles.Count());
            Assert.Equal(vehicles, vehicleList, new VehicleComparer());

        }

        /// <summary>
        /// tests that adding no vehicles to the database results in the database containing no vehicles.
        /// </summary>
        [Fact]
        public void TestAddingNoVehicles_DBShouldContainNoVehicles()
        {
            //reate dependencies
            IDbHandler dbHandler = new DbHandler();
            List<Vehicle> vehicleList = new List<Vehicle>();


            // use the helper to create mocks and get the vehicle list
            MockSet mockSet = CreateMocks(vehicleList);

            if (mockSet.ContextMock == null)
            {
                throw new InvalidOperationException("Mocks were not created correctly.");
            }

            VEHICLESContext context = mockSet.ContextMock.Object;
            dbHandler.SaveVehicles(vehicleList, context);
            Assert.Equal(context.Vehicles.Count(), vehicleList.Count());
            Assert.Equal(vehicleList, vehicleList, new VehicleComparer());
      

        }

        /// <summary>
        /// class to help create mock sets for the DbSet of Vehicles and the VEHICLESContext.
        /// </summary>
        public class MockSet
        {
            public Mock<DbSet<Vehicle>>? VehicleMock;
            public Mock<VEHICLESContext>? ContextMock;
            public List<Vehicle>? VehicleList;
        }

        /// <summary>
        /// helps create the mock set for the DbSet of Vehicles and the VEHICLESContext.
        /// </summary>
        /// <param name="vehicleList"></param>
        /// <returns></returns>
        private MockSet CreateMocks(List<Vehicle> vehicleList)
        {
            var mockSet = new Mock<DbSet<Vehicle>>();
            var queryable = vehicleList.AsQueryable();

            // setup the mock DbSet to behave like a queryable collection
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Vehicle>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            mockSet.Setup(m => m.Add(It.IsAny<Vehicle>())).Callback<Vehicle>(v => vehicleList.Add(v));

            // setup the mock DbSet to return the list of vehicles
            var mockContext = new Mock<VEHICLESContext>();
            mockContext.Setup(c => c.Vehicles).Returns(mockSet.Object);

            return new MockSet() { VehicleMock = mockSet, ContextMock = mockContext, VehicleList = vehicleList };
        }
    }
}