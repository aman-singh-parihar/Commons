namespace BMS
{
    public class Screen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Theater Theater { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Show> Shows { get; set; }
    }

}
