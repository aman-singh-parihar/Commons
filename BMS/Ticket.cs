namespace BMS
{
    public class Ticket
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Show Show { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseTime { get; set; }
    }

}
