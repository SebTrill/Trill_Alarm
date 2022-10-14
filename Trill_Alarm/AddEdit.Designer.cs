namespace Alarm_GUI
{
    partial class AddEdit
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
            this.time_select = new System.Windows.Forms.DateTimePicker();
            this.check_on = new System.Windows.Forms.CheckBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.set_button = new System.Windows.Forms.Button();
            this.sound_dropdown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // time_select
            // 
            this.time_select.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_select.Location = new System.Drawing.Point(72, 49);
            this.time_select.Name = "time_select";
            this.time_select.Size = new System.Drawing.Size(500, 47);
            this.time_select.TabIndex = 1;
            // 
            // check_on
            // 
            this.check_on.AutoSize = true;
            this.check_on.Location = new System.Drawing.Point(591, 53);
            this.check_on.Name = "check_on";
            this.check_on.Size = new System.Drawing.Size(96, 45);
            this.check_on.TabIndex = 2;
            this.check_on.Text = "On";
            this.check_on.UseVisualStyleBackColor = true;
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancel_button.Location = new System.Drawing.Point(69, 214);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(232, 103);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // set_button
            // 
            this.set_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.set_button.Location = new System.Drawing.Point(455, 214);
            this.set_button.Name = "set_button";
            this.set_button.Size = new System.Drawing.Size(232, 103);
            this.set_button.TabIndex = 4;
            this.set_button.Text = "Set";
            this.set_button.UseVisualStyleBackColor = true;
            this.set_button.Click += new System.EventHandler(this.set_button_Click);
            // 
            // sound_dropdown
            // 
            this.sound_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sound_dropdown.FormattingEnabled = true;
            this.sound_dropdown.Location = new System.Drawing.Point(69, 124);
            this.sound_dropdown.Name = "sound_dropdown";
            this.sound_dropdown.Size = new System.Drawing.Size(302, 49);
            this.sound_dropdown.TabIndex = 10;
            // 
            // AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.sound_dropdown);
            this.Controls.Add(this.set_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.check_on);
            this.Controls.Add(this.time_select);
            this.Name = "AddEdit";
            this.Text = "AddEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEdit_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button cancel_button;
        public CheckBox check_on;
        public Button set_button;
        public DateTimePicker time_select;
        private CheckBox ux_chickenAlarm;
        private CheckBox ux_noiseAlarm;
        private CheckBox ux_subwayAlarm;
        private CheckBox ux_sirenAlarm;
        private CheckBox ux_dogAlarm;
        private ComboBox sound_dropdown;
    }
}