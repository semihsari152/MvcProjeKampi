using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext // burada tanımlayacağımız propertyler sqlde birer tablo ismi olarak tutuluyor
    {
        public DbSet<About> Abouts { get; set; } // about başka bir katmanda olduğu için referansını oluşturduk solution exp'ten
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }

        //db set türünde propertyleri sql'e birer tablo olarak yansıtacak
    }
}
