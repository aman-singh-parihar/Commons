namespace BMS.Services
{
    public class BookingService
    {
        private readonly ShowSeatService _showSeatService;
        private readonly TicketService _ticketService;
        private readonly PaymentService _paymentService;

        public BookingService(ShowSeatService showSeatService, TicketService ticketService, PaymentService paymentService)
        {
            _showSeatService = showSeatService;
            _ticketService = ticketService;
            _paymentService = paymentService;
        }

        public Ticket BookTicket(User user, Show show, List<ShowSeat> seatsToBook, string paymentMethod)
        {
            if (!_showSeatService.AreSeatsAvailable(seatsToBook))
                throw new Exception("Some seats are already booked");

            _showSeatService.ReserveSeats(seatsToBook);

            decimal totalAmount = seatsToBook.Sum(seat => seat.Price);
            Ticket ticket = _ticketService.CreateTicket(user, show, seatsToBook, totalAmount);

            _paymentService.ProcessPayment(ticket, paymentMethod);

            return ticket;
        }
    }
}
