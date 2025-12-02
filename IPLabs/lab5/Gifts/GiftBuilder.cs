using IPLabs.lab5.Sweets;

namespace IPLabs.lab5.Gifts;

public class GiftBuilder
{
    private Gift gift = new Gift();

    public GiftBuilder AddCandy(Candy candy)
    {
        gift.AddSweet(candy);
        return this;
    }

    public GiftBuilder AddCookie(Cookie cookie)
    {
        gift.AddSweet(cookie);
        return this;
    }

    public Gift Build()
    {
        return gift;
    }
}