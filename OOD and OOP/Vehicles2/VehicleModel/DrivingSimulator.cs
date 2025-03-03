namespace VehicleModel;

public class DrivingSimulator
{
    public void SimulateJourney(Vehicle vehicle, List<(double Distance, RoadType Road)> segments)
    {
        Console.WriteLine();
        Console.WriteLine($"Starting with {vehicle.Type}:");

        double totalTime = 0;
        double totalFuel = 0;

        foreach (var (distance, road) in segments)
        {
            double time = vehicle.CalculateTime(distance, road);
            totalTime += time;

            Console.WriteLine($" - Drove {distance} km on {road}. Time: {time:F2} hrs.");

            if (vehicle is MotorizedVehicle motorizedVehicle)
            {
                double consumption = motorizedVehicle.Drive(distance, road);
                totalFuel += consumption;

                Console.WriteLine($"Fuel consumed: {consumption:F2} liters.");
            }
        }

        Console.WriteLine($"Total journey time: {totalTime:F2} hours.");
        if (vehicle is MotorizedVehicle)
            Console.WriteLine($"Total fuel consumed: {totalFuel:F2} liters.");
    }
}
