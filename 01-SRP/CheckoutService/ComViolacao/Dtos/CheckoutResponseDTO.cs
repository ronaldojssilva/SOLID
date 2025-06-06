namespace CheckoutService.ComViolacao.Dtos;

internal record CheckoutResponseDTO(
    string OrderId, 
    decimal TotalPrice, 
    decimal ShippingCost,
    StatusEnum Status,
    string? Error);

enum StatusEnum
{
    success,
    failed,
}