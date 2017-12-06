using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookShelfMVC.Models
{
    public class Book
    {
        public int ID { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Display(Name = "Author Last Name")]
        public string AuthorLastName { get; set; }

        [Display(Name = "Author First Name")]
        public string AuthorFirstName { get; set; }

        [Display(Name = "Call Number")]
        public string CallNumber { get; set; }

        public string AuthorFullName
        {
            get
            {
                return $"{AuthorLastName}, {AuthorFirstName}";
            }
        }

        public static List<Book> GetSortedBooks(BookShelfMVCContext db, string titleFilter, string authorLastNameFilter, string sort)
        {
            var displayBooks = from b in db.Book
                               select b;

            if (!String.IsNullOrEmpty(titleFilter))
            {
                displayBooks = displayBooks.Where(t => t.Title.Contains(titleFilter));
            }

            if (!String.IsNullOrEmpty(authorLastNameFilter))
            {
                displayBooks = displayBooks.Where(a => a.AuthorLastName.Contains(authorLastNameFilter));
            }

           
            if (sort == "title-asc")
            {
                return displayBooks.OrderBy(t => t.Title).ThenBy(t => t.AuthorLastName).ToList();
            }
            else if (sort == "title-desc")
            {
                return displayBooks.OrderByDescending(t => t.Title).ThenByDescending(t => t.AuthorLastName).ToList();
            }
            else if (sort == "author-asc")
            {
                return displayBooks.OrderBy(t => t.AuthorLastName).ThenBy(t => t.Title).ToList();
            }
            else if (sort == "author-desc")
            {
                return displayBooks.OrderByDescending(t => t.AuthorLastName).ThenByDescending(t => t.Title).ToList();
            }
            else if (sort == "callno-asc")
            {
                return displayBooks.OrderBy(t => t.CallNumber).ThenBy(t => t.Title).ToList();
            }
            else if (sort == "callno-desc")
            {
                return displayBooks.OrderByDescending(t => t.CallNumber).ThenByDescending(t => t.Title).ToList();
            }
            else
            {
                return displayBooks.OrderBy(t => t.Title).ThenBy(t => t.AuthorLastName).ToList();
            }
        }
    }
}