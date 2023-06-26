namespace BrewUp.Modules.Purchases.ReadModel.Entities
{
	public class LastEventPosition : EntityBase
	{
		public long CommitPosition { get; set; }
		public long PreparePosition { get; set; }
	}
}
