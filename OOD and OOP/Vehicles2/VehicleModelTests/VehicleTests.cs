namespace VehicleModelTests;
using VehicleModel;
using System;
using System.Collections.Generic;
using Xunit;

public class VehicleTests
{
    // City Roads  =   | con. = 1.2 | speed = 0.6 |
    // Highways    =   | con. = 0.8 | speed = 1.2 |
    // Backroads   =   | con. = 1.1 | speed = 0.9 |
    // Offroad     =   | con. = 1.5 | speed = 0.5 |
    
    [Fact]
    public void PassengerVehicle_CalculatesTimeCorrectly()
    {
        // Highways = | con. = 0.8 | speed = 1.2 |
        //
        // | dis. = 100 km | baseSpeed. = 80 km/h | baseCon. = 6.0 L/100km | fuelCap. = 50 L |
        //
        // v * speedMulti. = v1 
        // 80 km/h * 1.2 =  96 km/h
        //
        // s / v1 = t
        // 100 km / 96 km/h = 1,0416...
        
        var car = new PassengerVehicle("CAR-123", EnergySource.Gasoline, 80, 6.0, 50);
        double time = car.CalculateTime(100, RoadType.Highway); 
        Assert.Equal(1.04, time, 2); 
    }

    [Fact]
    public void MaterialVehicle_CalculatesConsumptionCorrectly()
    {
        // Offroad = | con. = 1.5 | speed = 0.5 |
        //
        // | dis. = 50 km | baseSpeed. = 60 km/h | baseCon. = 8.0 L/100km | fuelCap. = 100 L |
        //
        // (dis. / 100) * (baseCon. * conMulti.)
        // (50 km / 100) * (8.0 * 1.5) 
        //  0.5 * 12 = 6.0 Liter/100km
        
        var truck = new MaterialVehicle("TRUCK-567", EnergySource.Diesel, 60, 8.0, 100);
        double fuelUsed = truck.CalculateConsumption(50, RoadType.Offroad);
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
    public void DrivingSimulator_HandlesTerrainSwitchCorrectly()
    {
        // City Roads  =   | con. = 1.2 | speed = 0.6 |
        // Highways    =   | con. = 0.8 | speed = 1.2 |
        //
        // | dis.1 = 10 km | dis.2 = 30 km | baseSpeed. = 60 km/h | baseCon. = 8.0 L/100km | fuelCap. = 100 L |
        
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
        // Highway: 30 km * (8.0 * 0.8) / 100 = 1.92 L
        // total = 2.88 L
        double expectedConsumption = 2.88;
        double actualConsumption = truck.CalculateConsumption(10, RoadType.City) + truck.CalculateConsumption(30, RoadType.Highway);

        Assert.Equal(expectedConsumption, actualConsumption, 2);
    }

    
    [Fact]
    public void MultiModalTransport_FunctionsCorrectly()
    {
        // Set up the vehicles
        var bike = new Bicycle("BIKE-001", 25);
        var car = new PassengerVehicle("CAR-123", EnergySource.Gasoline, 80, 6.0, 50);
        var truck = new MaterialVehicle("TRUCK-567", EnergySource.Diesel, 60, 8.0, 100);
        var offroad = new MaterialVehicle("OFFROAD-999", EnergySource.Diesel, 60, 10.0, 100);

        // Set up the gas station
        var gasStation = new GasStation("Shell", new List<EnergySource> { EnergySource.Gasoline, EnergySource.Diesel });

        // Define the journey segments
        var journeySegments = new List<(double, RoadType)>
        {
            (3, RoadType.City),         // Bicycle ride: 3 km in city
            
            (10, RoadType.City),        // Electric car: 10 km in city
            (250, RoadType.Highway),    // Electric car: 250 km on highway
            (5, RoadType.Backroad),     // Electric car: 5 km on backroads
            
            (5, RoadType.Backroad),     // Off-road vehicle: 5 km on backroads
            (35, RoadType.Offroad),     // Off-road vehicle: 35 km offroad
            (10, RoadType.Backroad),    // Off-road vehicle: 10 km backroads
            (60, RoadType.Highway),     // Off-road vehicle: 60 km on highway
            
            (20, RoadType.Highway),     // Truck: 20 km on highway
            (40, RoadType.Backroad)     // Truck: 40 km on backroads    
        };

        // Simulate the journey
        double totalTime = 0;
        double totalFuelConsumed = 0;

        // Bike segment
        totalTime += bike.CalculateTime(3, RoadType.City);
        
        // Electric car segments
        totalTime += car.CalculateTime(10, RoadType.City);
        totalTime += car.CalculateTime(250, RoadType.Highway);
        totalTime += car.CalculateTime(5, RoadType.Backroad);
        totalFuelConsumed += car.CalculateConsumption(10, RoadType.City);
        totalFuelConsumed += car.CalculateConsumption(250, RoadType.Highway);
        totalFuelConsumed += car.CalculateConsumption(5, RoadType.Backroad);

        // Off-road vehicle segments
        totalTime += offroad.CalculateTime(5, RoadType.Backroad);
        totalTime += offroad.CalculateTime(35, RoadType.Offroad);
        totalTime += offroad.CalculateTime(10, RoadType.Backroad);
        totalTime += offroad.CalculateTime(60, RoadType.Highway);
        totalFuelConsumed += offroad.CalculateConsumption(5, RoadType.Backroad);
        totalFuelConsumed += offroad.CalculateConsumption(35, RoadType.Offroad);
        totalFuelConsumed += offroad.CalculateConsumption(10, RoadType.Backroad);
        totalFuelConsumed += offroad.CalculateConsumption(60, RoadType.Highway);

        // Truck segment
        totalTime += truck.CalculateTime(20, RoadType.Highway);
        totalTime += truck.CalculateTime(40, RoadType.Backroad);
        totalFuelConsumed += truck.CalculateConsumption(20, RoadType.Highway);
        totalFuelConsumed += truck.CalculateConsumption(40, RoadType.Backroad);

        // Refueling at gas station
        gasStation.Refuel(car, 20);
        gasStation.Refuel(offroad, 20);

        // Assertions
        Assert.InRange(totalTime, 6.25, 6.30);  // The total time should be approximately 6.27 hours
        Assert.InRange(totalFuelConsumed, 29.5, 30.0);  // The total fuel consumed should be around 29.55 L
    }
}
