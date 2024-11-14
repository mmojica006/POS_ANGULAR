﻿using AutoMapper;
using POS.Application.Dtos.Warehouse.Response;
using POS.Domain.Entities;
using POS.Utilities.Static;

namespace POS.Application.Mappers
{
    public class WarehouseMappingsProfile : Profile
    {
        public WarehouseMappingsProfile()
        {
            CreateMap<Warehouse,WarehouseResponseDto>()
                .ForMember(x => x.WarehouseId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.WarehouseId, x => x.MapFrom(t => t.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

        }
    }
}
