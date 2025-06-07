// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var validatorSemViolacao = new Validator.SemViolacao.Validator();
validatorSemViolacao.AddStrategy(Validator.SemViolacao.ValidatorType.Email, new Validator.SemViolacao.EmailValidator());
validatorSemViolacao.AddStrategy(Validator.SemViolacao.ValidatorType.Phone, new Validator.SemViolacao.PhoneValidator());

Console.WriteLine(validatorSemViolacao.Validate(Validator.SemViolacao.ValidatorType.Email, "test@example.com"));
Console.WriteLine(validatorSemViolacao.Validate(Validator.SemViolacao.ValidatorType.Phone, "0123456789"));