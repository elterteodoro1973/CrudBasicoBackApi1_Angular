using BackEndAngular.DTO;
using BackEndAngular.Models;
using AutoMapper;

namespace BackEndAngular.Parsers
{
    public class MapeamentoDTOParaEntidade : Profile
    {
        public MapeamentoDTOParaEntidade()
        {
            CreateMap<FuncionarioDTO, Funcionario>();
        }
    }
}
