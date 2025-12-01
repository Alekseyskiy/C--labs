namespace IPLabs.lab5.Sweets;

public class Cookie : Sweet
{
    public bool HasChocolate { get; set; }

    public Cookie(string name, double weight, double sugarContent, bool hasChocolate) 
        : base(name, weight, sugarContent)
    {
        HasChocolate = hasChocolate;
    }

    public override string ToString()
    {
        return base.ToString() + $", Chocolate: {HasChocolate}";
    }
}