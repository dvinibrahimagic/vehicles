using System.Diagnostics;

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

    
    // [...] <== in what unit is being returned

    /// <summary>
    /// Drives the vehicle a certain distance, reducing fuel accordingly.
    /// </summary>
    /// <param name="distance">Distance to drive</param>
    /// <param name="roadType">Type of road</param>
    /// <returns>Time taken to drive [hours]; -1 if fuel is insufficient</returns>
    public double Drive(double distance, RoadType roadType)
    {
        double fuelNeeded = CalculateConsumption(distance, roadType);
        if (fuelNeeded > CurrentFuel)
        {
            return -1; // not enough fuel, insufficient
        }
        CurrentFuel -= fuelNeeded; // removes used up fuel from drive from current fuel tracker
        return CalculateTime(distance, roadType); // return time in hours
    }

    /// <summary>
    /// Calculates the consumption needed for given distance and roadtype.
    /// </summary>
    /// <param name="distance">Distance to drive </param>
    /// <param name="roadType">Type of road</param>
    /// <returns>Fuel needed for distance and roadtype [liter/100km] </returns>
    public double CalculateConsumption(double distance, RoadType roadType)
    {
        
        double multiplier = GetConsumptionMultiplier(roadType);
        
        // | dis. = 10 km | baseCon. = 8.0 L | consMulti. =  1.2 (city)
        //
        // (10 km / 100) * (8.0 * 1.2) 
        //  0,1 * 9,6 = 0.96 Liter/100km
        return (distance / 100) * (BaseConsumption * multiplier);  
    }
    
    /// <summary>
    /// Calculates speed for given distance and roadtype.
    /// </summary>
    /// <param name="distance">Distance to drive </param>
    /// <param name="roadType">Type of road</param>
    /// <returns>Time needed for distance and roadtype [hours] </returns>
    public override double CalculateTime(double distance, RoadType roadType)
    {
        double speed = BaseSpeed * GetSpeedMultiplier(roadType);
        
        //    s = v * t, bewegungsformel ohne beschleunigng
        // => t = s / v
        return distance / speed;
    }

    private double GetSpeedMultiplier(RoadType roadType)
    {
        switch (roadType)
        {
            case RoadType.City:
                return 0.6;
            
            case RoadType.Highway:
                return 1.2;
            
            case RoadType.Backroad:
                return 0.9;
            
            case RoadType.Offroad:
                return 0.5;
        }

        return 1.0;
    }

    private double GetConsumptionMultiplier(RoadType roadType)
    {
        switch (roadType)
        {
            case RoadType.City:
                return 1.2;
            
            case RoadType.Highway:
                return 0.8;
            
            case RoadType.Backroad:
                return 1.1;
            
            case RoadType.Offroad:
                return 1.5;
        }

        return 1.0;
    }

    public void Refuel(double amount)
    {
        CurrentFuel = Math.Min(FuelCapacity, CurrentFuel + amount);
    }
}