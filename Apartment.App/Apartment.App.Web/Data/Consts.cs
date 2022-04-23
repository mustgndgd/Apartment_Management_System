using System.Collections.Generic;

namespace Apartment.App.Web.Data
{
    public class Months
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
    public static class Consts
    {
        public static readonly List<Months> MonthsList =
            new List<Months>
            {
                new Months {Value = 1, Name = "Ocak"},
                new Months {Value = 2, Name = "Şubat"},
                new Months {Value = 3, Name = "Mart"},
                new Months {Value = 4, Name = "Nisan"},
                new Months {Value = 5, Name = "Mayıs"},
                new Months {Value = 6, Name = "Haziran"},
                new Months {Value = 7, Name = "Temmuz"},
                new Months {Value = 8, Name = "Ağustos"},
                new Months {Value = 9, Name = "Eylül"},
                new Months {Value = 10, Name = "Ekim"},
                new Months {Value = 11, Name = "Kasım"},
                new Months {Value = 12, Name = "Aralık"}
            };

        public static readonly List<int> YearsList =
            new List<int>
            {
                2022,
                2023,
                2024,
                2025,
                2026,
                2027,
                2028,
                2029,
                2030,
                2031,
                2032,
                2033,
                2034,
                2035
            };

    }
}
