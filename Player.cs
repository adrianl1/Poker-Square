using System;

public class Player
{
    public string name { get; set; }
    public double buyIn { get; set; }
    public double chipValue { get; set; }
    public double difference { get; set; }
    public double balance { get; set; }

    public Player(string name, double buyIn, double chipValue)
    {
        this.name = name;
        this.buyIn = buyIn;
        this.chipValue = chipValue;
        this.difference = 0;
        this.balance = 0;
    }
}
