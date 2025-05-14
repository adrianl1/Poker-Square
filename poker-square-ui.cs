//using static System.Windows.Forms.AxHost;

using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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

            var gridPlan = Enumerable.Repeat(3, fullRows).ToList();
            if (lastRow > 0) gridPlan.Add(lastRow);

            return gridPlan.ToArray();

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
            ClearAllSpacers();
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
                for (int i = 0; i < difference; i++)
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
                app_panel.Controls.Add(CreateSpacer(20, calculate_button, "button_spacer"));
            }
            else
            {
                app_panel.Controls.Find("button_spacer", false)[0].Location = new System.Drawing.Point(0, calculate_button.Location.Y + calculate_button.Height);
            }
        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            if (!VerifyPopulatedTextBoxes())
            {
                CreateErrorMessage("Make sure all text boxes have some value.");
                return;
            }
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
                    app_panel.Controls.Add(newLabel);
                    newLabel.Location = new System.Drawing.Point(CalculateCenterX(newLabel), currentY);
                    currentY += payment_text_template.Height + 20;
                }
                Label allSquare = new Label()
                {
                    Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                    AutoSize = true,
                    Text = "All Square!",
                    Name = "all_square"
                };
                app_panel.Controls.Add(allSquare);
                allSquare.Location = new System.Drawing.Point(CalculateCenterX(allSquare), currentY);
                app_panel.Controls.Add(CreateSpacer(20, allSquare, "all_square_spacer"));
            }
            catch (ChipCountMismatchException ex)
            {
                CreateErrorMessage(ex.Message);
            }
        }

        private GroupBox CreateGroupBox(GroupBox original, int index)
        {
            GroupBox newGroup = new GroupBox
            {
                Name = "PlayerGroup_" + index,
                Text = original.Text + " " + (index), // Give each group a unique name
                Size = original.Size,
                TabIndex = original.TabIndex
            };

            // Clone each control inside the original GroupBox
            foreach (Control control in original.Controls)
            {
                Control newControl = (Control)Activator.CreateInstance(control.GetType());
                newControl.Text = control.Text;
                newControl.Size = control.Size;
                newControl.Location = control.Location;
                newControl.Name = control.Name + "_Player" + index;
                if (newControl is TextBox)
                {
                    newControl.TabIndex = control.TabIndex;
                    newControl.TextChanged += textbox_TextChanged;
                }
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

        private void CreateErrorMessage(string message)
        {
            Label errorLabel = new Label();
            errorLabel.Name = "error_text";
            errorLabel.Font = new Font("Segoe UI", 24F);
            errorLabel.ForeColor = Color.FromArgb(255, 0, 0);
            errorLabel.AutoSize = true;
            errorLabel.Text = message;
            errorLabel.Visible = true;
            app_panel.Controls.Add(errorLabel);
            errorLabel.Location = new System.Drawing.Point(CalculateCenterX(errorLabel), calculate_button.Location.Y + calculate_button.Height + 20);
            app_panel.Controls.Add(CreateSpacer(20, errorLabel, "error_spacer"));
        }

        //Adds an amount of space below the specified "lastControl" and names it something
        private Panel CreateSpacer(int amount, Control lastControl, string name)
        {
            Panel spacer = new Panel();
            spacer.Name = name;
            spacer.Size = new Size(1, amount);
            spacer.Location = new System.Drawing.Point(0, lastControl.Location.Y + lastControl.Height);
            spacer.BackColor = Color.Transparent;
            return spacer;
        }

        private void CreateTestData()
        {
            Random rand = new Random();
            int playerNum = rand.Next(2, 9);


            decimal winningsRemaining = 20 * playerNum;
            playerNumber.Value = playerNum;
            for (int i = 1; i <= playerBoxes.Count(); i++)
            {
                foreach (Control c in playerBoxes[i - 1].Controls)
                {
                    if (c.Name.StartsWith("player_name"))
                    {
                        c.Text = "Player " + i;
                    }
                    else if (c.Name.StartsWith("player_bought"))
                    {
                        c.Text = "20";
                    }
                    else if (c.Name.StartsWith("player_final"))
                    {
                        if (i == playerBoxes.Count())
                        {
                            c.Text = winningsRemaining.ToString();
                        }
                        else
                        {
                            decimal max = winningsRemaining;
                            decimal final = Math.Round((decimal)rand.NextDouble() * max, 2);
                            winningsRemaining -= final;
                            c.Text = final.ToString();
                        }
                    }
                }
            }
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

        private void ClearAllSpacers()
        {
            for (int i = app_panel.Controls.Count - 1; i >= 0; i--)
            {
                if (app_panel.Controls[i].Name.Contains("_spacer"))
                {
                    app_panel.Controls.RemoveAt(i);
                }
            }
        }

        private void ClearTestData()
        {
            for (int i = 1; i <= playerBoxes.Count(); i++)
            {
                foreach (Control c in playerBoxes[i - 1].Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
        }

        private void PopulatePlayersList()
        {
            foreach (GroupBox playerBox in playerBoxes)
            {
                string name = "";
                decimal buyIn = 0;
                decimal totalCount = 0;
                foreach (Control control in playerBox.Controls)
                {
                    if (control.Name.StartsWith("player_name"))
                    {
                        name = control.Text;
                        continue;
                    }
                    if (control.Name.StartsWith("player_final"))
                    {
                        totalCount = decimal.Parse(control.Text);
                        continue;
                    }
                    if (control.Name.StartsWith("player_bought"))
                    {
                        buyIn = decimal.Parse(control.Text);
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
                decimal paymentAmount = Math.Min(Math.Abs(debtor.balance), creditor.balance);

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
            decimal totalBuyIn = 0;
            decimal totalChipValue = 0;
            foreach (Player player in players)
            {
                totalBuyIn += player.buyIn;
                totalChipValue += player.chipValue;
            }
            if (totalBuyIn != totalChipValue) //Written this way to avoid floating point precision errors
            {
                string message = "Verify chip count\nTotal buy in: $" + totalBuyIn + "\nTotal chip value: $" + totalChipValue;
                throw new ChipCountMismatchException(message);
            }
        }

        private bool VerifyPopulatedTextBoxes()
        {
            bool conclusion = true;
            foreach (GroupBox playerBox in playerBoxes)
            {
                foreach (Control c in playerBox.Controls)
                {
                    if (c is TextBox)
                    {
                        c.BackColor = Color.White;
                        if (c.Text.Equals(""))
                        {
                            c.BackColor = Color.FromArgb(255, 184, 184);
                            conclusion = false;
                        }
                    }
                }
            }
            return conclusion;
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textbox)
            {
                textbox.BackColor = Color.White;
            }
        }

        private void test_data_CheckedChanged(object sender, EventArgs e)
        {
            if (test_data.Checked)
            { 
                CreateTestData();
            }
            else
            {
                ClearTestData();
            }
        }

        //If the control is auto sized, this MUST be called AFTER adding it to the panel
        private int CalculateCenterX(Control control)
        {
            return (800 - control.Width) / 2;
        }
    }

    class ChipCountMismatchException : Exception
    {
        public ChipCountMismatchException(string message) : base(message){ }
    }
}
