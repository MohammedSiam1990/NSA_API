
using System.Collections.Generic;

namespace POS.API.Helpers
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public  class PagedResponse
    {
      public  int  PageIndex { get; set; }
      public  int PageSize { get; set;}
      public  int TotalCount { get;set; }
      public  int TotalPages { get;set; }
      public  bool HasPreviousPage { get; set;}
      public  bool HasNextPage { get; set; }
    }
}
