using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdrianPiecykLab6.Models
{
    public class Course
    {
        /// <summary>
        /// Tworzenie modelu potrzebnego do zrobienia bazy w Entity Framework
        /// jak widac połączenie one-to-many
        /// </summary>
        public string Name { get; set; }
        public string  ECTSPoints { get; set; }
        public long Id { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }

    }
}