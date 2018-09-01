namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Repozytorium.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Repozytorium.Models.OglContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repozytorium.Models.OglContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            SeedRoles(context);
            SeedUsers(context);
            SeedOgloszenia(context);
            SeedKategorie(context);
            SeedOgloszenie_Kategoria(context);
        }

        private void SeedOgloszenie_Kategoria(OglContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                Ogloszenie_Kategoria okat = new Ogloszenie_Kategoria()
                {
                    Id = i,
                    OgloszenieId = i / +1,
                    KategoriaId = i / 2 + 1
                };
                context.Set<Ogloszenie_Kategoria>().AddOrUpdate(okat);         
            }
        }

        private void SeedKategorie(OglContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                Kategoria kat = new Kategoria()
                {
                    Id = i,
                    Nazwa = "Nazwa kategorii" + i,
                    Tresc = "Tresc ogloszenia" + i,
                    MetaTytul = "Tytul kategorii" + i,
                    MetaOpis = "Opis kategorii" + i,
                    MetaSlowa = "Slowa kluczowe do kategorii" + i,
                    ParemtId = i
                    
                };
                context.Set<Kategoria>().AddOrUpdate(kat);
            }
        }

        private void SeedOgloszenia(OglContext context)
        {
            string idUzytkownika = context.Set<Uzytkownik>()
                .Where(u => u.UserName == "Admin")
                .FirstOrDefault().Id;

            for (int i = 1; i <= 10; i++)
            {
                Ogloszenie ogl = new Ogloszenie()
                {
                    Id = i,
                    UzytkownikId = idUzytkownika,
                    Tresc = "Tresc ogloszenia" + i,
                    Tytul = "Tytul ogloszenia" + i,
                    DataDodania = DateTime.Now.AddDays(-1)
                };
                context.Set<Ogloszenie>().AddOrUpdate(ogl);
            }
        }

        private void SeedUsers(OglContext context)
        {
            UserStore<Uzytkownik> store = new UserStore<Uzytkownik>(context);
            UserManager<Uzytkownik> manager = new UserManager<Uzytkownik>(store);
            if (!context.Users.Any(user => user.UserName == "Admin"))
            {
                Uzytkownik user = new Uzytkownik
                {
                    UserName = "Admin"
                };
                var adminresult = manager.Create(user, "12345678");
                if (adminresult.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }
        }

        private void SeedRoles(OglContext context)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }
    }
}
