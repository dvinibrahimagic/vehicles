# VEHICLES

## RULES 
#### Transportation Surfaces
- City Roads: 1.2 consumption, 0.6 speed.
 
- Highways:   0.8 consumption, 1.2 speed.
 
- Backroads:  1.1 consumption, 0.9 speed.
 
- Offroad:    1.5 consumption, 0.5 speed.

 __

 #### Power Methods
- Electric

- Gas-powered

- Unpowered

__

#### Common Properties:
- `licensePlate`: Unique identifier for the vehicle
- `type`: Type of vehicle (Passenger/Material Transport)
- `energySource`: Fuel or electricity source
- `speed`: Base speed of the vehicle
- `consumption`: Base energy consumption rate
- `surfaceMultiplier`: Modifiers for different driving surfaces

__

#### Actions:
- `transportPassengers(count)`: Ensures the vehicle can accommodate passengers
- `startEngine()`: Initiates movement based on propulsion type
  
- `calculateConsumption(distance, condition)`: Calculates energy consumption
- `calculateTime(distance, condition)`: Calculates travel time
- `refuel()`: Restores energy source (if available)
___

## THINGS

### Vehicle Types
- Car
 
- Sports Car
 
- Truck
 
- Bus
 
- Bicycle
 
 __

#### Electric Vehicles
- Electric Car
 
- Electric Truck

 #### Gas-powered Vehicles
- Car
 
- Truck
 
- Motorcycle

 #### Unpowered Vehicles
- Bicycle

 ___
