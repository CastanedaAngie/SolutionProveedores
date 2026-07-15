using System;
using System.Collections.Generic;
using System.Text;
using sistem_supplier.DTO;
using sistem_supplier.DAL;
using sistem_supplier.DLL.services.conexion;
using AutoMapper;
using sistem_supplier.DAL.Repository.Interfaces;
using sistem_supplier._Models.Models;

namespace sistem_supplier.DLL.services
{
    public class ServicioProveedorRepository: IServicioProveedorRepository
    {

        private readonly IGenericRepository<ServicioProveedor> _ServicioProveedorRepository;
        private readonly IMapper _Mapper;

        public ServicioProveedorRepository(IGenericRepository<ServicioProveedor> servicioProveedorRepository, IMapper mapper)
        {
            _ServicioProveedorRepository = servicioProveedorRepository;
            _Mapper = mapper;
        }

        public async Task<List<ServicioProveedorDTO>> Lista()
        {
            try
            {
               
                var ListaServicioProveedor = await _ServicioProveedorRepository.GetAll();

                return _Mapper.Map<List<ServicioProveedorDTO>>(ListaServicioProveedor.ToList());

            }
            catch
            {
                throw;
            }
        }
    }

    
}
