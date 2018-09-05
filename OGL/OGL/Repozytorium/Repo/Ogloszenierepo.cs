using Repozytorium.IRepo;
using Repozytorium.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Repozytorium.Repo
{
    public class OgloszenieRepo : IOgloszenieRepo
    {
        private OglContext db = new OglContext();

        public IQueryable<Ogloszenie> PobierzOgloszenia()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            return db.Ogloszenia.AsNoTracking();
        }
    }
}