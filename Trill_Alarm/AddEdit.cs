using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trill_Alarm
{
    public partial class AddEdit : Form
    {
        //// Delegates from Controller ////

        /// <summary>
        /// This is the helper for the SetButtonClick
        /// </summary>
        SetEventHelper_DEL set_helper;
        
        /// <summary>
        /// This is the helper to enable and disable checkboxes when Chicken Sounds is chosen.
        /// </summary>
        ChickenChangedHelper_DEL chicken_helper;

        /// <summary>
        /// This is the helper to enable and disable checkboxes when White Noise is chosen.
        /// </summary>
        NoiseChangedHelper_DEL noise_helper;

        /// <summary>
        /// This is the helper to enable and disable checkboxes when Dog Barking is chosen.
        /// </summary>
        DogChangedHelper_DEL dog_helper;

        /// <summary>
        /// This is the helper to enable and disable checkboxes when Busy Subway is chosen.
        /// </summary>
        SubwayChangedHelper_DEL subway_helper;

        /// <summary>
        /// This is the helper to enable and disable checkboxes when Blaring Siren is chosen.
        /// </summary>
        SirenChangedHelper_DEL siren_helper;

        ///////////////////////////////////

        /// <summary>
        /// This check for an alarm edit.
        /// </summary>
        public bool reset;

        /// <summary>
        /// This is the constructor.
        /// </summary>
        /// <param name="alarm">This is the alarm form reference.</param>
        public AddEdit()
        {
            InitializeComponent();
            time_select.Format = DateTimePickerFormat.Time;
        }

        /// <summary>
        /// This is the AddEdit SetContructor.
        /// 
        /// This adds the references to the delegates.
        /// </summary>
        /// <param name="chicken_h">This is the CheckenChangedHelper Delegate.</param>
        /// <param name="noise_h">This is the NoiseChangedHelper Delegate.</param>
        /// <param name="dog_h">This is the DogChangedHelper Delegate.</param>
        /// <param name="subway_h">This is the SubwayChangedHelper Delegate.</param>
        /// <param name="siren_h">This is the SirenChangedHelper Delegate.</param>
        /// <param name="set_h">This is the SetEventHelper Delegate.</param>
        public void SetConstructor(ChickenChangedHelper_DEL chicken_h, NoiseChangedHelper_DEL noise_h, DogChangedHelper_DEL dog_h,
            SubwayChangedHelper_DEL subway_h, SirenChangedHelper_DEL siren_h, SetEventHelper_DEL set_h)
        {
            chicken_helper = chicken_h;
            noise_helper = noise_h;
            dog_helper = dog_h;
            subway_helper = subway_h;
            siren_helper = siren_h;
            set_helper = set_h;
        }

        /// <summary>
        /// Event handler for the cancel button.
        /// </summary>
        /// <param name="sender">This is the cancel button.</param>
        /// <param name="e">These are the arguments.</param>
        private void cancel_button_Click(object sender, EventArgs e) { this.Hide(); }

        /// <summary>
        /// Event handler for the set button.
        /// </summary>
        /// <param name="sender">This is the set button.</param>
        /// <param name="e">These are the arguments.</param>
        private void set_button_Click(object sender, EventArgs e)
        {
            time_select.Format = DateTimePickerFormat.Custom;
            time_select.CustomFormat = "hh:mm:ss tt";
            set_helper();
        }

        /// <summary>
        /// This sets the time_select value.
        /// </summary>
        /// <param name="t">This is the value to change to.</param>
        public void SetTime(DateTime t)
        {
            time_select.Value = t;
            // reset = true;
        }

        /// <summary>
        /// This hides the view.
        /// </summary>
        public void HideView() { this.Hide(); }

        /// <summary>
        /// The retrieves the time_select value.
        /// </summary>
        /// <returns>Returns the DateTime from the value.</returns>
        public DateTime GetTimeSelectValue() { return time_select.Value; }

        /// <summary>
        /// Event for when the Chicken Sounds checkbox is changed.
        /// </summary>
        /// <param name="sender">This is the checkbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_chickenAlarm_CheckedChanged(object sender, EventArgs e) { chicken_helper(); }

        /// <summary>
        /// Event for when the White Noise checkbox is changed.
        /// </summary>
        /// <param name="sender">This is the checkbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_noiseAlarm_CheckedChanged(object sender, EventArgs e) { noise_helper(); }

        /// <summary>
        /// Event for when the Dog Barking checkbox is changed.
        /// </summary>
        /// <param name="sender">This is the checkbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_dogAlarm_CheckedChanged(object sender, EventArgs e) { dog_helper(); }

        /// <summary>
        /// Event for when the Busy Subway checkbox is changed.
        /// </summary>
        /// <param name="sender">This is the checkbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_subwayAlarm_CheckedChanged(object sender, EventArgs e) { subway_helper(); }

        /// <summary>
        /// Event for when the Blaring Sirens checkbox is changed.
        /// </summary>
        /// <param name="sender">This is the checkbox.</param>
        /// <param name="e">These are the arguments.</param>
        private void ux_sirenAlarm_CheckedChanged(object sender, EventArgs e) { siren_helper(); }

        /// <summary>
        /// Retrieves whether or not the On checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool CheckedChanged() { return check_on.Checked; }

        /// <summary>
        /// Retrieves whether or not the Chicken Sounds checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool ChickenChecked() { return ux_chickenAlarm.Checked; }

        /// <summary>
        /// Retrieves whether or not the White Noise checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool NoiseChecked() { return ux_noiseAlarm.Checked; }

        /// <summary>
        /// Retrieves whether or not the Dog Barking checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool DogChecked() { return ux_dogAlarm.Checked; }

        /// <summary>
        /// Retrieves whether or not the Busy Subway checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool SubwayChecked() { return ux_subwayAlarm.Checked; }

        /// <summary>
        /// Retrieves whether or not the Blaring Sirens checkbox is checked
        /// </summary>
        /// <returns>Returns whether or not the checkbox is checked,</returns>
        public bool SirenChecked() { return ux_sirenAlarm.Checked; }

        /// <summary>
        /// Changes the enabled value of the On checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void CheckedOnOff(bool b) { check_on.Checked = b; }

        /// <summary>
        /// Changes the enabled value of the Chicken Sounds checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void ChickenOnOff(bool b) { ux_chickenAlarm.Enabled = b; }

        /// <summary>
        /// Changes the enabled value of the White Noise checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void NoiseOnOff(bool b) { ux_noiseAlarm.Enabled = b; }

        /// <summary>
        /// Changes the enabled value of the Dog Barking checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void DogOnOff(bool b) { ux_dogAlarm.Enabled = b; }

        /// <summary>
        /// Changes the enabled value of the Busy Subway checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void SubwayOnOff(bool b) { ux_subwayAlarm.Enabled = b; }

        /// <summary>
        /// Changes the enabled value of the Blaring Sirens checkbox.
        /// </summary>
        /// <param name="b">This is the value to change the enabled property to.</param>
        public void SirenOnOff(bool b) { ux_sirenAlarm.Enabled = b; }
    }
}
