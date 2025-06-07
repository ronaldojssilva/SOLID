using System.Text.RegularExpressions;

namespace Validator.ComViolacao;

public class Validator
{
    public bool Validate(string field, string value)
    {
        if (field == "email")
        {
            return Regex.IsMatch(value, @"\S+@\S+\.\S+");
        }
        else if (field == "phone")
        {
            return Regex.IsMatch(value, @"^\d{10}$");
        }

        return false;
    }
}