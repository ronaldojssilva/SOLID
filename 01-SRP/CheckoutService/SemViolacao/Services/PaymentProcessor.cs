using CheckoutService.SemViolacao.Dtos;

namespace CheckoutService.SemViolacao.Services;

internal class PaymentProcessor
{
    internal async Task<PaymentResult> ProcessPaymentAsync(PaymentRequest paymentRequest)
    {
        if (paymentRequest.PaymentInfo.CardNumber == "0000")
        {
            return new PaymentResult(false, "InvalidCardNumber");
        }
        return new PaymentResult(true, null);
    }
}

internal class PaymentRequest
{
    public string UserId { get; set; }

    public decimal Amount { get; set; }

    public PaymentInfo PaymentInfo { get; set; }
}

internal record PaymentResult(bool Success, string? ErrorCode);