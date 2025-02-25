using VehicleModel;

Console.WriteLine("Hello, World!");

Console.WriteLine("Creating a greeting for John");
var greeter = new Greeter("John");
Console.WriteLine(greeter.Greet());
Console.WriteLine($"This greeter's name ist {greeter.Name}");

Console.WriteLine("Creating a greeting for Jane");
var greeter2 = new Greeter("Jane");
Console.WriteLine(greeter2.Greet());
Console.WriteLine($"This greeter's name ist {greeter2.Name}");