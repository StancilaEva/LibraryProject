﻿using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Paging
{
    public class FavoritePage
    {
        public List<ComicBook> Comics { get; set; }
        public int PageCount { get; set; }
    }
}
