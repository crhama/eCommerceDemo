using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class PhotoImage
    {
        public Guid Id { get; set; }
        public string OriginalName { get; set; }
        public string FileExtension { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Resolution { get; set; }
        public string Description { get; set; }
        public PageLocation PageLocation { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
