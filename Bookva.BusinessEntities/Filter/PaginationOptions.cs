namespace Bookva.BusinessEntities.Filter
{
    public class PaginationOptions
    {
        private int page;
        private int pageSize;
        private string fieldName;

        public PaginationOptions()
        {
            pageSize = 10;
            page = 1;
        }
        public int Page
        {
            get { return page; }
            set { page = value > 0 ? value: 10; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value >0 ? value : 1; }
        }

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value ?? "Id"; }
        }

        public SortOrder Order { get; set; }
    }
}
