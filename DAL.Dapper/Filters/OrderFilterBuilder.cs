namespace DAL.Filters
{
    public class FilterBuilder
    {
        private List<IFilter> _filters = new List<IFilter>();

        public FilterBuilder Add(params IFilter[] filters)
        {
            if (filters != null)
                _filters.AddRange(filters);

            return this;
        }

        public string BuildWhereExpression()
        {
            if (_filters.Count == 0)
                return string.Empty;

            return " WHERE " + String.Join(" AND ", _filters.Select(x => x.GetEqualityStatement()));
        }
    } 
}
