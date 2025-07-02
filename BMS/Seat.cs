namespace BMS
{
    public class Seat
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; } // e.g., "A1", "B2"
        public SeatType SeatType { get; set; }
    }
}
