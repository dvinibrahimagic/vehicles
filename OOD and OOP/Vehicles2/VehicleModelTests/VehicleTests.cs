namespace VehicleModelTests;
using VehicleModel;
using System;
using System.Collections.Generic;
using Xunit;

public class VehicleTests
{
    [Fact]
    public void PassengerVehicle_CalculatesTimeCorrectly()
    {
        var car = new PassengerVehicle("CAR-123", EnergySource.Gasoline, 80, 6.0, 50);
        double time = car.CalculateTime(100, RoadType.Highway); // 100 km on Highway
        Assert.Equal(1.14, time, 2); // highway has 1.1x speed multi
    }

    [Fact]
    public void MaterialVehicle_CalculatesConsumptionCorrectly()
    {
        var truck = new MaterialVehicle("TRUCK-567", EnergySource.Diesel, 60, 8.0, 100);
        double fuelUsed = truck.Drive(50, RoadType.Offroad);
        Assert.Equal(6.0, fuelUsed, 2); // 8.0 * 1.5 (Offroad multi) * 50/100
    }

    [Fact]
    public void Bicycle_CalculatesTimeCorrectly()
    {
        var bike = new Bicycle("BIKE-001", 25);
        double time = bike.CalculateTime(10, RoadType.City);
        Assert.Equal(0.4, time, 2); // 10 km / 25 km/h
    }

    [Fact]
    public void GasStation_RefuelsVehicleCorrectly()
    {
        var car = new PassengerVehicle("CAR-123", EnergySource.Gasoline, 80, 6.0, 50);
        var gasStation = new GasStation("Shell", new List<EnergySource> { EnergySource.Gasoline, EnergySource.Diesel });

        car.Refuel(-40); // simulate fuel usage
        gasStation.Refuel(car, 20);
        
        Assert.Equal(30, car.CurrentFuel); // fuel should be 30 AFTER refueling
    }

    [Fact]
    public void GasStation_DoesNotRefuelWrongFuelType()
    {
        var car = new PassengerVehicle("CAR-123", EnergySource.Gasoline, 80, 6.0, 50);
        var electricStation = new GasStation("EV Charge", new List<EnergySource> { EnergySource.Electric });

        electricStation.Refuel(car, 10);
        
        Assert.Equal(50, car.CurrentFuel); // should remain the same (gas not availabe)
    }

    [Fact]
    public void DrivingSimulator_HandlesMotorizedVehicleCorrectly()
    {
        var drivingSimulator = new DrivingSimulator();
        var truck = new MaterialVehicle("TRUCK-567", EnergySource.Diesel, 60, 8.0, 100);

        var segments = new List<(double, RoadType)>
        {
            (10, RoadType.City),
            (30, RoadType.Highway)
        };

        drivingSimulator.SimulateJourney(truck, segments);

        // expected total consumption:
        // City: 10 km * (8.0 * 1.2) / 100 = 0.96 L
        // Highway: 30 km * (8.0 * 0.9) / 100 = 2.16 L
        // total = 3.12 L
        double expectedConsumption = 3.12;
        double actualConsumption = truck.Drive(10, RoadType.City) + truck.Drive(30, RoadType.Highway);

        Assert.Equal(expectedConsumption, actualConsumption, 2);
    }
}
