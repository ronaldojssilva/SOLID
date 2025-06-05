namespace Checkout.ComViolacao
{
    internal class CheckoutService
    {
        public void ProcessCheckout(Cart cart, string userId)
        {
            // Validação de estoque
            foreach (var item in cart.Items)
            {
                if (item.Stock < item.Quantity)
                {
                    throw new ArgumentException($"Produto {item.Name} sem estoque suficiente.");
                }
            }

            // Cálculo de impostos e total
            decimal total = 0;
            foreach (var item in cart.Items)
            {
                total += item.Price * item.Quantity;
            }

            var tax = total * 0.1m;
            total += tax;

            Console.WriteLine($"Total com impostos: R${total}");

            // Processamento de pagamento
            Console.WriteLine($"Processando pagamento para o usuário {userId}");
        }
    }
}
