using Dionisio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Data.Context
{
    public class PdfContext : DbContext
    {
        public PdfContext(DbContextOptions<PdfContext> options) : base(options)
        {

        }
        public DbSet<PdfEntity> Pdf => Set<PdfEntity>();

    }
}
