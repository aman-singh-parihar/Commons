namespace BMS
{
    public class ShowSeat
    {
        public int Id { get; set; }
        public Show Show { get; set; }
        public Seat Seat { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }

}
