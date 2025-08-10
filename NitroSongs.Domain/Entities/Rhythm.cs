using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class Rhythm
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public ICollection<Song> Songs { get; set; } = [];
    }
}
