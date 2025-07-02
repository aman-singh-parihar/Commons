namespace BMS.Services
{
    public class ShowSeatService
    {
        public bool AreSeatsAvailable(List<ShowSeat> seats)
        {
            return seats.All(seat => seat.IsAvailable);
        }

        public void ReserveSeats(List<ShowSeat> seats)
        {
            foreach (var seat in seats)
            {
                seat.IsAvailable = false;
            }
        }
    }
}
