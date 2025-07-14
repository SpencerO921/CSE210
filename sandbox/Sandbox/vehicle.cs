public class Vehicle
{
    private int _yearManufactured;
    private string _manufacturer;
    private string _modelName;

    // public Vehicle()
    // {
    //     _yearManufactured = 1975;
    //     _manufacturer = Honda
    // }

    public Vehicle(int yearManufactured, string manufacturer, string modelName)
    {
        _yearManufactured = yearManufactured;
        _manufacturer = manufacturer;
        _modelName = modelName;
    }

    public int GetYearManufactured()
    {
        return _yearManufactured;
    }
}


public class Car : Vehicle
{
    private int _numberOfDoors;
    public Car(int _yearManufactured, string manufacturer, string modelName, int numberOfDoors)
    : base(_yearManufactured, manufacturer, modelName)
    {
        _numberOfDoors = numberOfDoors;
    }
}

public class Ford : Car
{
    public Ford(int yearManufactured, string modelName, int numberOfDoors)
    : base(yearManufactured, "Ford", modelName, numberOfDoors)
    {

    }
}


public class Program2
{
    public static void Main(string[] args)
    {
        Car car1 = new Car(2006, "Hyundai", "Sonata", 4);

        Ford ford1 = new Ford(2006, "F-150", 2);
        Console.WriteLine(ford1.GetYearManufactured);
    }
}