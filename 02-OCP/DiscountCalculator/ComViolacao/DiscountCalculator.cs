namespace DiscountCalculator.ComViolacao
{
    internal class DiscountCalculator
    {
        public decimal CalculateDiscount(string userType)
        {
            if (userType == "Premium")
            {
                return 20;
            }
            else if (userType == "Regular")
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
    }
}
