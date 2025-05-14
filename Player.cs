using System;

public class Player
{
    public string name { get; set; }
    public decimal buyIn { get; set; }
    public decimal chipValue { get; set; }
    public decimal balance { get; set; }

    public Player(string name, decimal buyIn, decimal chipValue)
    {
        this.name = name;
        this.buyIn = buyIn;
        this.chipValue = chipValue;
        this.balance = 0;
    }

    public override string ToString()
    {
        return "{" + this.name + ", " + this.buyIn + ", " + this.chipValue + "}";
    }
}
