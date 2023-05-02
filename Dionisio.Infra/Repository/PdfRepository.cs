using Dionisio.Application.Interface.Repository;
using Dionisio.Data.Context;
using Dionisio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Infra.Repository
{
    public class PdfRepository : BaseRepository<PdfEntity>, IPdfRepository
    {
        public PdfRepository(PdfContext context) : base(context)
        {
        }
    }
}
