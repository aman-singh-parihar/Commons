namespace BMS.Services
{
    public class TicketService
    {
        public Ticket CreateTicket(User user, Show show, List<ShowSeat> seats, decimal totalPrice)
        {
            Ticket ticket = new Ticket
            {
                User = user,
                Show = show,
                ShowSeats = new List<ShowSeat>(seats),
                TotalPrice = totalPrice,
                PurchaseTime = DateTime.Now
            };

            user.Tickets.Add(ticket);

            return ticket;
        }
    }
}
