using System;

public class TemperatureSensor
{
    public delegate void TemperatureChangeHandler(int newTemperature);

    public event TemperatureChangeHandler TemperatureChanged;

    private int currentTemperature;

    public void UpdateTemperature(int newTemperature)
    {
        if (newTemperature != currentTemperature)
        {
            currentTemperature = newTemperature;

            TemperatureChanged?.Invoke(newTemperature);
        }
    }
}

public class TemperatureDisplay
{
    public void HandleTemperatureChange(int newTemperature)
    {
        Console.WriteLine($"Temperature changed to {newTemperature}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureSensor sensor = new TemperatureSensor();
        TemperatureDisplay display = new TemperatureDisplay();

        sensor.TemperatureChanged += display.HandleTemperatureChange;

        sensor.UpdateTemperature(10);
        sensor.UpdateTemperature(25);
        sensor.UpdateTemperature(30);
    }
}