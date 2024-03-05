using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiteReq.Models;

namespace SiteReq.Data
{
    public class SiteReqContext : DbContext
    {
        public SiteReqContext (DbContextOptions<SiteReqContext> options)
            : base(options)
        {
        }

        public DbSet<SiteReq.Models.Person> Person { get; set; } = default!;
    }
}
