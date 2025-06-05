using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ComViolacao
{
    /// <summary>
    /// Essa classe é um orquestrador de reservas, que processa as informações de reserva, calcula o preço total e envia um e-mail de confirmação.
    /// Mas se houver necessidade de alterar a lógica de envio de e-mail ou cálculo de preço, teremos que modificar essa classe.
    /// ela deveria ser responsável apenas por orquestrar o processo de reserva, delegando as responsabilidades específicas para outras classes.
    /// </summary>
    internal class BookingService
    {
        public void ProcessBoking(BookingDetails bookingDetails)
        {
            // Validação das datas
            if (bookingDetails.StartDate >= bookingDetails.EndDate)
            {
                throw new ArgumentException("A data de início deve ser anterior à data de término.");
            }

            // Cálculo do preço total
            var durationInDays = bookingDetails.EndDate.DayNumber - bookingDetails.StartDate.DayNumber + 1;

            var totalPrice = bookingDetails.Dailyrate * durationInDays;

            Console.WriteLine($"Preço total calculado: R$ {totalPrice}");

            // Envio de confirmação por e-mail
            Console.WriteLine($"Enviando e-mail de confirmação para {bookingDetails.Email}");
        }
    }

    internal class BookingDetails
    {
        public DateOnly StartDate { get; internal set; }
        public DateOnly EndDate { get; internal set; }
        public int Dailyrate { get; internal set; }
        public string? Email { get; internal set; }
    }
}
