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
    public class LawRepository : BaseRepository<LawEntity>, ILawRepository
    {
        public LawRepository(DionisioContext context) : base(context)
        {
        }
    }
}
