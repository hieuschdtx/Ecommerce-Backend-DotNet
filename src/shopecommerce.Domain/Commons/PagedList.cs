namespace shopecommerce.Domain.Commons
{
    public class PagedList<T> : List<T>
    {
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public int total_count { get; set; }
        public int page_size { get; set; }
        public bool has_previous => current_page > 1;
        public bool has_next => current_page < total_pages;
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            total_count = count;
            page_size = pageSize;
            current_page = pageNumber;
            total_pages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}