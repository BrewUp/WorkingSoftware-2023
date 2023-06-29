using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Warehouses.SharedKernel.DomainIds;

public record BeerId(Guid Value) : DomainId(Value);