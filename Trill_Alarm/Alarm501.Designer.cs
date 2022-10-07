namespace Trill_Alarm
{
    partial class Alarm501
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.alarm_list = new System.Windows.Forms.ListBox();
            this.add_button = new System.Windows.Forms.Button();
            this.snooze_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.alarmwentoff_text = new System.Windows.Forms.TextBox();
            this.ux_snoozetime = new System.Windows.Forms.NumericUpDown();
            this.ux_timetext = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ux_snoozetime)).BeginInit();
            this.SuspendLayout();
            // 
            // alarm_list
            // 
            this.alarm_list.FormattingEnabled = true;
            this.alarm_list.ItemHeight = 41;
            this.alarm_list.Location = new System.Drawing.Point(78, 253);
            this.alarm_list.Name = "alarm_list";
            this.alarm_list.Size = new System.Drawing.Size(645, 496);
            this.alarm_list.TabIndex = 9;
            this.alarm_list.SelectedIndexChanged += new System.EventHandler(this.alarm_list_SelectedIndexChanged);
            // 
            // add_button
            // 
            this.add_button.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.add_button.Location = new System.Drawing.Point(479, 83);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(244, 112);
            this.add_button.TabIndex = 8;
            this.add_button.Text = "+";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // snooze_button
            // 
            this.snooze_button.Enabled = false;
            this.snooze_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.snooze_button.Location = new System.Drawing.Point(78, 900);
            this.snooze_button.Name = "snooze_button";
            this.snooze_button.Size = new System.Drawing.Size(244, 112);
            this.snooze_button.TabIndex = 7;
            this.snooze_button.Text = "Snooze";
            this.snooze_button.UseVisualStyleBackColor = true;
            this.snooze_button.Click += new System.EventHandler(this.snooze_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Enabled = false;
            this.stop_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stop_button.Location = new System.Drawing.Point(479, 900);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(244, 112);
            this.stop_button.TabIndex = 6;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Enabled = false;
            this.edit_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.edit_button.Location = new System.Drawing.Point(78, 83);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(244, 112);
            this.edit_button.TabIndex = 5;
            this.edit_button.Text = "Edit";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // alarmwentoff_text
            // 
            this.alarmwentoff_text.BackColor = System.Drawing.SystemColors.MenuBar;
            this.alarmwentoff_text.Enabled = false;
            this.alarmwentoff_text.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.alarmwentoff_text.Location = new System.Drawing.Point(78, 800);
            this.alarmwentoff_text.Name = "alarmwentoff_text";
            this.alarmwentoff_text.Size = new System.Drawing.Size(645, 62);
            this.alarmwentoff_text.TabIndex = 10;
            this.alarmwentoff_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ux_snoozetime
            // 
            this.ux_snoozetime.Location = new System.Drawing.Point(113, 1018);
            this.ux_snoozetime.Name = "ux_snoozetime";
            this.ux_snoozetime.Size = new System.Drawing.Size(101, 47);
            this.ux_snoozetime.TabIndex = 11;
            // 
            // ux_timetext
            // 
            this.ux_timetext.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ux_timetext.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ux_timetext.Location = new System.Drawing.Point(220, 1018);
            this.ux_timetext.Name = "ux_timetext";
            this.ux_timetext.Size = new System.Drawing.Size(78, 47);
            this.ux_timetext.TabIndex = 12;
            this.ux_timetext.Text = "min.";
            // 
            // Alarm501
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1095);
            this.Controls.Add(this.ux_timetext);
            this.Controls.Add(this.ux_snoozetime);
            this.Controls.Add(this.alarmwentoff_text);
            this.Controls.Add(this.alarm_list);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.snooze_button);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.edit_button);
            this.Name = "Alarm501";
            this.Text = "Alarm501";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Alarm501_FormClosing);
            this.Load += new System.EventHandler(this.Alarm501_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ux_snoozetime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ListBox alarm_list;
        public Button add_button;
        public Button snooze_button;
        public Button stop_button;
        public Button edit_button;
        public TextBox alarmwentoff_text;
        private TextBox ux_timetext;
        public NumericUpDown ux_snoozetime;
    }
}