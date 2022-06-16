using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Filters.Implementations.Order
{
    public class YearFilter : IFilter
    {
        private int _year;

        public YearFilter(int year)
        {
            _year = year;
        }

        public string GetEqualityStatement() => $"year(CreatedDate) = {_year}";

    }
}
