﻿namespace Data;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string MoviesCollectionName { get; set; } = null!;
    public string VehiclesCollectionName { get; set; } = null!;
}
