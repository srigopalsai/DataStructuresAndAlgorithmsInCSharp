using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    //Design time data type and implement some add functions.
    class Time
    {
        int hour;
        int minute;
        //int second;
        public Time()
        {
            hour = 0;
            minute = 0;
            //second = 0;
        }
        public void AddHour(int _hour)
        {
            hour += _hour;
        }
        public void AddMinute(int _minutes)
        {
            int _hrs = _minutes / 60;
            int _mns = _minutes % 60;
            hour += _hrs;
            minute += _mns;

            if (minute > 60)
            {
                _hrs = minute / 60;
                hour += _hrs;
            }
        }
    }
}