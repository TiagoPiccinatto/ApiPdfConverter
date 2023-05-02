using AutoMapper;
using Dionisio.Application.Interface.Repository;
using Dionisio.Application.Interface.Sevice;
using Dionisio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Application.Service
{
    public class PdfService : BaseService<PdfEntity>, IPdfService
    {
        private readonly IPdfRepository _PdfRepository;
        public PdfService(IBaseRepository<PdfEntity> baseRepository, IMapper mapper, IPdfRepository PdfRepository) : base(baseRepository, mapper)
        {
            _PdfRepository = PdfRepository;
        }
    }

}
