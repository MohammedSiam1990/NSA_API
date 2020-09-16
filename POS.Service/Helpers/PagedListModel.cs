using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
namespace POS.API.Helpers
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public class PagedListModel
    {
        public int PageIndex { get ; set; } = 0;
        public int PageSize { get; set; } = int.MaxValue;

    }
}
