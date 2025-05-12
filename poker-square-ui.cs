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
            RemoveOldGroupBoxes();

            //Create player info boxes
            int numBoxes = (int)playerNumber.Value;
            int numRows = (numBoxes / 3) + 1;
            int leftOver = numBoxes % 3;
            int row = 1; //Current row
            int gutter = 45; //Space between each box
            int startX = PlayerGroupTemplate.Location.X; // X position of the template
            int currentY = PlayerGroupTemplate.Location.Y; //Y position of the template
            int scrollableHeight = 0;
            for (int i = 0; i < numBoxes; i++)
            {
                if (i + 1 > row * 3)
                {
                    row++;
                    startX = PlayerGroupTemplate.Location.X;
                    currentY = (PlayerGroupTemplate.Location.Y + ((PlayerGroupTemplate.Size.Height + 20) * (row - 1)));
                    scrollableHeight += PlayerGroupTemplate.Size.Height + 20;
                    if (row == numRows)
                    {
                        gutter = (600 - (170 * leftOver)) / (leftOver + 1);
                        startX += gutter;
                        app_panel.AutoScrollMinSize = new Size(0, scrollableHeight + 450); //Adds space to the bottom of the scrollable area
                    }
                }
                GroupBox newGroup = CloneGroupBox(PlayerGroupTemplate, i + 1);
                newGroup.Location = new System.Drawing.Point(startX + ((i % 3) * (PlayerGroupTemplate.Width + gutter)), currentY);
                app_panel.Controls.Add(newGroup);
            }

            //Show calculate button
            Control lastGroup = app_panel.Controls[app_panel.Controls.Count - 1];
            Calculate_Button.Location = new System.Drawing.Point(Calculate_Button.Location.X, lastGroup.Location.Y + lastGroup.Size.Height + 20);
            Calculate_Button.Visible = true;
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

        // Remove any previously generated group boxes
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
    }
}
