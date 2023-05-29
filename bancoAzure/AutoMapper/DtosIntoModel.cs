using AutoMapper;
using bancoAzure.Models;

namespace bancoAzure.AutoMapper
{
    public class DtosIntoModel : Profile
    {
        public DtosIntoModel()
        {
            CreateMap<UsuarioCreate, Usuario>();


        }
    }
}
