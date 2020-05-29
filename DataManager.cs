using System;
using System.Linq;

namespace Solution
{
    public class DataManager
    {
        public static void OldQuoteRemover(QuotesContext context)
        {
            DateTime currentDate = DateTime.Now.Date;

            foreach(var item in context.Quotes)
            {
                if((DateTime.Now.Date - item.InsertDate.Date).Days > 31)
                {
                    context.Quotes.Remove(item);
                }
            }
            context.SaveChanges();
        }
    }
}