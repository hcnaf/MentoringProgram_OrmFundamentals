using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Filters.Implementations.Order
{
    public class MonthFilter : IFilter
    {
        private int _month;

        public MonthFilter(int month)
        {
            _month = month;
        }

        public string GetEqualityStatement() => $"month(CreatedDate) = {_month}";

    }
}
