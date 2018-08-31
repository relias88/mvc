using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OGL.Models
{
    public class Uzytkownik : IdentityUser
    {
        public Uzytkownik()
        {
            this.Ogloszenia = new HashSet<Ogloszenie>();
        }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        #region Not Mapped
        [NotMapped]
        [Display(Name = "Pan/Pani:")]
        public string PelneNazwisko => Imie + " " + Nazwisko;   //tylko get w net46

        #endregion

        public virtual ICollection<Ogloszenie> Ogloszenia { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Uzytkownik> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}