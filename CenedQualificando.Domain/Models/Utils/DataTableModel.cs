using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Utils
{
    public class DataTableModel<TModel>
    {
        public IEnumerable<TModel> Data { get; set; } = new List<TModel>();
        public DataTableFilterModel Filter { get; set; } = new DataTableFilterModel();
        public DataTableSortingModel Sorting { get; set; } = new DataTableSortingModel();
        public DataTablePaginationModel Pagination { get; set; } = new DataTablePaginationModel();
    }

    public class DataTableSortingModel
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

    public class DataTableFilterModel
    {
        public string Search { get; set; }
    }
}