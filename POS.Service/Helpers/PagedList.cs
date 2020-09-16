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
  // [Serializable]
    public class PagedList<T> //: IPagedList<T>
    {
      
        public int PageIndex { get;  set; }
        public int PageSize { get;  set; }
        public int TotalCount { get;  set; }
        public int TotalPages { get;  set; }

      // public PagedResponse PagedResponse { get;  set; }
        public List<T> Data { get; set; }
        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        } 
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, string sortField = null, bool? sortOrder = null)
        {
            if (pageSize == 0)
                pageSize = int.MaxValue;
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;

            if (!string.IsNullOrEmpty(sortField))
            {
                if (sortOrder.HasValue)
                {
                    if (sortOrder.GetValueOrDefault())
                    {
                        source = source.OrderBy(sortField);
                    }
                    else
                    {
                        source = source.OrderBy(sortField + " DESC");
                    }
                }
            }
            source = source.Skip(pageIndex * pageSize).Take(pageSize);

          //  this.AddRange(source.ToList());

            //PagedResponse = new PagedResponse();
            //PagedResponse.PageIndex = pageIndex;
            //PagedResponse.PageSize = pageSize;
            //PagedResponse.TotalCount = TotalCount;
            //PagedResponse.TotalPages = TotalCount / pageSize;
            //PagedResponse.HasPreviousPage = HasPreviousPage;
            //PagedResponse.HasNextPage = HasNextPage;
            Data = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
           // this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            if (pageSize == 0)
                pageSize = int.MaxValue;
          
            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;

            //PagedResponse = new PagedResponse();
            //PagedResponse.PageIndex = pageIndex;
            //PagedResponse.PageSize = pageSize;
            //PagedResponse.TotalCount = TotalCount;
            //PagedResponse.TotalPages = TotalCount / pageSize;
            //PagedResponse.HasPreviousPage = HasPreviousPage;
            //PagedResponse.HasNextPage = HasNextPage;
            Data = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
             // this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            if (pageSize == 0)
                pageSize = int.MaxValue;
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            

            //PagedResponse = new PagedResponse();
            //PagedResponse.PageIndex = pageIndex;
            //PagedResponse.PageSize = pageSize;
            //PagedResponse.TotalCount = TotalCount;
            //PagedResponse.TotalPages = TotalCount / pageSize;
            //PagedResponse.HasPreviousPage = HasPreviousPage;
            //PagedResponse.HasNextPage = HasNextPage;
            Data = source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            // this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());

        }

    }
}
