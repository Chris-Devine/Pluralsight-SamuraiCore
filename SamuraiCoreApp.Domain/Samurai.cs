﻿using System.Collections.Generic;

namespace SamuraiCoreApp.Domain
{
    public class Samurai
    {
        public Samurai()
        {
            Quotes = new List<Quote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }
        //public int BattleId { get; set; }   
        public List<SamuraiBattle> SamuraiBattles { get; set; }

        // NOTE: One to one (this can be null here 
        public SecretIdentity SecretIdentity { get; set; }
    }
}
