using Dionisio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Data.Context
{
    public class DionisioContext : DbContext
    {
        public DionisioContext(DbContextOptions<DionisioContext> options) : base(options)
        {

        }
        public DbSet<LawEntity> Law => Set<LawEntity>();

    }
}
