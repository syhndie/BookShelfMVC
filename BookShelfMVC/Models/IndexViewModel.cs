using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShelfMVC.Models
{
    public class IndexViewModel
    {
        public List<Book> Books { get; set; }
        public string Sort { get; set; }
        public string TitleFilter { get; set; }
        public string AuthorLastNameFilter { get; set; }
    }
}
