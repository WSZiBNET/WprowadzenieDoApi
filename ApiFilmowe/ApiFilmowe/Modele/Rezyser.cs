using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiFilmowe.Modele
{
    public partial class Rezyser
    {
        public Rezyser()
        {
            Film = new HashSet<Film>();
        }

        public long Id { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string KrajPochodzenia { get; set; }
        [JsonIgnore]
        public virtual ICollection<Film> Film { get; set; }
    }
}
