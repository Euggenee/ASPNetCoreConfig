using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Models
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<CategoriesDto> CategoriesDtos{ get; set; }
    }
}
