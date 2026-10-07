namespace FLORES_Midterm_Store.Models

{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

}