namespace BMS.Services
{
    public class PaymentService
    {
        public void ProcessPayment(Ticket ticket, string method)
        {
            Payment payment = new Payment
            {
                Ticket = ticket,
                Amount = ticket.TotalPrice,
                PaymentMethod = method,
                PaymentDate = DateTime.Now
            };

            // In real-world, call payment gateway APIs here
            Console.WriteLine($"Payment of {payment.Amount} done using {payment.PaymentMethod}");
        }
    }
}
