using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class ImageWeightInfo
    {
        public int Id { get; set; }
        public PageLocation PageLocation { get; set; }
        public int SizeOrder { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Resolution { get; set; }
    }
}
