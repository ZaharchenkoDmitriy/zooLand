using System;
using ConsoleApplication1.DataBase;

namespace ConsoleApplication1.server
{
    public class Bear : Mammalia
    {
        public override void calculateFeedDate()
        {
            
            var month = DateTime.Now.Month;
            if (!isWinter(month) && !Hungry)
            {                
                if (!isActivePeriod(month))
                {
                    FeedDate = DateFormatter.addDays(FeedDate, 2);
                }
                else
                {
                    FeedDate = DateFormatter.addDays(FeedDate, 1);
                }           
            }
            if (isWinter(month))
            {
                FeedDate = DateTime.Now.Year + "-03-01";
                return;
            }
            if (Hungry)
            {
                FeedDate = DateFormatter.getCurrentDate();
            }
        }

        private bool isWinter(int month)
        {
            return month == 12 || month == 1 || month == 2;
        }

        private bool isActivePeriod(int month)
        {
            return month == 11 || month == 3;
        }
    }
}