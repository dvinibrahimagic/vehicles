using VehicleModel;
class Program
{
    static void Main()
    {
        Console.WriteLine("3 Scenarios, Different Vehicles under Different Conditions");
        Console.WriteLine();
        
        var car = new PassengerVehicle("CAR-123", EnergySource.Gasoline, 80, 6.0, 50);
        var truck = new MaterialVehicle("TRUCK-567", EnergySource.Diesel, 60, 8.0, 100);
        var bike = new Bicycle("BIKE-001", 25);

        var gasStation = new GasStation("Shell", new List<EnergySource> { EnergySource.Gasoline, EnergySource.Diesel });

        var drivingSimulator = new DrivingSimulator();

        Console.WriteLine("Scenario 1: Passenger Car Commute");
        drivingSimulator.SimulateJourney(car, new List<(double, RoadType)>
        {
            (20, RoadType.City),
            (50, RoadType.Highway)
        });

        gasStation.Refuel(car, 10);

        Console.WriteLine();
        Console.WriteLine("Scenario 2: Short Bicycle Ride");
        drivingSimulator.SimulateJourney(bike, new List<(double, RoadType)>
        {
            (3, RoadType.City)
        });

        Console.WriteLine();
        Console.WriteLine("Scenario 3: Truck Delivery Route");
        drivingSimulator.SimulateJourney(truck, new List<(double, RoadType)>
        {
            (10, RoadType.City),
            (30, RoadType.Highway),
            (20, RoadType.Backroad)
        });

        gasStation.Refuel(truck, 20);
        Console.Read();
    }
}