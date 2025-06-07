// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var discountCalculatorComViolacao = new DiscountCalculator.ComViolacao.DiscountCalculator();
discountCalculatorComViolacao.CalculateDiscount("Premium");
discountCalculatorComViolacao.CalculateDiscount("Regular");

var discountCalculatorSemViolacao = new DiscountCalculator.SemViolacao.DiscountCalculator();
discountCalculatorSemViolacao.CalculateDiscount(new DiscountCalculator.SemViolacao.PremiumDiscount());
discountCalculatorSemViolacao.CalculateDiscount(new DiscountCalculator.SemViolacao.RegularDiscount());