using System.Text.RegularExpressions;

namespace Validator.SemViolacao;

interface IValidatorStrategy
{
    bool Validate(string input);
}

class EmailValidator : IValidatorStrategy
{
    public bool Validate(string input)
    {
        // Implement email validation logic here
        return Regex.IsMatch(input, @"\S+@\S+\.\S+");
    }
}

class PhoneValidator : IValidatorStrategy
{
    public bool Validate(string input)
    {
        // Implement phone validation logic here
        return Regex.IsMatch(input, @"^\d{10}$");
    }
}

public class ValidatorType
{
    public readonly static ValidatorType Email = new(1, "Email");
    public readonly static ValidatorType Phone = new(2, "Phone");

    public ValidatorType(int cod, string name)
    {
        Cod = cod;
        Name = name;
    }

    public int Cod { get; private set; }

    public string Name { get; private set; }
}

internal class Validator
{
    private Dictionary<ValidatorType, IValidatorStrategy> strategies = [];
        
    public void AddStrategy(ValidatorType field, IValidatorStrategy strategy)
    {
        strategies[field] = strategy;
    }

    public bool Validate(ValidatorType field, string value)
    {
        var strategy = strategies.GetValueOrDefault(field);
        if (strategy == null)
        {
            throw new ArgumentException($"No validation strategy found for field: {field}");
        }
        return strategy.Validate(value);
    }
}

