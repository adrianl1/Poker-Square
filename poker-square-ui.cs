//using static System.Windows.Forms.AxHost;

namespace Poker_Square
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submit_playerNumber_Click(object sender, EventArgs e)
        {
            RemoveOldPaymentText();
            RemoveOldGroupBoxes();

            //Create player info boxes
            int gutter = 73; //Space between each box
            int currentY = PlayerGroupTemplate.Location.Y; //Y position of the template
            int currentPlayer = 1;
            int[] gridPlan = CalculateGridPlan((int)playerNumber.Value); //Array containing the number of boxes in each row
            for(int i = 0; i < gridPlan.Length; i++)
            {
                for (int j = 0; j < gridPlan[i]; j++)
                {
                    if (gridPlan[i] != 3)
                    {
                        gutter = (800 - (170 * gridPlan[i])) / (gridPlan[i] + 1);
                    }
                    GroupBox newGroup = CloneGroupBox(PlayerGroupTemplate, currentPlayer);
                    newGroup.Location = new System.Drawing.Point(gutter + (j * (PlayerGroupTemplate.Width + gutter)), currentY);
                    app_panel.Controls.Add(newGroup);
                    currentPlayer++;
                }
                currentY += PlayerGroupTemplate.Height + 20;
            }

            //Show calculate button
            if ((int)playerNumber.Value == 0)
            {
                Calculate_Button.Location = new System.Drawing.Point(Calculate_Button.Location.X, 384);
                Calculate_Button.Visible = false;
            }
            else
            {
                Control lastGroup = app_panel.Controls[app_panel.Controls.Count - 1];
                Calculate_Button.Location = new System.Drawing.Point(Calculate_Button.Location.X, lastGroup.Location.Y + lastGroup.Size.Height + 20);
                Calculate_Button.Visible = true;
            }

            app_panel.AutoScrollMinSize = new Size(0, currentY + 72); //Adds space to the bottom of the scrollable area
        }

        // Returns an array with each element representing the number of boxes in a row
        private int[] CalculateGridPlan(int numBoxes)
        {
            int[] gridPlan;
            int leftOver = numBoxes % 3;
            int lastRow;
            if (leftOver == 0)
            {
                gridPlan = new int[numBoxes / 3];
                lastRow = 3;
            }
            else
            {
                gridPlan = new int[(numBoxes / 3) + 1];
                lastRow = leftOver;
            }
            for (int i = 0; i < gridPlan.Length; i++)
            {
                if (i == gridPlan.Length - 1)
                {
                    gridPlan[i] = lastRow;
                }
                else
                {
                    gridPlan[i] = 3;
                }
            }
            return gridPlan;
        }

        private GroupBox CloneGroupBox(GroupBox original, int index)
        {
            GroupBox clone = new GroupBox();
            clone.Name = "PlayerGroup_" + index;
            clone.Text = original.Text + " " + (index); // Give each group a unique name
            clone.Size = original.Size;

            // Clone each control inside the original GroupBox
            foreach (Control control in original.Controls)
            {
                Control newControl = (Control)Activator.CreateInstance(control.GetType());
                newControl.Text = control.Text;
                newControl.Size = control.Size;
                newControl.Location = control.Location;
                newControl.Name = control.Name + "_Player" + index;
                clone.Controls.Add(newControl);
            }
            clone.Visible = true;

            return clone;
        }

        private void RemoveOldGroupBoxes()
        {
            for (int i = app_panel.Controls.Count - 1; i >= 0; i--)
                {
                if (app_panel.Controls[i] is GroupBox && app_panel.Controls[i].Name.StartsWith("PlayerGroup_"))
                {
                    app_panel.Controls.RemoveAt(i);
                }
            }
        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            RemoveOldPaymentText();

            int startX = payment_text_template.Location.X;
            int startY = payment_text_template.Location.Y;
            for (int i = 0; i < (int)playerNumber.Value; i++)
            {
                Label newLabel = clonePaymentText(payment_text_template, i + 1);
                newLabel.Location = new System.Drawing.Point(startX, startY + (i * (payment_text_template.Height + 20)));
                app_panel.Controls.Add (newLabel);
            }
        }

        private Label clonePaymentText(Label original, int index)
        {
            Label clone = new Label();
            clone.Name = "PaymentText_" + index;
            clone.Size = original.Size;
            clone.Text = index + " pays " + index + " some money";
            clone.Visible = true;
            return clone;
        }

        private void RemoveOldPaymentText()
        {
            for (int i = app_panel.Controls.Count - 1; i >= 0; i--)
            {
                if (app_panel.Controls[i] is Label && app_panel.Controls[i].Name.StartsWith("PaymentText_"))
                {
                    app_panel.Controls.RemoveAt(i);
                }
            }
        }
    }
}
