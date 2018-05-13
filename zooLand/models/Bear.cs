using System;

namespace ConsoleApplication1.server
{
    public class Bear : Mammalia
    {
        public override void calculateFeedDate()
        {
            var month = DateTime.Now.Month;
            if (!isWinter(month) && !Hungry)
            {
                String[] feededDate = FeedDate.Split('-');
                int day = Int32.Parse(feededDate[2]);

                if (!isActivePeriod(month))
                {
                    day += 2;   
                }
                else
                {
                    day += 1;
                }
                feededDate[2] = "-" + day;
                FeedDate = feededDate[0] + '-' + feededDate[1] + feededDate[2];
            }
            if (isWinter(month))
            {
                FeedDate = DateTime.Now.Year + "-03-01";
                return;
            }
            if (Hungry)
            {
                //ToDo send message to staff
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