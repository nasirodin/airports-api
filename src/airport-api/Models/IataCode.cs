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
        return Code.Length == 3;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as IataCode;
        return this.Code == other?.Code;
    }

    public void EnsureIsValid()
    {
        if (IsValid() == false) throw new Exception($"IATA Code is not valid : {Code}");
    }
    
    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}