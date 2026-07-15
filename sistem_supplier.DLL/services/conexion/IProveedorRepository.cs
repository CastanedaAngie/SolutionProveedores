using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using sistem_supplier.DLL.services.conexion;
using sistem_supplier.DAL.Repository.Interfaces;
using sistem_supplier.DTO;
using sistem_supplier._Models;
using sistem_supplier.DAL.Repository;

namespace sistem_supplier.DLL.services.conexion
{

    public interface IProveedorRepository
    {
        Task<ProveedorDTO> GetById(int id);
        Task<List<ProveedorDTO>> Lista();

        Task<ProveedorDTO> Create(ProveedorDTO Modelo);

        Task<bool> Update(ProveedorDTO Modelo);

        Task<bool> Delete(int id);
    }
}
