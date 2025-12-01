namespace IPLabs.lab5.Sweets;

public abstract class Sweet
{
    public string Name { get; set; }
    public double Weight { get; set; } // в граммах
    public double SugarContent { get; set; } // в граммах

    protected Sweet(string name, double weight, double sugarContent)
    {
        Name = name;
        Weight = weight;
        SugarContent = sugarContent;
    }

    public override string ToString()
    {
        return $"{Name} - {Weight}g, Sugar: {SugarContent}g";
    }
}