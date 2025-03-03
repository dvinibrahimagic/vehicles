namespace VehicleModel;

public abstract class MotorizedVehicle : Vehicle
{
    public EnergySource EnergySource { get; }
    public double BaseSpeed { get; }
    public double BaseConsumption { get; }
    public double FuelCapacity { get; }
    public double CurrentFuel { get; private set; }

    protected MotorizedVehicle(string licensePlate, string type, EnergySource energySource, double baseSpeed, double baseConsumption, double fuelCapacity)
        : base(licensePlate, type)
    {
        EnergySource = energySource;
        BaseSpeed = baseSpeed;
        BaseConsumption = baseConsumption;
        FuelCapacity = fuelCapacity;
        CurrentFuel = fuelCapacity; // starts full
    }


    /// <summary>
    /// Drives the vehicle a certain distance, reducing fuel accordingly.
    /// </summary>
    /// <param name="distance">Distance to drive</param>
    /// <param name="roadType">Type of road</param>
    /// <returns>Time taken to drive; -1 if fuel is insufficient</returns>
    public double Drive(double distance, RoadType roadType)
    {
        double fuelNeeded = CalculateConsumption(distance, roadType);
        if (fuelNeeded > CurrentFuel)
        {
            return -1; // not enough fuel, insufficient
        }
        CurrentFuel -= fuelNeeded; // removes used up fuel from drive from current fuel tracker
        return CalculateTime(distance, roadType); // return time in minutes
    }

    /// <summary>
    /// Calculates the consumption needed for given distance and roadtype.
    /// </summary>
    /// <param name="distance">Distance to drive </param>
    /// <param name="roadType">Type of road</param>
    /// <returns>Fuel needed for distance and roadtype </returns>
    public double CalculateConsumption(double distance, RoadType roadType)
    {
        
        double multiplier = GetConsumptionMultiplier(roadType);
        
        // | dis. = 10 km | baseCon. = 8.0 | consMulti =  1.2 (city) / 100 = 0.96 L
        // 10 km * (8.0 * 1.2) / 100 = 2.16 L
        return (distance / 100) * (BaseConsumption * multiplier); 
    }
    
    /// <summary>
    /// Calculates speed for given distance and roadtype.
    /// </summary>
    /// <param name="distance">Distance to drive </param>
    /// <param name="roadType">Type of road</param>
    /// <returns>Time needed for distance and roadtype </returns>
    public override double CalculateTime(double distance, RoadType roadType)
    {
        double speed = BaseSpeed * GetSpeedMultiplier(roadType);
        return distance / speed;    // s = v * t ===> t = s / v
    }

    private double GetSpeedMultiplier(RoadType roadType) => roadType switch
    {
        RoadType.City => 0.6,
        RoadType.Highway => 1.2,
        RoadType.Backroad => 0.9,
        RoadType.Offroad => 0.5
    };

    private double GetConsumptionMultiplier(RoadType roadType) => roadType switch
    {
        RoadType.City => 1.2,
        RoadType.Highway => 0.8,
        RoadType.Backroad => 1.1,
        RoadType.Offroad => 1.5
    };

    public void Refuel(double amount)
    {
        CurrentFuel = Math.Min(FuelCapacity, CurrentFuel + amount);
    }
}