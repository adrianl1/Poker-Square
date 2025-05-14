//using static System.Windows.Forms.AxHost;

namespace Poker_Square
{
    public partial class Form1 : Form
    {
        List<Player> players = new List<Player>();
        List<GroupBox> playerBoxes = new List<GroupBox>();
        List<Payment> payments = new List<Payment>();
        int[] gridPlan; //Array containing the number of boxes in each row

        public Form1()
        {
            InitializeComponent();
            playerNumber_ValueChanged(null, null);
        }

        // Returns an array with each element representing the number of boxes in each row
        private int[] CalculateGridPlan(int numBoxes)
        {
            int fullRows = numBoxes / 3;
            int lastRow = numBoxes % 3;
            return Enumerable.Repeat(3, fullRows)
                             .Concat(lastRow > 0 ? [lastRow] : Array.Empty<int>())
                             .ToArray();

            //int[] gridPlan;
            //int leftOver = numBoxes % 3;
            //int lastRow;
            //if (leftOver == 0)
            //{
            //    gridPlan = new int[numBoxes / 3];
            //    lastRow = 3;
            //}
            //else
            //{
            //    gridPlan = new int[(numBoxes / 3) + 1];
            //    lastRow = leftOver;
            //}
            //for (int i = 0; i < gridPlan.Length; i++)
            //{
            //    if (i == gridPlan.Length - 1)
            //    {
            //        gridPlan[i] = lastRow;
            //    }
            //    else
            //    {
            //        gridPlan[i] = 3;
            //    }
            //}
            //return gridPlan;
        }

        private void playerNumber_ValueChanged(object sender, EventArgs e)
        {
            ClearErrorMessage();
            ClearSpacers();
            ClearPaymentText();

            gridPlan = CalculateGridPlan((int)playerNumber.Value);

            int gutter = 73; //Space between each box
            int currentY = PlayerGroupTemplate.Location.Y; //Y position of the template
            int currentPlayer = 1;
            //Remove boxes if the number decreased
            if (playerNumber.Value < playerBoxes.Count())
            {
                for (int i = playerBoxes.Count() - 1; i >= playerNumber.Value; i--)
                {
                    app_panel.Controls.Remove(playerBoxes[i]);
                    playerBoxes.Remove(playerBoxes[i]);
                }
            }
            //Add boxes if the number increased
            else
            {
                int difference = (int)playerNumber.Value - playerBoxes.Count();
                for(int i = 0; i < difference; i++)
                {
                    currentPlayer = playerBoxes.Count() + 1;
                    GroupBox newGroup = CreateGroupBox(PlayerGroupTemplate, currentPlayer);
                    app_panel.Controls.Add(newGroup);
                    playerBoxes.Add(newGroup);
                }
            }
            //Set box locations
            currentPlayer = 1;
            for (int i = 0; i < gridPlan.Length; i++)
            {
                if (gridPlan[i] != 3)
                {
                    gutter = (800 - (170 * gridPlan[i])) / (gridPlan[i] + 1);
                }
                for (int j = 0; j < gridPlan[i]; j++)
                {
                    GroupBox currentGroup = playerBoxes[currentPlayer - 1];
                    currentGroup.Location = new System.Drawing.Point(gutter + (j * (PlayerGroupTemplate.Width + gutter)), currentY);
                    currentPlayer++;
                }
                currentY += PlayerGroupTemplate.Height + 20;
            }

            //Update position of calculate button
            Control lastGroup = playerBoxes[playerBoxes.Count() - 1];
            calculate_button.Location = new System.Drawing.Point(calculate_button.Location.X, lastGroup.Location.Y + lastGroup.Size.Height + 20);
            calculate_button.Visible = true;

            // Conditionally create or update the spacer
            if (!app_panel.Controls.ContainsKey("button_spacer"))
            {
                Panel buttonSpacer = AddSpacer(20, calculate_button, "button_spacer");
                app_panel.Controls.Add(buttonSpacer);
            }
            else
            {
                app_panel.Controls.Find("button_spacer", false)[0].Location = new System.Drawing.Point(0, calculate_button.Location.Y + calculate_button.Height);
            }
        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            players.Clear();
            payments.Clear();
            ClearPaymentText();
            ClearErrorMessage();
            PopulatePlayersList();
            int currentY = calculate_button.Location.Y + calculate_button.Height + 20;
            try
            {
                VerifyChipCount();
                SquareUp();
                for (int i = 0; i < payments.Count(); i++)
                {
                    Label newLabel = CreatePaymentText(payment_text_template, payments[i], i + 1);
                    newLabel.Location = new System.Drawing.Point(payment_text_template.Location.X, currentY);
                    app_panel.Controls.Add(newLabel);
                    currentY += payment_text_template.Height + 20;
                }
                Label allSquare = new Label();
                allSquare.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                allSquare.Location = new System.Drawing.Point(payment_text_template.Location.X, currentY);
                allSquare.AutoSize = true;
                allSquare.Text = "All Square!";
                allSquare.Name = "all_square";
                app_panel.Controls.Add(allSquare);
                app_panel.Controls.Add(AddSpacer(20, allSquare, "all_square_spacer"));
            }
            catch (ChipCountMismatchException ex)
            {
                Label error = CreateErrorMessage(ex.Message);
                error.Location = new System.Drawing.Point(payment_text_template.Location.X, currentY);
                app_panel.Controls.Add(error);
                app_panel.Controls.Add(AddSpacer(20, error, "error_spacer"));
            }
        }

        private GroupBox CreateGroupBox(GroupBox original, int index)
        {
            GroupBox newGroup = new GroupBox
            {
                Name = "PlayerGroup_" + index,
                Text = original.Text + " " + (index), // Give each group a unique name
                Size = original.Size,
            };

            // Clone each control inside the original GroupBox
            foreach (Control control in original.Controls)
            {
                Control newControl = (Control)Activator.CreateInstance(control.GetType());
                newControl.Text = control.Text;
                newControl.Size = control.Size;
                newControl.Location = control.Location;
                newControl.Name = control.Name + "_Player" + index;
                newGroup.Controls.Add(newControl);
            }
            newGroup.Visible = true;

            return newGroup;
        }

        private Label CreatePaymentText(Label labelTemplate, Payment payment, int index)
        {
            Label newPaymentText = new Label
            {
                Name = "PaymentText_" + index,
                Font = labelTemplate.Font,
                AutoSize = true,
                Text = payment.player1 + " pays " + payment.player2 + " $" + payment.amount,
                Visible = true
            };
            return newPaymentText;
        }

        private Label CreateErrorMessage(String message)
        {
            Label errorLabel = new Label();
            errorLabel.Name = "error_text";
            errorLabel.Font = new Font("Segoe UI", 24F);
            errorLabel.ForeColor = Color.FromArgb(255, 0, 0);
            errorLabel.AutoSize = true;
            errorLabel.Text = message;
            errorLabel.Visible = true;
            return errorLabel;
        }

        private void ClearPaymentText()
        {
            List<Control> paymentLabels = new List<Control>();
            foreach (Control control in app_panel.Controls)
            {
                if (control.Name.Contains("PaymentText_"))
                {
                    paymentLabels.Add(control);
                }    
            }
            foreach (Control control in paymentLabels)
            {
                app_panel.Controls.Remove(control);
            }
            app_panel.Controls.RemoveByKey("all_square");
        }

        private void ClearErrorMessage()
        {
            if (app_panel.Controls.ContainsKey("error_text"))
            {
                app_panel.Controls.RemoveByKey("error_text");
            }
        }

        private void PopulatePlayersList()
        {
            foreach (GroupBox playerBox in playerBoxes)
            {
                string name = "";
                double buyIn = 0;
                double totalCount = 0;
                foreach (Control control in playerBox.Controls)
                {
                    if (control.Name.StartsWith("player_name"))
                    {
                        name = control.Text;
                        continue;
                    }
                    if (control.Name.StartsWith("player_final"))
                    {
                        totalCount = double.Parse(control.Text);
                        continue;
                    }
                    if (control.Name.StartsWith("player_bought"))
                    {
                        buyIn = double.Parse(control.Text);
                        continue;
                    }
                }
                players.Add(new Player(name, buyIn, totalCount));
            }
        }

        private void SquareUp()
        {
            List<Player> negatives = players.Where(player => player.chipValue - player.buyIn < 0).ToList();
            List<Player> positives = players.Where(player => player.chipValue - player.buyIn > 0).ToList();

            //Calculate differences
            foreach (Player player in players)
            {
                //The balance should be updated during the process of squaring up
                player.balance = player.chipValue - player.buyIn;
            }

            //Square up players
            while (negatives.Count != 0)
            {
                Player debtor = negatives[0];
                Player creditor = positives[0];
                double paymentAmount = Math.Min(Math.Abs(debtor.balance), creditor.balance);

                payments.Add(new Payment(debtor.name, creditor.name, paymentAmount));
                debtor.balance += paymentAmount;
                creditor.balance -= paymentAmount;

                if (debtor.balance == 0)
                {
                    negatives.RemoveAt(0);
                }
                if (creditor.balance == 0)
                {
                    positives.RemoveAt(0);
                }
            }

            //This loop starts at the first negative player in the list
            //while (negatives.Count != 0)
            //{
            //    //Check for any players that owe the exact amount that someone else made
            //    for (int i = 0; i < negatives.Count; i++)
            //    {
            //        for (int j = 0; j < positives.Count; j++)
            //        {
            //            if (Math.Abs(negatives[i].balance) == positives[j].balance)
            //            {
            //                payments.Add(new Payment(negatives[i].name, positives[j].name, positives[j].balance));
            //                negatives.RemoveAt(i);
            //                positives.RemoveAt(j);
            //                j--;
            //            }
            //        }
            //    }

            //    if (negatives.Count == 0)
            //    {
            //        break;
            //    }

            //    //Square up the next negative player
            //    if (positives[0].balance > Math.Abs(negatives[0].balance))
            //    {
            //        payments.Add(new Payment(negatives[0].name, positives[0].name, Math.Abs(negatives[0].balance)));
            //        positives[0].balance -= Math.Abs(negatives[0].balance);
            //        negatives.RemoveAt(0);
            //    }
            //    else
            //    {
            //        payments.Add(new Payment(negatives[0].name, positives[0].name, positives[0].balance));
            //        negatives[0].balance += positives[0].balance;
            //        positives.RemoveAt(0);
            //    }
            //}

        }

        private void VerifyChipCount()
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
                string message = "Verify chip count\nTotal buy in: $" + totalBuyIn + "\nTotal chip value: $" + totalChipValue;
                throw new ChipCountMismatchException(message);
            }
        }

        //Adds an amount of space below the specified "lastControl" and names it something
        private Panel AddSpacer(int amount, Control lastControl, string name)
        {
            Panel spacer = new Panel();
            spacer.Name = name;
            spacer.Size = new Size(1, amount);
            spacer.Location = new System.Drawing.Point(0, lastControl.Location.Y + lastControl.Height);
            spacer.BackColor = Color.Transparent;
            return spacer;
        }

        private void ClearSpacers()
        {
            foreach (Control control in app_panel.Controls)
            {
                if (control.Name.Contains("_spacer"))
                {
                    app_panel.Controls.Remove(control);
                }
            }
        }
    }

    class ChipCountMismatchException : Exception
    {
        public ChipCountMismatchException(string message) : base(message){ }
    }
}
