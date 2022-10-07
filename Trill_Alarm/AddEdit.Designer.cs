namespace Trill_Alarm
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
            this.ux_chickenAlarm = new System.Windows.Forms.CheckBox();
            this.ux_noiseAlarm = new System.Windows.Forms.CheckBox();
            this.ux_subwayAlarm = new System.Windows.Forms.CheckBox();
            this.ux_sirenAlarm = new System.Windows.Forms.CheckBox();
            this.ux_dogAlarm = new System.Windows.Forms.CheckBox();
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
            this.cancel_button.Location = new System.Drawing.Point(72, 278);
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
            this.set_button.Location = new System.Drawing.Point(455, 278);
            this.set_button.Name = "set_button";
            this.set_button.Size = new System.Drawing.Size(232, 103);
            this.set_button.TabIndex = 4;
            this.set_button.Text = "Set";
            this.set_button.UseVisualStyleBackColor = true;
            this.set_button.Click += new System.EventHandler(this.set_button_Click);
            // 
            // ux_chickenAlarm
            // 
            this.ux_chickenAlarm.AutoSize = true;
            this.ux_chickenAlarm.Location = new System.Drawing.Point(72, 116);
            this.ux_chickenAlarm.Name = "ux_chickenAlarm";
            this.ux_chickenAlarm.Size = new System.Drawing.Size(268, 45);
            this.ux_chickenAlarm.TabIndex = 5;
            this.ux_chickenAlarm.Text = "Chicken Sounds";
            this.ux_chickenAlarm.UseVisualStyleBackColor = true;
            this.ux_chickenAlarm.CheckedChanged += new System.EventHandler(this.ux_chickenAlarm_CheckedChanged);
            // 
            // ux_noiseAlarm
            // 
            this.ux_noiseAlarm.AutoSize = true;
            this.ux_noiseAlarm.Location = new System.Drawing.Point(458, 116);
            this.ux_noiseAlarm.Name = "ux_noiseAlarm";
            this.ux_noiseAlarm.Size = new System.Drawing.Size(218, 45);
            this.ux_noiseAlarm.TabIndex = 6;
            this.ux_noiseAlarm.Text = "White Noise";
            this.ux_noiseAlarm.UseVisualStyleBackColor = true;
            this.ux_noiseAlarm.CheckedChanged += new System.EventHandler(this.ux_noiseAlarm_CheckedChanged);
            // 
            // ux_subwayAlarm
            // 
            this.ux_subwayAlarm.AutoSize = true;
            this.ux_subwayAlarm.Location = new System.Drawing.Point(72, 218);
            this.ux_subwayAlarm.Name = "ux_subwayAlarm";
            this.ux_subwayAlarm.Size = new System.Drawing.Size(229, 45);
            this.ux_subwayAlarm.TabIndex = 7;
            this.ux_subwayAlarm.Text = "Busy Subway";
            this.ux_subwayAlarm.UseVisualStyleBackColor = true;
            this.ux_subwayAlarm.CheckedChanged += new System.EventHandler(this.ux_subwayAlarm_CheckedChanged);
            // 
            // ux_sirenAlarm
            // 
            this.ux_sirenAlarm.AutoSize = true;
            this.ux_sirenAlarm.Location = new System.Drawing.Point(458, 218);
            this.ux_sirenAlarm.Name = "ux_sirenAlarm";
            this.ux_sirenAlarm.Size = new System.Drawing.Size(234, 45);
            this.ux_sirenAlarm.TabIndex = 8;
            this.ux_sirenAlarm.Text = "Blaring Sirens";
            this.ux_sirenAlarm.UseVisualStyleBackColor = true;
            this.ux_sirenAlarm.CheckedChanged += new System.EventHandler(this.ux_sirenAlarm_CheckedChanged);
            // 
            // ux_dogAlarm
            // 
            this.ux_dogAlarm.AutoSize = true;
            this.ux_dogAlarm.Location = new System.Drawing.Point(266, 167);
            this.ux_dogAlarm.Name = "ux_dogAlarm";
            this.ux_dogAlarm.Size = new System.Drawing.Size(220, 45);
            this.ux_dogAlarm.TabIndex = 9;
            this.ux_dogAlarm.Text = "Dog Barking";
            this.ux_dogAlarm.UseVisualStyleBackColor = true;
            this.ux_dogAlarm.CheckedChanged += new System.EventHandler(this.ux_dogAlarm_CheckedChanged);
            // 
            // AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ux_dogAlarm);
            this.Controls.Add(this.ux_sirenAlarm);
            this.Controls.Add(this.ux_subwayAlarm);
            this.Controls.Add(this.ux_noiseAlarm);
            this.Controls.Add(this.ux_chickenAlarm);
            this.Controls.Add(this.set_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.check_on);
            this.Controls.Add(this.time_select);
            this.Name = "AddEdit";
            this.Text = "AddEdit";
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
    }
}