using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.DTOs;
using Muflone.Messages.Commands;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public class CreatePurchaseOrder : Command
{
	public SupplierId SupplierId { get; }
	public DateTime Date { get; }
	public IEnumerable<OrderLine> Lines { get; }

	public CreatePurchaseOrder(PurchaseOrderId aggregateId, SupplierId supplierId, DateTime date, IEnumerable<OrderLine> lines) :
		base(aggregateId)
	{
		SupplierId = supplierId;
		Date = date;
		Lines = lines;
	}
}