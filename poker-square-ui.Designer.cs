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
            playerNumber_label = new Label();
            playerNumber = new NumericUpDown();
            PlayerGroupTemplate = new GroupBox();
            player_dollarsign2 = new Label();
            player_dollarsign1 = new Label();
            label_player_final = new Label();
            label_player_bought = new Label();
            label_player_name = new Label();
            player_name = new TextBox();
            player_final = new TextBox();
            player_bought = new TextBox();
            calculate_button = new Button();
            payment_text_template = new Label();
            app_panel = new Panel();
            test_data = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)playerNumber).BeginInit();
            PlayerGroupTemplate.SuspendLayout();
            app_panel.SuspendLayout();
            SuspendLayout();
            // 
            // playerNumber_label
            // 
            playerNumber_label.AutoSize = true;
            playerNumber_label.Font = new Font("Segoe UI", 24F);
            playerNumber_label.ForeColor = SystemColors.ControlText;
            playerNumber_label.Location = new Point(169, 43);
            playerNumber_label.Name = "playerNumber_label";
            playerNumber_label.Size = new Size(367, 45);
            playerNumber_label.TabIndex = 12;
            playerNumber_label.Text = "Enter number of players:";
            // 
            // playerNumber
            // 
            playerNumber.Font = new Font("Segoe UI", 24F);
            playerNumber.Location = new Point(542, 38);
            playerNumber.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            playerNumber.Name = "playerNumber";
            playerNumber.Size = new Size(89, 50);
            playerNumber.TabIndex = 0;
            playerNumber.Value = new decimal(new int[] { 2, 0, 0, 0 });
            playerNumber.ValueChanged += playerNumber_ValueChanged;
            // 
            // PlayerGroupTemplate
            // 
            PlayerGroupTemplate.Controls.Add(player_dollarsign2);
            PlayerGroupTemplate.Controls.Add(player_dollarsign1);
            PlayerGroupTemplate.Controls.Add(label_player_final);
            PlayerGroupTemplate.Controls.Add(label_player_bought);
            PlayerGroupTemplate.Controls.Add(label_player_name);
            PlayerGroupTemplate.Controls.Add(player_name);
            PlayerGroupTemplate.Controls.Add(player_final);
            PlayerGroupTemplate.Controls.Add(player_bought);
            PlayerGroupTemplate.Location = new Point(100, 133);
            PlayerGroupTemplate.Name = "PlayerGroupTemplate";
            PlayerGroupTemplate.Size = new Size(170, 200);
            PlayerGroupTemplate.TabIndex = 1;
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
            // label_player_final
            // 
            label_player_final.AutoSize = true;
            label_player_final.Location = new Point(31, 143);
            label_player_final.Name = "label_player_final";
            label_player_final.Size = new Size(91, 15);
            label_player_final.TabIndex = 5;
            label_player_final.Text = "Final Chip Value";
            // 
            // label_player_bought
            // 
            label_player_bought.AutoSize = true;
            label_player_bought.Location = new Point(31, 86);
            label_player_bought.Name = "label_player_bought";
            label_player_bought.Size = new Size(106, 15);
            label_player_bought.TabIndex = 4;
            label_player_bought.Text = "Amount Bought In";
            // 
            // label_player_name
            // 
            label_player_name.AutoSize = true;
            label_player_name.Location = new Point(31, 27);
            label_player_name.Name = "label_player_name";
            label_player_name.Size = new Size(39, 15);
            label_player_name.TabIndex = 3;
            label_player_name.Text = "Name";
            // 
            // player_name
            // 
            player_name.Location = new Point(31, 45);
            player_name.Name = "player_name";
            player_name.Size = new Size(64, 23);
            player_name.TabIndex = 1;
            // 
            // player_final
            // 
            player_final.Location = new Point(31, 161);
            player_final.Name = "player_final";
            player_final.Size = new Size(64, 23);
            player_final.TabIndex = 3;
            // 
            // player_bought
            // 
            player_bought.Location = new Point(31, 104);
            player_bought.Name = "player_bought";
            player_bought.Size = new Size(64, 23);
            player_bought.TabIndex = 2;
            // 
            // calculate_button
            // 
            calculate_button.Font = new Font("Segoe UI", 16F);
            calculate_button.Location = new Point(267, 356);
            calculate_button.Margin = new Padding(3, 20, 3, 20);
            calculate_button.Name = "calculate_button";
            calculate_button.Size = new Size(265, 52);
            calculate_button.TabIndex = 4;
            calculate_button.Text = "Calculate Payments";
            calculate_button.UseVisualStyleBackColor = true;
            calculate_button.Visible = false;
            calculate_button.Click += Calculate_Button_Click;
            // 
            // payment_text_template
            // 
            payment_text_template.AutoSize = true;
            payment_text_template.Font = new Font("Segoe UI", 16F);
            payment_text_template.Location = new Point(271, 482);
            payment_text_template.Name = "payment_text_template";
            payment_text_template.Size = new Size(189, 30);
            payment_text_template.TabIndex = 18;
            payment_text_template.Text = "player pays player";
            payment_text_template.Visible = false;
            // 
            // app_panel
            // 
            app_panel.AutoScroll = true;
            app_panel.Controls.Add(test_data);
            app_panel.Controls.Add(payment_text_template);
            app_panel.Controls.Add(calculate_button);
            app_panel.Controls.Add(PlayerGroupTemplate);
            app_panel.Controls.Add(playerNumber);
            app_panel.Controls.Add(playerNumber_label);
            app_panel.Location = new Point(1, 0);
            app_panel.Name = "app_panel";
            app_panel.Size = new Size(803, 483);
            app_panel.TabIndex = 17;
            // 
            // test_data
            // 
            test_data.AutoSize = true;
            test_data.Location = new Point(542, 94);
            test_data.Name = "test_data";
            test_data.Size = new Size(96, 19);
            test_data.TabIndex = 19;
            test_data.Text = "Use Test Data";
            test_data.UseVisualStyleBackColor = true;
            test_data.CheckedChanged += test_data_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 481);
            Controls.Add(app_panel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Poker Square";
            ((System.ComponentModel.ISupportInitialize)playerNumber).EndInit();
            PlayerGroupTemplate.ResumeLayout(false);
            PlayerGroupTemplate.PerformLayout();
            app_panel.ResumeLayout(false);
            app_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel app_panel;
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
        private CheckBox test_data;
    }
}
