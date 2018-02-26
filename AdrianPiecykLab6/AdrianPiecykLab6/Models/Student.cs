using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdrianPiecykLab6.Models
{
    public class Student
    {
        /// <summary>
        /// Tworzenie modelu potrzebnego do zrobienia bazy w Entity Framework
        /// jak widac połączenie one-to-many
        /// </summary>
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string  DateOfBirth { get; set; }
        [JsonIgnore]
        public virtual List<Course> Courses { get; set; }
      

      


    }
}