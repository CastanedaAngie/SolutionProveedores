using System;
using System.Collections.Generic;
using System.Text;
using sistem_supplier.DTO;
using AutoMapper;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier._Models;
using sistem_supplier.DAL.Repository;

namespace sistem_supplier.DLL.services.conexion
{
    public interface IServicioRepository
    {
        Task<ServicioDTO> GetById(int id);
        Task<List<ServicioDTO>> Lista();

        Task<ServicioDTO> Create (ServicioDTO Modelo);

        Task<bool> Update (ServicioDTO Model);

        Task<bool> Delete (int id);


    }
}
