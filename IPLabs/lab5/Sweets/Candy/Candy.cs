using IPLabs.lab5.Sweets;

namespace IPLabs.lab5;

public abstract class Candy : Sweet
{
    public Candy(string name, double weight, double sugarContent) 
        : base(name, weight, sugarContent) { }
}