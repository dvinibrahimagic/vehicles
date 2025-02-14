

# VEHICLES

## RULES 

#### Transportation Surface

| Surface           | Speed Multiplier | Consumption Multiplier | Notes |
|-------------------|------------------|------------------------|-------|
| City Roads        | 0.6              | 1.2                    | Default state |
| Highways          | 1.2              | 0.8                    | Minor slowdowns |
| Backroads         | 0.9              | 1.1                    | Frequent stops, higher consumption |
| Offroad           | 0.5              | 1.5                    | No movement possible |

___

![alt text](https://github.com/dvinibrahimagic/vehicles-ooa/blob/main/Bild_2025-02-11_121754474.png)

___

### Traffic Conditions

| Traffic Condition | Speed Multiplier | Consumption Multiplier | Notes |
|-------------------|------------------|------------------------|-------|
| No Traffic        | 1.0              | 1.0                    | Default state |
| Light Traffic     | 0.8              | 1.1                    | Minor slowdowns |
| Heavy Traffic     | 0.5              | 1.2                    | Frequent stops, higher consumption |
| Road Block        | 0.0              | 1.0                    | No movement possible |

___

#### Energy Sources
- Electric

- Gas-powered

- Unpowered (i.e. Bicycles)

___

#### Common Properties:
- `licensePlate`: Unique identifier for the vehicle
- `type`: Type of vehicle (Passenger/Material Transport)
- `energySource`: Fuel or electricity source
- `speed`: Base speed of the vehicle, changes based on modifiers
- `consumption`: Base energy consumption rate
- `surfaceMultiplier`: Modifiers for different driving surfaces
- `trafficMultiplier`: Modifiers for different traffic conditions
- `distanceTravelled`: Holds value for how many km the vehicle has travelled

___

#### Actions:
- `startEngine()`: Turns the engine on, making it possible to drive the vehicle, also consumes fuel but significantly less than `drive()`
- `drive()`: Moves vehicle only if `isDriveable()` is `True`, adds respective amount to distanceTraveled based on all active multipliers & consumes fuel
- `isDriveable()`: Checks if engine is on
- `stopEngine()`: Turns the engine off, making it no longer possible to drive the vehicle
___
- `transportPassengers(count)`: Ensures the vehicle can accommodate passengers
- `calculateConsumption(distance, condition)`: Calculates energy consumption
- `calculateTime(distance, condition)`: Calculates travel time
- `refuel()`: Restores energy source (if available)
  
___

___

## THINGS

### Vehicle Types
- Car - personal transportation machine (an example of a passenger vehicle)
 
- Sports Car - more powerful and expensive version of a car
 
- Truck - transport loads of shipments, bigger and longer than a car (an example of a material transport vehicle)
 
- Bus - to commercially transport a lot of people from a to b
 
- Bicycle - cheap alternative, requires no fuel, small, may ignore traffic conditions
 
___

#### Electric Vehicles
- Electric Car - electric fueled car
 
- Electric Truck

 #### Gas-powered Vehicles
- Car
 
- Truck
 
- Motorcycle

 #### Unpowered Vehicles
- Bicycle

___

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
- Charging infrastructure still developing, therefore less gas stations likely to offer electricity
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
## Prototype PUML-Diagram for planned OOD implementation

![alt text](https://github.com/dvinibrahimagic/vehicles-ooa/blob/main/Vehicles.png?raw=true)

___

 ## CRC Table for better visualisation
| Class                      | Responsibility                            | Collaborations |
|----------------------------|-------------------------------------------|----------------|
| Vehicle                    | General properties, movement              | EnergySource, DrivingCondition, Gas station |
| Passenger Vehicle          | Transports people                         | Vehicle |
| Material Transport Vehicle | Transports goods                          | Vehicle |
| Energy Source              | fuel/electricity                          | Vehicle |
| Driving Condition          | Affects vehicle performance               | Vehicle |
| Traffic Condition          | Works like driving condition              | Vehicle |
| Gas Station                | Place that provides said fuel/electricity | Vehicle, Energy Source |


