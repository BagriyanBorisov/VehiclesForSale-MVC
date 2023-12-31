﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesForSale.Web.ViewModels
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(ICollection<T> items, int count, int pageIndex, int pageSize) 
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            this.AddRange(items);

        }

        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;

        public static PaginatedList<T> Create(ICollection<T> source,
            int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1)*pageSize).Take(pageSize).ToList();   
            
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

    }
}
