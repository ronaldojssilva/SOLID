namespace CheckoutService.SemViolacao.Dtos;

internal record CheckoutDTO(string UserId, IEnumerable<Item> Items, string Address, PaymentInfo PaymentInfo);

internal record PaymentInfo(string CardNumber, string Cvv);

internal record Item(string ProductId, int Quantity);
