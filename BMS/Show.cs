namespace BMS
{
    public class Show
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Screen Screen { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }
    }

}
