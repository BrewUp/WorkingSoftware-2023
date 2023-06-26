using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.DTOs;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.Messages.Events;

public sealed class PurchaseOrderCreated : DomainEvent
{
	public SupplierId SupplierId { get; }
	public DateTime Date { get; }
	public IEnumerable<OrderLine> Lines { get; }

	public PurchaseOrderCreated(PurchaseOrderId aggregateId, SupplierId supplierId, DateTime date, IEnumerable<OrderLine> lines) :
		base(aggregateId)
	{
		SupplierId = supplierId;
		Date = date;
		Lines = lines;
	}
}