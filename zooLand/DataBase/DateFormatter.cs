using System;
using System.Runtime.CompilerServices;

namespace ConsoleApplication1.DataBase
{
    public static class DateFormatter
    {
        public static string getCurrentDate()
        {
            return DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
        }

        public static string addDays(string date, int days)
        {
            if (days < 0) return date;
            
            String[] feededDate = date.Split('-');
            int day = Int32.Parse(feededDate[2]);
            int month = Int32.Parse(feededDate[1]);
            int year = Int32.Parse(feededDate[0]);
            
            DateTime dateTime = new DateTime(year, month, day);
            dateTime.AddDays(days);
            
            return dateTime.Year + "-" + dateTime.Month+ "-" + dateTime.Day;
        }
    }
}