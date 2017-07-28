using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiCoreApp.Domain
{
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }

        // NOTE: Two below props are need to be a one to one relationship
        public int BattleId { get; set; }
        public Battle Battle { get; set; }
    }
}
