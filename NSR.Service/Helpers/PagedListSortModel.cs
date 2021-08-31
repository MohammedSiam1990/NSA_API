using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
namespace NSR.API.Helpers
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public class PagedListSortModel
    {
        public int PageIndex { get ; set; } = 0;
        public int PageSize { get; set; } = int.MaxValue;
        public string sortField { get;  set; }
        public bool? sortOrder { get;  set; }

    }
}
