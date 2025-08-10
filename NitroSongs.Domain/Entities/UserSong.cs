using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class UserSong
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = default!;
        public long SongId { get; set; }
        public Song Song { get; set; } = default!;
    }
}
