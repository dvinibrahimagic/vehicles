using VehicleModel;

namespace VehicleModelTests;

public class GreeterTests
{
    [Fact]
    public void CreateGreeter_ReturnsProperGreeting()
    {
        // Arrange
        var name = "John";
        var greeter = new Greeter(name);

        // Act
        var greeting = greeter.Greet();
        
        // Assert
        Assert.Equal(greeting, "Hello, John!");
    }

    [Fact]
    public void CreateGreeter_ReturnsNameInProperty()
    {
        // Arrange
        var name = "John";
        var greeter = new Greeter(name);

        // Act
        var nameProperty = greeter.Name;
        
        // Assert
        Assert.Equal(nameProperty, "John");
    }
}