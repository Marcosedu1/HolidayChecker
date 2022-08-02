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
            int year = Convert.ToInt32(date.Year);

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

        private static DateTime PickingEaster(int easterYear)
        {
            int lunarCyclePosition = easterYear % 19;
            int century = easterYear / 100;
            int daysBetweenEquinoxAndFullmoon = (century - (int)(century / 4) - (int)((8 * century + 13) / 25) + 19 * lunarCyclePosition + 15) % 30;
            int daysBetweenFullmoonAndFirstSunday = daysBetweenEquinoxAndFullmoon - (int)(daysBetweenEquinoxAndFullmoon / 28) * (1 - (int)(daysBetweenEquinoxAndFullmoon / 28) * (int)(29 / (daysBetweenEquinoxAndFullmoon + 1)) * (int)((21 - lunarCyclePosition) / 11));

            int easterDay = daysBetweenFullmoonAndFirstSunday - ((easterYear + (int)(easterYear / 4) + daysBetweenFullmoonAndFirstSunday + 2 - century + (int)(century / 4)) % 7) + 28;
            int easterMonth = 3;

            if (easterDay > 31)
            {
                easterMonth++;
                easterDay -= 31;
            }

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