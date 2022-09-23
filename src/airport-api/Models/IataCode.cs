using airport_api.Exceptions;

namespace airport_api.Models;

public class IataCode
{
    public string Code { get; }

    public IataCode(string code)
    {
        Code = (code ?? string.Empty).ToUpper();
    }

    public bool IsValid()
    {
        return Code.Length == 3 && Code.All(c=>char.IsLetter(c));
    }

    public override bool Equals(object? obj)
    {
        var other = obj as IataCode;
        return this.Code == other?.Code;
    }

    public void EnsureIsValid()
    {
        if (IsValid() == false) throw new InvalidIataCodeException(Code);
    }
    
    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}