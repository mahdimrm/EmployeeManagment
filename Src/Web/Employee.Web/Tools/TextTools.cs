namespace Employee.Web.Tools
{
    using System;
    using System.Globalization;

    public static class TextTools
    {
        public static string ToPersianDate(this DateTime dateTime)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                string time = $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime).ToString("#0,#")}/{pc.GetDayOfMonth(dateTime).ToString("#0,#")}";
                return time;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string HowLongHeIntoMilitaryServices(this DateTime employedDateTime)
        {

            DateTime current = DateTime.Now;
            TimeSpan date = current - employedDateTime;
            DateTime howLong = DateTime.MinValue + date;

            int year = howLong.Year - 1;
            int month = howLong.Month - 1;
            int day = howLong.Day - 1;

            return $" {year} سال ,  {month} ماه ,  {day} روز";
        }
    }
}
