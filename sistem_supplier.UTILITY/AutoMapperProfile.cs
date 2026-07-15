using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using sistem_supplier.DTO;
using sistem_supplier._Models;
using sistem_supplier._Models.Models;

namespace sistem_supplier.UTILITY
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Proveedor,ProveedorDTO>().ReverseMap();


            CreateMap<Servicio,ServicioDTO>().ReverseMap();


            CreateMap<ServicioProveedor,ServicioProveedorDTO>().ReverseMap();



        }

    }
}
