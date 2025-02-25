namespace VehicleModel;

public abstract class MotorizedVehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double FuelLevel { get; private set; }

    public MotorizedVehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    /// <summary>
    /// Calculates the time it takes to drive a certain distance on a certain road type.
    /// Updates the FuelLevel.
    /// </summary>
    /// <param name="distance">distance to drive in km</param>
    /// <param name="roadType">kind of road that is driven</param>
    /// <returns>travel time in minutes; or -1 if FuelLevel is too low</returns>
    public abstract double Drive(double distance, RoadType roadType);
}