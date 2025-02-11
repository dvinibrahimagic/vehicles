

# VEHICLES

## RULES 
#### Transportation Surfaces
- City Roads: 1.2 consumption, 0.6 speed.
 
- Highways:   0.8 consumption, 1.2 speed.
 
- Backroads:  1.1 consumption, 0.9 speed.
 
- Offroad:    1.5 consumption, 0.5 speed.

 __

 #### Energy Sources
- Electric

- Gas-powered

- Unpowered (i.e. Bicycles)

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
- Car - personal transportation machine
 
- Sports Car - more powerful and expensive version of a car
 
- Truck - transport loads of shipments, bigger and longer than a car
 
- Bus - to commercially transport people from a to b
 
- Bicycle - cheap alternative, requires no fuel, small.
 
 __

#### Electric Vehicles
- Electric Car - electric fueled car
 
- Electric Truck

 #### Gas-powered Vehicles
- Car
 
- Truck
 
- Motorcycle

 #### Unpowered Vehicles
- Bicycle

__

### Gas Station
![alt text](https://github.com/dvinibrahimagic/vehicles-ooa/blob/main/Bild_2025-02-11_121754474.png)
#### Fuel Types
- Diesel
- Benzin
- Electricity
- Hydrogen
- Food (Bicycle)

#### Properties
- `availableGasPumps`: Useable gas pumps in gas station
- `availableElectricitiyPumps`:  Available useable energy sources for electric cars
___


![alt text](https://github.com/dvinibrahimagic/vehicles-ooa/blob/main/Screenshot%202025-02-11%20101427.png?raw=true)

___

 ## Object-Responsibility-Collaboration (CRC)
| Class | Responsibility | Collaborations |
|--------|--------------|---------------|
| Vehicle | General properties, movement | EnergySource, DrivingCondition |
| Passenger Vehicle | Transporting people | Vehicle |
| Material Transport Vehicle | Transporting goods | Vehicle |
| Energy Source | Providing fuel/electricity | Vehicle |
| Driving Condition | Affecting vehicle performance | Vehicle |

