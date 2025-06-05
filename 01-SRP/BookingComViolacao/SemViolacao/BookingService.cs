using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.SemViolacao
{
    internal class BookingValidator
    {
        public void ValidateDates(DateOnly startDate, DateOnly endDate)
        {
            if (startDate >= endDate)
            {
                throw new ArgumentException("Data de check-ou deve ser após a data de check-in");
            }
        }
    }

    internal class BookingPriceCalculator
    {
        public decimal CalculatePrice(DateOnly startDate, DateOnly endDate, decimal dailyRate)
        {
            var durationInDays = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days + 1;
            return dailyRate * durationInDays;
        }
    }

    class EmailService
    {
        public void SendConfirmation(string email)
        {
            Console.WriteLine($"Enviando e-mail de confirmação para {email}");
        }
    }

    // Essa classe BookingService agora é responsável apenas por orquestrar o processo de reserva, delegando as responsabilidades específicas para outras classes.
    // Essa classe tem uma regra clara de negócio que é: validar as datas, calcular o preço total e enviar um e-mail de confirmação.
    // Essas regras são delegadas para as classes BookingValidator, BookingPriceCalculator e EmailService, respectivamente. e poderão ser substituidos caso tenham
    // necessidade de alteração na lógica de validação, cálculo ou envio de e-mail, sem afetar a classe BookingService.
    // Mas se em algum momento tiver um conflito de como um processamento de reserva deve ser feito, por exemplo,
    // nesse caso pode ser mais interessante criar uma outra classe que forneça um fluxo diferente ou trabalhar com outra abordagem.
    class BookingService
    {
        private readonly BookingValidator _bookingValidator;
        private readonly BookingPriceCalculator _bookingPriceCalculator;
        private readonly EmailService _emailService;

        public BookingService()
        {
            _bookingValidator = new BookingValidator();
            _bookingPriceCalculator = new BookingPriceCalculator();
            _emailService = new EmailService();
        }

        public void ProcessBooking(DateOnly startDate, DateOnly endDate, decimal dailyRate, string email)
        {
            // Validação das datas.
            // agora no procesamento de reserva, a validação das datas é feita por uma classe separada, BookingValidator.
            // isso permite que a lógica de validação seja reutilizada em outros contextos, se necessário, sem duplicação de código.
            // e facilita a manutenção, pois se a lógica de validação precisar ser alterada, só será necessário modificar a classe BookingValidator.
            _bookingValidator.ValidateDates(startDate, endDate);

            // Cálculo do preço total
            // o cálculo do preço total é feito por uma classe separada, BookingPriceCalculator.
            // isso permite que a lógica de cálculo seja reutilizada em outros contextos, se necessário, sem duplicação de código.
            // e facilita a manutenção, pois se a lógica de cálculo precisar ser alterada, só será necessário modificar a classe BookingPriceCalculator.
            var totalPrice = _bookingPriceCalculator.CalculatePrice(startDate, endDate, dailyRate);
            Console.WriteLine($"Preço total calculado: R$ {totalPrice}");

            // Envio de confirmação por e-mail
            // o envio de e-mail é feito por uma classe separada, EmailService.
            // isso permite que a lógica de envio de e-mail seja reutilizada em outros contextos, se necessário, sem duplicação de código.
            // e facilita a manutenção, pois se a lógica de envio de e-mail precisar ser alterada, só será necessário modificar a classe EmailService.
            _emailService.SendConfirmation(email);
        }
    }
}
