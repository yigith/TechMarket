namespace ApplicationCore.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductPictureUri { get; set; }
    }
}