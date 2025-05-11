using System.Text.Json;

namespace Poker_Square
{
    internal static class Program
    {
        static List<Player> players = new List<Player>();
        static List<Player> negatives = new List<Player>();
        static List<Player> positives = new List<Player>();
        static List<Payment> payments = new List<Payment>();

        [STAThread]
        static void Main()
        {
            //Parse file and create lists
            string jsonText = File.ReadAllText("players.json");
            players = JsonSerializer.Deserialize<List<Player>>(jsonText);

            verifyChipCount();

            calculateDifferences();

            Console.WriteLine("----------");

            squareUp();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        static void verifyChipCount()
        {
            double totalBuyIn = 0;
            double totalChipValue = 0;
            foreach (Player player in players)
            {
                totalBuyIn += player.buyIn;
                totalChipValue += player.chipValue;
            }
            if (totalBuyIn != totalChipValue)
            {
                Console.WriteLine("VERIFY CHIP COUNT AND BUY IN VALUES");
                Console.WriteLine("Total buy in: $" + totalBuyIn);
                Console.WriteLine("Total chip value: $" + totalChipValue);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        static void calculateDifferences()
        {
            foreach (Player player in players) {
                //The difference should not change after this
                player.difference = player.chipValue - player.buyIn;
                //The balance should be updated during the process of squaring up
                player.balance = player.difference;

                Console.WriteLine(player.name + " balance: $" + player.difference);
                if(player.difference < 0)
                {
                    negatives.Add(player);
                }
                else
                {
                    positives.Add(player);
                }
            }
        }

        static void squareUp()
        {
            //This loop starts at the first negative player in the list
            while(negatives.Count != 0)
            {
                //Check for any players that owe the exact amount that someone else made
                for (int i = 0; i < negatives.Count; i++)
                {
                    for(int j = 0; j < positives.Count; j++)
                    {
                        if (Math.Abs(negatives[i].balance) == positives[j].balance)
                        {
                            payments.Add(new Payment(negatives[i].name, positives[j].name, positives[j].difference));
                            negatives.RemoveAt(i);
                            positives.RemoveAt(j);
                            i--;
                            j--;
                        }
                    }
                }

                if (negatives.Count == 0) {
                    break;
                }

                //Square up the next negative player
                if (positives[0].balance > Math.Abs(negatives[0].balance))
                {
                    payments.Add(new Payment(negatives[0].name, positives[0].name, Math.Abs(negatives[0].balance)));
                    positives[0].balance -= Math.Abs(negatives[0].balance);
                    negatives.RemoveAt(0);
                }
                else
                {
                    payments.Add(new Payment(negatives[0].name, positives[0].name, positives[0].balance));
                    negatives[0].balance += positives[0].balance;
                    positives.RemoveAt(0);
                }
            }
            
            foreach (Payment payment in payments)
            {
                Console.WriteLine(payment.player1 + " pays " + payment.player2 + " $" + payment.amount);
            }
        }
    }
}