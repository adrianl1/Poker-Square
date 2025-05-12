namespace Poker_Square
{
    partial class Form1
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
            Calculate_Button = new Button();
            PlayerGroupTemplate = new GroupBox();
            player_dollarsign2 = new Label();
            player_dollarsign1 = new Label();
            player_final_label = new Label();
            player_buyin_label = new Label();
            playerName_1 = new Label();
            player_name_text = new TextBox();
            player_final_text = new TextBox();
            player_bought_text = new TextBox();
            submit_playerNumber = new Button();
            playerNumber = new NumericUpDown();
            playerNumber_label = new Label();
            app_panel = new Panel();
            PlayerGroupTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playerNumber).BeginInit();
            app_panel.SuspendLayout();
            SuspendLayout();
            // 
            // Calculate_Button
            // 
            Calculate_Button.Font = new Font("Segoe UI", 16F);
            Calculate_Button.Location = new Point(271, 384);
            Calculate_Button.Name = "Calculate_Button";
            Calculate_Button.Size = new Size(265, 52);
            Calculate_Button.TabIndex = 16;
            Calculate_Button.Text = "Calculate Payments";
            Calculate_Button.UseVisualStyleBackColor = true;
            Calculate_Button.Visible = false;
            // 
            // PlayerGroupTemplate
            // 
            PlayerGroupTemplate.Controls.Add(player_dollarsign2);
            PlayerGroupTemplate.Controls.Add(player_dollarsign1);
            PlayerGroupTemplate.Controls.Add(player_final_label);
            PlayerGroupTemplate.Controls.Add(player_buyin_label);
            PlayerGroupTemplate.Controls.Add(playerName_1);
            PlayerGroupTemplate.Controls.Add(player_name_text);
            PlayerGroupTemplate.Controls.Add(player_final_text);
            PlayerGroupTemplate.Controls.Add(player_bought_text);
            PlayerGroupTemplate.Location = new Point(100, 133);
            PlayerGroupTemplate.Name = "PlayerGroupTemplate";
            PlayerGroupTemplate.Size = new Size(170, 200);
            PlayerGroupTemplate.TabIndex = 15;
            PlayerGroupTemplate.TabStop = false;
            PlayerGroupTemplate.Text = "Player";
            PlayerGroupTemplate.Visible = false;
            // 
            // player_dollarsign2
            // 
            player_dollarsign2.AutoSize = true;
            player_dollarsign2.Location = new Point(21, 164);
            player_dollarsign2.Name = "player_dollarsign2";
            player_dollarsign2.Size = new Size(13, 15);
            player_dollarsign2.TabIndex = 7;
            player_dollarsign2.Text = "$";
            // 
            // player_dollarsign1
            // 
            player_dollarsign1.AutoSize = true;
            player_dollarsign1.Location = new Point(21, 107);
            player_dollarsign1.Name = "player_dollarsign1";
            player_dollarsign1.Size = new Size(13, 15);
            player_dollarsign1.TabIndex = 6;
            player_dollarsign1.Text = "$";
            // 
            // player_final_label
            // 
            player_final_label.AutoSize = true;
            player_final_label.Location = new Point(31, 143);
            player_final_label.Name = "player_final_label";
            player_final_label.Size = new Size(91, 15);
            player_final_label.TabIndex = 5;
            player_final_label.Text = "Final Chip Value";
            // 
            // player_buyin_label
            // 
            player_buyin_label.AutoSize = true;
            player_buyin_label.Location = new Point(31, 86);
            player_buyin_label.Name = "player_buyin_label";
            player_buyin_label.Size = new Size(106, 15);
            player_buyin_label.TabIndex = 4;
            player_buyin_label.Text = "Amount Bought In";
            // 
            // playerName_1
            // 
            playerName_1.AutoSize = true;
            playerName_1.Location = new Point(31, 27);
            playerName_1.Name = "playerName_1";
            playerName_1.Size = new Size(39, 15);
            playerName_1.TabIndex = 3;
            playerName_1.Text = "Name";
            // 
            // player_name_text
            // 
            player_name_text.Location = new Point(31, 45);
            player_name_text.Name = "player_name_text";
            player_name_text.Size = new Size(64, 23);
            player_name_text.TabIndex = 2;
            // 
            // player_final_text
            // 
            player_final_text.Location = new Point(31, 161);
            player_final_text.Name = "player_final_text";
            player_final_text.Size = new Size(64, 23);
            player_final_text.TabIndex = 1;
            // 
            // player_bought_text
            // 
            player_bought_text.Location = new Point(31, 104);
            player_bought_text.Name = "player_bought_text";
            player_bought_text.Size = new Size(64, 23);
            player_bought_text.TabIndex = 0;
            // 
            // submit_playerNumber
            // 
            submit_playerNumber.Font = new Font("Segoe UI", 16F);
            submit_playerNumber.Location = new Point(599, 28);
            submit_playerNumber.Name = "submit_playerNumber";
            submit_playerNumber.Size = new Size(89, 52);
            submit_playerNumber.TabIndex = 14;
            submit_playerNumber.Text = "Submit";
            submit_playerNumber.UseVisualStyleBackColor = true;
            submit_playerNumber.Click += submit_playerNumber_Click;
            // 
            // playerNumber
            // 
            playerNumber.Font = new Font("Segoe UI", 24F);
            playerNumber.Location = new Point(504, 28);
            playerNumber.Name = "playerNumber";
            playerNumber.Size = new Size(89, 50);
            playerNumber.TabIndex = 13;
            // 
            // playerNumber_label
            // 
            playerNumber_label.AutoSize = true;
            playerNumber_label.Font = new Font("Segoe UI", 24F);
            playerNumber_label.Location = new Point(131, 28);
            playerNumber_label.Name = "playerNumber_label";
            playerNumber_label.Size = new Size(367, 45);
            playerNumber_label.TabIndex = 12;
            playerNumber_label.Text = "Enter number of players:";
            // 
            // app_panel
            // 
            app_panel.AutoScroll = true;
            app_panel.Controls.Add(Calculate_Button);
            app_panel.Controls.Add(PlayerGroupTemplate);
            app_panel.Controls.Add(submit_playerNumber);
            app_panel.Controls.Add(playerNumber);
            app_panel.Controls.Add(playerNumber_label);
            app_panel.Location = new Point(1, 0);
            app_panel.Name = "app_panel";
            app_panel.Size = new Size(800, 482);
            app_panel.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 479);
            Controls.Add(app_panel);
            Name = "Form1";
            Text = "Poker Square";
            PlayerGroupTemplate.ResumeLayout(false);
            PlayerGroupTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playerNumber).EndInit();
            app_panel.ResumeLayout(false);
            app_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Calculate_Button;
        private GroupBox PlayerGroupTemplate;
        private Label player_dollarsign2;
        private Label player_dollarsign1;
        private Label player_final_label;
        private Label player_buyin_label;
        private Label playerName_1;
        private TextBox player_name_text;
        private TextBox player_final_text;
        private TextBox player_bought_text;
        private Button submit_playerNumber;
        private NumericUpDown playerNumber;
        private Label playerNumber_label;
        private Panel app_panel;
    }
}
