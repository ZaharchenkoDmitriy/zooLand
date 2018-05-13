using System;
using ConsoleApplication1.DataBase;

namespace ConsoleApplication1.server
{
    public class Lion : Mammalia
    {
        public override void calculateFeedDate()
        {
            if (isActivePeriod())
            {
                FeedDate = DateFormatter.addDays(FeedDate, 2);
            }
            else
            {
                FeedDate = DateFormatter.addDays(FeedDate, 1);
            }
        }

        private bool isActivePeriod()
        {
            return true;
        }
    }
}