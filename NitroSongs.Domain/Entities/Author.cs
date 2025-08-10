using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class Author
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Song> Songs { get; set; } = [];
    }
}
