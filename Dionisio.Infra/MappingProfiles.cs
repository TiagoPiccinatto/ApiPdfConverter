using AutoMapper;
using Dionisio.Domain.Entities;
using Dionisio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dionisio.Infra
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PdfEntity, PdfModel>().ReverseMap();
           
        }
    }
}
