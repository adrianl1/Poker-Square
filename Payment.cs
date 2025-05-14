using System;

public class Payment
{
	public string player1 { get; set; }
	public string player2 { get; set; }
	public double amount { get; set; }
	public Payment(string player1, string player2, double amount)
	{
		this.player1 = player1;
		this.player2 = player2;
		this.amount = amount;
	}

    public override string ToString()
    {
        return "{" + this.player1 + ", " + this.player2 + ", " + this.amount + "}"; ;
    }
}
