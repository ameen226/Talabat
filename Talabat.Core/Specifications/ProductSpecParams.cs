using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Specifications
{
    public class ProductSpecParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        private int _pageSize = 5;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > 10 ? 10 : value; }
        }

        public int PageIndex { get; set; } = 1;

        private string? _search;

        public string? Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }

    }
}
