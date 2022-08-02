namespace CheckIsHoliday
{
    internal class CheckHoliday
    {
        public CheckHoliday(DateTime Date)
        {
            date = Date;
        }

        private DateTime date { get; }

        internal void CheckIsHoliday()
        {
            double year = Convert.ToDouble(date.Year);

            Console.WriteLine("\nChecking Now...");

            DateTime easter = PickingEaster(year);
            bool leapYear = isLeapYear(year);

            DateTime carnival = !leapYear? easter.AddDays(-47) : easter.AddDays(-48);

            List<Holiday> holidays = new List<Holiday>
            {
                new Holiday(easter.Day,easter.Month,"Easter"),
                new Holiday(carnival.Day,carnival.Month, "Carnival"),
                new Holiday(easter.AddDays(-2).Day,easter.AddDays(-2).Month,"Good Friday"),
                new Holiday(easter.AddDays(60).Day,easter.AddDays(60).Month,"Corpus Christi"),
                new Holiday(21,4,"Tiradentes Holiday"),
                new Holiday(7,9, "Independence of Brazil"),
                new Holiday(12,10,"Day of Our Lady"),
                new Holiday(2,11, "All Souls' Day"),
                new Holiday(15,11, "Proclamation of the Republic"),
                new Holiday(25,12, "Chrismas"),
            };

            IsHoliday(date, holidays);
        }

        private bool isLeapYear(double year)
        {
            if((year % 400) == 0)
            {
                return true;
            }
            else
            {
                if((year % 100) == 0)
                {
                    return false;
                }
                else
                {
                    if((year % 4) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private static DateTime PickingEaster(double year)
        {
            double A = (int)(year % 19);
            double B = (int)Math.Floor(year / 100);
            double C = (int)(year % 100);
            double D = (int)(B / 4);
            double E = (int)(B % 4);
            double F = (int)Math.Floor(B + 8) / 25;
            double G = (int)Math.Floor(1 + B - F) / 3;
            double H = (int)((19 * A) + B + 15 - (D + G)) % 30;
            double I = (int)Math.Floor(C / 4);
            double K = (int)(C % 4);
            double L = (int)(32 + (2 * E) + (2 * I) - (H + K)) % 7;
            double M = (int)Math.Floor(((A + (11 * H) + (22 * L)) / 451));

            int easterMonth = (int)Math.Floor(((H + L + 114 - (7 * M)) / 31));
            int easterDay = (int)((H + L + 114 - (7 * M)) % 31) + 1;
            int easterYear = Convert.ToInt32(year);

            DateTime easter = new DateTime(easterYear,easterMonth,easterDay);

            return easter;
        }

        internal void IsHoliday(DateTime date, List<Holiday> holidays)
        {
            string holidayName = "";
            bool isHoliday = false;

            foreach (var holiday in holidays)
            {
                if (date.Day == holiday.Day && date.Month == holiday.Month)
                {
                    isHoliday = true;
                    holidayName = holiday.HolidayName;
                    break;
                }
            }

            if (isHoliday)
            {
                Console.WriteLine($"The day {date.Day}/{date.Month}/{date.Year} is a Holiday: {holidayName}");
            }
            else
            {
                Console.WriteLine($"The day {date.Day}/{date.Month}/{date.Year} isn't a Holiday");
            }
        }
    }

    class Holiday
    {
        public Holiday(int day, int month, string holiday)
        {
            Day = day;
            Month = month;
            HolidayName = holiday;
        }

        public int Day { get; private set; }
        public int Month { get; private set; }
        public string HolidayName { get; private set; }

    }
}