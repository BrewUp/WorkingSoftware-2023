﻿namespace BrewUp.Modules.Purchases.Infrastructure.MongoDb;

public class PurchasesMongoDbSettings
{
	public string ConnectionString { get; set; } = string.Empty;
	public string DatabaseName { get; set; } = string.Empty;
}