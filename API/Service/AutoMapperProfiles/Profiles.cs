using AutoMapper;
using Domain.DTO.OperationDTOs;
using Domain.DTO.TypeDTOs;
using Domain.Entitys;

namespace Service.AutoMapperProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<OperationType, OperationTypeDTO>()
                .ReverseMap();
            CreateMap<OperationType, OperationTypeCreateUpdateDTO>()
                .ReverseMap();

            CreateMap<Operation, OperationDTO>()
                .ReverseMap();

            CreateMap<Operation, OperationCreateUpdateDTO>()
                .ForMember(x => x.TypeName, y => y.MapFrom(src => src.Type.Name))
                .ReverseMap();
        }

    }
}
