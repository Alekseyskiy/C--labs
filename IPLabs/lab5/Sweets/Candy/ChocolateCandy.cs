namespace IPLabs.lab5;

public class ChocolateCandy : Candy
{
    public string ChocolateType { get; set; } // например: молочный, темный

    public ChocolateCandy(string name, double weight, double sugarContent, string chocolateType) 
        : base(name, weight, sugarContent)
    {
        ChocolateType = chocolateType;
    }

    public override string ToString()
    {
        return base.ToString() + $", Type: {ChocolateType}";
    }
}