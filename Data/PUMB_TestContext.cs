using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PUMB_Test.Models;

namespace PUMB_Test.Data
{
    public class PUMB_TestContext : DbContext
    {
        public PUMB_TestContext (DbContextOptions<PUMB_TestContext> options)
            : base(options)
        {
        }

        public DbSet<PUMB_Test.Models.ContactsModel> ContactsModel { get; set; } = default!;
    }
}
