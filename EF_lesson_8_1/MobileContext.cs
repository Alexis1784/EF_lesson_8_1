using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_8_1
{
    class MobileContext : DbContext
    {
        public MobileContext()
            : base("EF_lesson_8_1")
        { }
        public DbSet<Phone> Phones { get; set; }
    }
}
