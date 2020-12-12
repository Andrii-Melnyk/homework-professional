using System;
using System.Collections;
using System.Linq;

namespace Task1
{
    class Calendar : IEnumerable
    {
        private readonly string[] months = {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"
        };
        private readonly int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < months.Length; i++)
            {
                yield return String.Format($"{i + 1} {months[i]} - {days[i]}");
            }
        }
        public string GetMonthByNumber(int monthNumber)
        {
            string resalt = default;
            if (monthNumber > 0 && monthNumber < 13)
            {
                for (int i = 0; i < months.Length; i++)
                {
                    if (i + 1 == monthNumber)
                        resalt = String.Format($"{i + 1} {months[i]} - {days[i]}");
                }
            }
            else
            {
                resalt = "Месяца с таким номером в коллекции нет";
            }
            return resalt;
        }
        public IEnumerable GetMontshByDaysCount(int daysCount)
        {
            return days.Select((x, i) => new { Element = x, Index = i }).Where(x => x.Element == daysCount)
                   .Select((x) => String.Format($"{x.Index + 1} {months[x.Index]} - {x.Element}"));
        }
    }
}
