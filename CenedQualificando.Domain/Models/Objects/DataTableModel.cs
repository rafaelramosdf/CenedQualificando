using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Objects
{
    public class DataTableModel<TModel>
    {
        public IEnumerable<TModel> Data { get; set; } = new List<TModel>();
        public DataTableFilterModel<TModel> Filter { get; set; } = new DataTableFilterModel<TModel>();
        public DataTableSortingModel<TModel> Sorting { get; set; } = new DataTableSortingModel<TModel>();
        public DataTablePaginationModel Pagination { get; set; } = new DataTablePaginationModel();
    }

    public class DataTableSortingModel<TModel>
    {
        public string Field { get; set; }
        public bool Desc { get; set; } = false;
    }

    public class DataTablePaginationModel
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
        public int Total { get; set; }
    }

    public class DataTableFilterModel<TModel>
    {
        public string Text { get; set; }
    }
}