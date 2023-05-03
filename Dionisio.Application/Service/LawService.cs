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
    public class LawService : BaseService<LawEntity>, ILawService
    {
        private readonly ILawRepository _PdfRepository;
        public LawService(IBaseRepository<LawEntity> baseRepository, IMapper mapper, ILawRepository PdfRepository) : base(baseRepository, mapper)
        {
            _PdfRepository = PdfRepository;
        }
    }

}
