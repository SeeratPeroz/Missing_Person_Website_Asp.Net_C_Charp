using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace CRUD_Operations.Models
{
    public class cntContext: DbContext
    {
        public cntContext():base("name=curd")
        {
            Database.SetInitializer<cntContext>(new DropCreateDatabaseIfModelChanges<cntContext>());
        }

        public System.Data.Entity.DbSet<Missing_Person.Models.Entity.MissingPerson> MissingPersons { get; set; }

    }
}