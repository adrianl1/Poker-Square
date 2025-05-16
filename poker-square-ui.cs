namespace Poker_Square
{
    public partial class PokerSquareForm : Form
    {
        List<Player> players = new List<Player>();
        List<GroupBox> playerBoxes = new List<GroupBox>();
        List<Payment> payments = new List<Payment>();
        int[] gridPlan; //Array containing the number of boxes in each row

        int minGutter = 75;
        int playersPerRow = 3;
        double sidePaddingPercent = .1;
        int sidePadding = 0;

        public PokerSquareForm()
        {
            InitializeComponent();
            playerNumber_ValueChanged(null, null);
        }

        // Returns an array with each element representing the number of boxes in each row
        private int[] CalculateGridPlan(int numBoxes)
        {
            int fullRows = numBoxes / playersPerRow;
            int lastRow = numBoxes % playersPerRow;

            var gridPlan = Enumerable.Repeat(playersPerRow, fullRows).ToList();
            if (lastRow > 0) gridPlan.Add(lastRow);

            return gridPlan.ToArray();
        }

        private void playerNumber_ValueChanged(object sender, EventArgs e)
        {
            ClearErrorMessage();
            ClearAllSpacers();
            ClearPaymentText();
            int currentPlayer;

            //Remove boxes if the number decreased
            if (playerNumber.Value < playerBoxes.Count())
            {
                for (int i = playerBoxes.Count() - 1; i >= playerNumber.Value; i--)
                {
                    Controls.Remove(playerBoxes[i]);
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
                    Controls.Add(newGroup);
                    playerBoxes.Add(newGroup);
                }
            }

            ArrangeContent();
        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            players.Clear();
            payments.Clear();
            ClearPaymentText();
            ClearErrorMessage();
            if (!VerifyPopulatedTextBoxes())
            {
                CreateErrorMessage("Make sure all text boxes have some value.");
                return;
            }
            PopulatePlayersList();
            int currentY = calculate_button.Location.Y + calculate_button.Height + 20;
            try
            {
                VerifyChipCount();
                SquareUp();
                for (int i = 0; i < payments.Count(); i++)
                {
                    Label newLabel = CreatePaymentText(payment_text_template, payments[i], i + 1);
                    Controls.Add(newLabel);
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
                Controls.Add(allSquare);
                allSquare.Location = new System.Drawing.Point(CalculateCenterX(allSquare), currentY);
                Controls.Add(CreateSpacer(20, allSquare, "all_square_spacer"));
            }
            catch (ChipCountMismatchException ex)
            {
                CreateErrorMessage(ex.Message);
            }
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

        private void window_SizeChanged(object sender, EventArgs e)
        {
            if(this.ClientSize.Width <= 940)
            {
                sidePaddingPercent = .1;
            }
            else
            {
                sidePaddingPercent = .2;
            }
                top_panel.Location = new System.Drawing.Point(CalculateCenterX(top_panel), top_panel.Location.Y);
            ArrangeContent();
        }

        private GroupBox CreateGroupBox(GroupBox original, int index)
        {
            GroupBox newGroup = new GroupBox
            {
                Name = "PlayerGroup_" + index,
                Text = original.Text + " " + (index), // Give each group a unique name
                Font = original.Font,
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
                newControl.Font = control.Font;
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
            Label errorLabel = new Label()
            {
                Name = "error_text",
                Font = new Font("Segoe UI", 24F),
                BackColor = Color.FromArgb(200, 0, 0),
                ForeColor = Color.White,
                AutoSize = true,
                Text = message,
                Visible = true
            };

            Controls.Add(errorLabel);
            errorLabel.Location = new System.Drawing.Point(CalculateCenterX(errorLabel), calculate_button.Location.Y + calculate_button.Height + 20);
            Controls.Add(CreateSpacer(20, errorLabel, "error_spacer"));
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
            foreach (var control in Controls.OfType<Label>()
                                      .Where(c => c.Name.StartsWith("PaymentText_") || c.Name == "all_square")
                                      .ToList())
            {
                Controls.Remove(control);
            }
        }

        private void ClearErrorMessage()
        {
            Controls.RemoveByKey("error_text");
        }

        private void ClearAllSpacers()
        {
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i].Name.Contains("_spacer"))
                {
                    Controls.RemoveAt(i);
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

                if (debtor.balance < 0.01m)
                {
                    negatives.RemoveAt(0);
                }
                if (creditor.balance < 0.01m)
                {
                    positives.RemoveAt(0);
                }
            }
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
            bool allValid = true;
            foreach (GroupBox playerBox in playerBoxes)
            {
                foreach (TextBox textBox in playerBox.Controls.OfType<TextBox>())
                {
                    textBox.BackColor = Color.White;
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.BackColor = Color.FromArgb(255, 184, 184);
                        allValid = false;
                    }
                }
            }
            return allValid;
        }

        //If the control is auto sized, this MUST be called AFTER adding it to the panel
        private int CalculateCenterX(Control control)
        {
            return (this.ClientSize.Width - control.Width) / 2;
        }

        private int CalculateBaseGutter()
        {
            int calculatedGutter = minGutter;
            int currentGutter = minGutter;
            int numPlayerGroups = 1;
            this.AutoScrollPosition = new Point(0, 0);
            int totalWidth = this.ClientSize.Width - 1;
            sidePadding = (int)(((double)this.ClientSize.Width) * sidePaddingPercent);
            while (currentGutter >= minGutter && totalWidth <= this.ClientSize.Width)
            {
                currentGutter = ((this.ClientSize.Width - (sidePadding * 2)) - (numPlayerGroups * PlayerGroupTemplate.Width)) / (numPlayerGroups + 1);
                totalWidth = (sidePadding * 2) + (numPlayerGroups * PlayerGroupTemplate.Width) + (numPlayerGroups * (currentGutter + 1));
                if (currentGutter >= minGutter && totalWidth <= this.ClientSize.Width)
                {
                    calculatedGutter = currentGutter;
                    playersPerRow = numPlayerGroups;
                }
                numPlayerGroups++;
            }
            return calculatedGutter;
        }

        private void ArrangeContent()
        {
            gridPlan = CalculateGridPlan((int)playerNumber.Value);
            int gutter = CalculateBaseGutter();
            int currentY = PlayerGroupTemplate.Location.Y; //Y position of the template
            int currentPlayer = 1;
            for (int i = 0; i < gridPlan.Length; i++)
            {
                if (gridPlan[i] != playersPerRow)
                {
                    gutter = ((this.ClientSize.Width - (sidePadding * 2)) - (PlayerGroupTemplate.Width * gridPlan[i])) / (gridPlan[i] + 1);
                }
                for (int j = 0; j < gridPlan[i]; j++)
                {

                    GroupBox currentGroup = playerBoxes[currentPlayer - 1];
                    currentGroup.Location = new System.Drawing.Point(sidePadding + gutter + (j * (PlayerGroupTemplate.Width + gutter)), currentY);
                    currentPlayer++;
                }
                currentY += PlayerGroupTemplate.Height + 20;
            }

            //Update position of calculate button
            Control lastGroup = playerBoxes[playerBoxes.Count() - 1];
            calculate_button.Location = new System.Drawing.Point(CalculateCenterX(calculate_button), lastGroup.Location.Y + lastGroup.Size.Height + 20);
            calculate_button.Visible = true;

            // Conditionally create or update the spacer
            if (!Controls.ContainsKey("button_spacer"))
            {
                Controls.Add(CreateSpacer(20, calculate_button, "button_spacer"));
            }
            else
            {
                Controls.Find("button_spacer", false)[0].Location = new System.Drawing.Point(0, calculate_button.Location.Y + calculate_button.Height);
            }
        }
    }

    class ChipCountMismatchException : Exception
    {
        public ChipCountMismatchException(string message) : base(message){ }
    }
}
