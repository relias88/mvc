using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OGL.Models
{
    public class Ogloszenie
    {
        public Ogloszenie()
        {
            this.Ogloszenie_kategoria = new HashSet<Ogloszenie_Kategoria>();
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Tresc ogłoszenia:")]
        [MaxLength(72)]
        public string Tresc { get; set; }

        [Display(Name = "Tytuł ogłoszenia:")]
        [MaxLength(72)]
        public string Tytul { get; set; }

        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDodania { get; set; }

        public virtual ICollection<Ogloszenie_Kategoria> Ogloszenie_Kategoria { get; set; }

        public string UzytkownikId { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}