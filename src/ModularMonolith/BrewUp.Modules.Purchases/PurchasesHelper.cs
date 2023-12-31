﻿using BrewUp.Modules.Purchases.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Purchases;

public static class PurchasesHelper
{
	public static IServiceCollection AddPurchases(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();
		services.AddValidatorsFromAssemblyContaining<OrderValidator>();
		services.AddSingleton<ValidationHandler>();
		services.AddScoped<IPurchasesOrchestrator, PurchasesOrchestrator>();

		return services;
	}
}