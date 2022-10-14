using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Alarm_Library
{
    public class Alarm
    {
        /// <summary>
        /// Gives all the different status's.
        /// </summary>
        public enum State
        {
            ON,
            OFF,
            GOING_OFF,
            STOPPED,
            SNOOZE
        };

        public enum AlarmSound
        {
            CHICKEN,
            NOISE,
            BARKING,
            SUBWAY,
            SIRENS,
            NONE
        }

        public State Status;

        public AlarmSound Sound;

        /// <summary>
        /// This is the time of the alarm.
        /// </summary>
        public DateTime Time;

        /// <summary>
        /// This is the constructor for the Alarm class.
        /// </summary>
        /// <param name="time">This is the time of the alarm.</param>
        /// <param name="status">This is whether or not the alarm is running.</param>
        public Alarm(DateTime time, State status, AlarmSound sound)
        {
            Time = time;
            Status = status;
            Sound = sound;
        }

        public Alarm()
        {
            Time = DateTime.Now;
            Status = State.OFF;
            Sound = AlarmSound.NONE;
        }
    }
}
