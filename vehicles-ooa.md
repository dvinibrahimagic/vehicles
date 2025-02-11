

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

![alt text](https://github.com/dvinibrahimagic/vehicles-ooa/blob/main/Bild_2025-02-11_121754474.png)
__

### Gas Station

#### Fuel Types

##### Diesel
- High energy density, efficient for long distances
- Common in trucks, buses, and some cars
- Produces more NOx and particulate matter
- Generally more fuel-efficient than gasoline
- Requires exhaust treatment (e.g., DPF, SCR)


##### Benzin (Gasoline)
- Widely used in passenger cars
- Higher CO₂ emissions per liter than diesel
- Quick refueling time
- Less fuel-efficient than diesel
- Produces fewer particulates but more CO₂

##### Electricity
- Zero emissions at the point of use
- Powered by batteries (Li-ion most common)
- Charging infrastructure still developing
- Lower running costs but higher initial price
- Energy efficiency is higher than combustion engines

##### Hydrogen
- Zero emissions, only water vapor as a byproduct
- Used in fuel cell vehicles (FCVs)
- High energy density but challenging storage
- Refueling time similar to gasoline/diesel
- Requires dedicated infrastructure and green production for sustainability

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

