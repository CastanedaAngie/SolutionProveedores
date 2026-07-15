using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using sistem_supplier._Models.Models;
using sistem_supplier.DAL.Repository.Interfaces;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.DTO;
using sistem_supplier.DAL.DContext;
using Microsoft.EntityFrameworkCore;

namespace sistem_supplier.DLL.services
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly IGenericRepository<Servicio> _ServicioRepository;
        private readonly IMapper _Mapper;

        public ServicioRepository(IGenericRepository<Servicio> ServicioRepository, IMapper mapper)
        {
            _ServicioRepository = ServicioRepository;
            _Mapper = mapper;
        }

        public async Task<List<ServicioDTO>> Lista()
        {
            try
            {

                var ListaServicio = await _ServicioRepository.GetAll();

                return _Mapper.Map<List<ServicioDTO>>(ListaServicio.ToList());

            }
            catch
            {
                throw;
            }
        }


        public async Task<ServicioDTO> Create(ServicioDTO Modelo)
        {
            try
            {
                var ServicioCreado = await _ServicioRepository.Create(_Mapper.Map<Servicio>(Modelo));
                if (ServicioCreado.IdServicio == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el servicio");
                }
                return _Mapper.Map<ServicioDTO>(ServicioCreado);

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
                var ServicioEncontrado = await _ServicioRepository.Get(s => s.IdServicio == id);
                if (ServicioEncontrado == null)
                {
                    throw new TaskCanceledException("El servicio no existe");
                }
                bool respuesta = await _ServicioRepository.Delete(ServicioEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El el servicio no se elimino con exito");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(ServicioDTO Modelo)
        {
            try
            {
                var ServicioModelo = _Mapper.Map<Servicio>(Modelo);
                var ServicioEncontrado = await _ServicioRepository.Get(s => s.IdServicio == Modelo.idServicio);
                if (ServicioEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el Servicio");
                }
                ServicioEncontrado.IdServicio = ServicioModelo.IdServicio;
                ServicioEncontrado.NomServicio = ServicioModelo.NomServicio;


                bool respuesta = await _ServicioRepository.Update(ServicioEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo editar el servicio");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ServicioDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
