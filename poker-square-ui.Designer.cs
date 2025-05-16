namespace Poker_Square
{
    partial class PokerSquareForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokerSquareForm));
            test_data = new CheckBox();
            payment_text_template = new Label();
            calculate_button = new Button();
            PlayerGroupTemplate = new GroupBox();
            player_dollarsign2 = new Label();
            player_dollarsign1 = new Label();
            label_player_final = new Label();
            label_player_bought = new Label();
            label_player_name = new Label();
            player_name = new TextBox();
            player_final = new TextBox();
            player_bought = new TextBox();
            playerNumber = new NumericUpDown();
            playerNumber_label = new Label();
            logo = new PictureBox();
            top_panel = new Panel();
            PlayerGroupTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playerNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            top_panel.SuspendLayout();
            SuspendLayout();
            // 
            // test_data
            // 
            test_data.AutoSize = true;
            test_data.Location = new Point(366, 249);
            test_data.Name = "test_data";
            test_data.Size = new Size(96, 19);
            test_data.TabIndex = 25;
            test_data.Text = "Use Test Data";
            test_data.UseVisualStyleBackColor = true;
            test_data.Click += test_data_CheckedChanged;
            // 
            // payment_text_template
            // 
            payment_text_template.AutoSize = true;
            payment_text_template.Font = new Font("Segoe UI", 16F);
            payment_text_template.Location = new Point(306, 698);
            payment_text_template.Name = "payment_text_template";
            payment_text_template.Size = new Size(189, 30);
            payment_text_template.TabIndex = 24;
            payment_text_template.Text = "player pays player";
            payment_text_template.Visible = false;
            // 
            // calculate_button
            // 
            calculate_button.Font = new Font("Segoe UI", 16F);
            calculate_button.Location = new Point(268, 572);
            calculate_button.Margin = new Padding(3, 20, 3, 20);
            calculate_button.Name = "calculate_button";
            calculate_button.Size = new Size(265, 52);
            calculate_button.TabIndex = 22;
            calculate_button.Text = "Calculate Payments";
            calculate_button.UseVisualStyleBackColor = true;
            calculate_button.Visible = false;
            calculate_button.Click += Calculate_Button_Click;
            // 
            // PlayerGroupTemplate
            // 
            PlayerGroupTemplate.BackColor = Color.Transparent;
            PlayerGroupTemplate.BackgroundImageLayout = ImageLayout.Stretch;
            PlayerGroupTemplate.Controls.Add(player_dollarsign2);
            PlayerGroupTemplate.Controls.Add(player_dollarsign1);
            PlayerGroupTemplate.Controls.Add(label_player_final);
            PlayerGroupTemplate.Controls.Add(label_player_bought);
            PlayerGroupTemplate.Controls.Add(label_player_name);
            PlayerGroupTemplate.Controls.Add(player_name);
            PlayerGroupTemplate.Controls.Add(player_final);
            PlayerGroupTemplate.Controls.Add(player_bought);
            PlayerGroupTemplate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PlayerGroupTemplate.Location = new Point(124, 302);
            PlayerGroupTemplate.Name = "PlayerGroupTemplate";
            PlayerGroupTemplate.Size = new Size(170, 225);
            PlayerGroupTemplate.TabIndex = 21;
            PlayerGroupTemplate.TabStop = false;
            PlayerGroupTemplate.Text = "Player";
            PlayerGroupTemplate.Visible = false;
            // 
            // player_dollarsign2
            // 
            player_dollarsign2.AutoSize = true;
            player_dollarsign2.Font = new Font("Segoe UI", 9F);
            player_dollarsign2.Location = new Point(17, 172);
            player_dollarsign2.Name = "player_dollarsign2";
            player_dollarsign2.Size = new Size(13, 15);
            player_dollarsign2.TabIndex = 7;
            player_dollarsign2.Text = "$";
            // 
            // player_dollarsign1
            // 
            player_dollarsign1.AutoSize = true;
            player_dollarsign1.Font = new Font("Segoe UI", 9F);
            player_dollarsign1.Location = new Point(17, 115);
            player_dollarsign1.Name = "player_dollarsign1";
            player_dollarsign1.Size = new Size(13, 15);
            player_dollarsign1.TabIndex = 6;
            player_dollarsign1.Text = "$";
            // 
            // label_player_final
            // 
            label_player_final.AutoSize = true;
            label_player_final.Font = new Font("Segoe UI", 9F);
            label_player_final.Location = new Point(31, 151);
            label_player_final.Name = "label_player_final";
            label_player_final.Size = new Size(91, 15);
            label_player_final.TabIndex = 5;
            label_player_final.Text = "Final Chip Value";
            // 
            // label_player_bought
            // 
            label_player_bought.AutoSize = true;
            label_player_bought.Font = new Font("Segoe UI", 9F);
            label_player_bought.Location = new Point(31, 94);
            label_player_bought.Name = "label_player_bought";
            label_player_bought.Size = new Size(106, 15);
            label_player_bought.TabIndex = 4;
            label_player_bought.Text = "Amount Bought In";
            // 
            // label_player_name
            // 
            label_player_name.AutoSize = true;
            label_player_name.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_player_name.Location = new Point(31, 35);
            label_player_name.Name = "label_player_name";
            label_player_name.Size = new Size(39, 15);
            label_player_name.TabIndex = 3;
            label_player_name.Text = "Name";
            // 
            // player_name
            // 
            player_name.Location = new Point(31, 53);
            player_name.Name = "player_name";
            player_name.Size = new Size(64, 29);
            player_name.TabIndex = 1;
            // 
            // player_final
            // 
            player_final.Location = new Point(31, 169);
            player_final.Name = "player_final";
            player_final.Size = new Size(64, 29);
            player_final.TabIndex = 3;
            // 
            // player_bought
            // 
            player_bought.Location = new Point(31, 112);
            player_bought.Name = "player_bought";
            player_bought.Size = new Size(64, 29);
            player_bought.TabIndex = 2;
            // 
            // playerNumber
            // 
            playerNumber.Font = new Font("Segoe UI", 24F);
            playerNumber.Location = new Point(373, 193);
            playerNumber.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            playerNumber.Name = "playerNumber";
            playerNumber.Size = new Size(89, 50);
            playerNumber.TabIndex = 20;
            playerNumber.Value = new decimal(new int[] { 2, 0, 0, 0 });
            playerNumber.ValueChanged += playerNumber_ValueChanged;
            // 
            // playerNumber_label
            // 
            playerNumber_label.AutoSize = true;
            playerNumber_label.FlatStyle = FlatStyle.Flat;
            playerNumber_label.Font = new Font("Segoe UI", 24F);
            playerNumber_label.ForeColor = SystemColors.ControlText;
            playerNumber_label.Location = new Point(10, 195);
            playerNumber_label.Name = "playerNumber_label";
            playerNumber_label.Size = new Size(367, 45);
            playerNumber_label.TabIndex = 23;
            playerNumber_label.Text = "Enter number of players:";
            // 
            // logo
            // 
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(54, 3);
            logo.Name = "logo";
            logo.Size = new Size(375, 185);
            logo.TabIndex = 26;
            logo.TabStop = false;
            // 
            // top_panel
            // 
            top_panel.BackColor = Color.Transparent;
            top_panel.Controls.Add(logo);
            top_panel.Controls.Add(test_data);
            top_panel.Controls.Add(playerNumber);
            top_panel.Controls.Add(playerNumber_label);
            top_panel.Location = new Point(167, 10);
            top_panel.Name = "top_panel";
            top_panel.Size = new Size(465, 275);
            top_panel.TabIndex = 27;
            // 
            // PokerSquareForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 481);
            Controls.Add(top_panel);
            Controls.Add(payment_text_template);
            Controls.Add(calculate_button);
            Controls.Add(PlayerGroupTemplate);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 520);
            Name = "PokerSquareForm";
            Text = "Poker Square";
            SizeChanged += window_SizeChanged;
            PlayerGroupTemplate.ResumeLayout(false);
            PlayerGroupTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playerNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            top_panel.ResumeLayout(false);
            top_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox test_data;
        private Label payment_text_template;
        private Button calculate_button;
        private GroupBox PlayerGroupTemplate;
        private Label player_dollarsign2;
        private Label player_dollarsign1;
        private Label label_player_final;
        private Label label_player_bought;
        private Label label_player_name;
        private TextBox player_name;
        private TextBox player_final;
        private TextBox player_bought;
        private NumericUpDown playerNumber;
        private Label playerNumber_label;
        private PictureBox logo;
        private Panel top_panel;
    }
}
