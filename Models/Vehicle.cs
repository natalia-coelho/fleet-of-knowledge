namespace Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public string LicensePlate { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Kilometer { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Active,
    Inactive
}