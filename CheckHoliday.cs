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

            IsHoliday(date, year, leapYear, easter);
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

        internal void IsHoliday(DateTime date, double year, bool leapYear, DateTime easter)
        {
            string holiday = "";
            bool isHoliday = false;

            if(date == easter)
            {
                isHoliday = true;
                holiday = "Easter";
            }else
            {
                DateTime carnival;
                if (!leapYear)
                {
                    carnival = easter.AddDays(-47);
                }
                else
                {
                    carnival = easter.AddDays(-48);
                }

                if(date == carnival)
                {
                    isHoliday = true;
                    holiday = "Carnival";
                }
            }
            if(date == easter.AddDays(-2))
            {
                isHoliday = true;
                holiday = "Good Friday";

            }else if(date == easter.AddDays(60))
            {
                isHoliday = true;
                holiday = "Corpus Christi";

            }else if(date.Day == 21 && date.Month == 4)
            {
                isHoliday = true;
                holiday = "Tiradentes Holiday";

            }else if(date.Day == 1 && date.Month == 5)
            {
                isHoliday = true;
                holiday = "Worker's Day";

            }else if(date.Day == 7 && date.Month == 9)
            {
                isHoliday = true;
                holiday = "Independence of Brazil";

            }else if(date.Day == 12 && date.Month == 10)
            {
                isHoliday = true;
                holiday = "Day of Our Lady";

            }else if(date.Day == 2 && date.Month == 11)
            {
                isHoliday = true;
                holiday = "All Souls' Day";

            }else if(date.Day == 15 && date.Month == 11)
            {
                isHoliday = true;
                holiday = "Proclamation of the Republic";

            }else if(date.Day == 25 && date.Month == 12)
            {
                isHoliday = true;
                holiday = "Chrismas";

            }

            if (isHoliday)
            {
                Console.WriteLine($"The day {date.Day}/{date.Month}/{date.Year} is a Holiday: {holiday}");
            }
            else
            {
                Console.WriteLine($"The day {date.Day}/{date.Month}/{date.Year} isn't a Holiday");
            }
        }
    }
}