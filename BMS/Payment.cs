namespace BMS
{
    public class Payment
    {
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
