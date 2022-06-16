using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Filters.Implementations.Order
{
    public class ProductIdFilter : IFilter
    {
        private Guid _guid;
        public ProductIdFilter(Guid guid)
        {
            _guid = guid;
        }

        public string GetEqualityStatement() => $"ProductId = '{_guid}";
    }
}
