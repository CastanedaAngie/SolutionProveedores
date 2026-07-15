using AutoMapper;
using sistem_supplier._Models.Models;
using sistem_supplier.DAL.Repository.Interfaces;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.DTO;
using sistem_supplier.DLL.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistem_supplier.DLL.services
{
    public class ProveedorRepository:IProveedorRepository
    {
        private readonly IGenericRepository<Proveedor> _ProveedorRepository;
        private readonly IMapper _Mapper;


        public ProveedorRepository(IGenericRepository<Proveedor> proveedorRepository,IMapper mapper)
        {
            _ProveedorRepository = proveedorRepository;
            _Mapper = mapper;
        }

        public async Task<List<ProveedorDTO>> Lista()
        {
            try
            {

                var ListaProveedor = await _ProveedorRepository.GetAll();

                return _Mapper.Map<List<ProveedorDTO>>(ListaProveedor.ToList());

            }
            catch
            {
                throw;
            }
        }

        public async Task<ProveedorDTO> Create(ProveedorDTO Modelo)
        {
            try
            {
                var ProveedorCreado = await _ProveedorRepository.Create(_Mapper.Map<Proveedor>(Modelo));
                if (ProveedorCreado.idProveedor == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el Proveedor");
                }
                return _Mapper.Map<ProveedorDTO>(ProveedorCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var ProveedorEncontrado = await _ProveedorRepository.Get(p =>p.idProveedor == id);
                if (ProveedorEncontrado == null)
                {
                    throw new TaskCanceledException("El Proveedor no existe");
                }
                bool respuesta = await _ProveedorRepository.Delete(ProveedorEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El el Proveedor no se elimino con exito");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(ProveedorDTO Modelo)
        {
            try
            {
                var ProveedorModelo = _Mapper.Map<Proveedor>(Modelo);
                var ProveedorEncontrado = await _ProveedorRepository.Get(p => p.idProveedor == Modelo.idProveedor);
                if (ProveedorEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Servicio");
                }
                ProveedorEncontrado.idProveedor = ProveedorModelo.idProveedor;
                ProveedorEncontrado.nomProveedor = ProveedorModelo.nomProveedor;


                bool respuesta = await _ProveedorRepository.Update(ProveedorEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo editar el Proveedor");
                }
                return respuesta;
            }
            catch
            {
                throw;

            }
        }

        public Task<ProveedorDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        

       
        
    }
}
