using sistem_supplier.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace sistem_supplier.DLL.services.conexion
{
    public interface IPaisRepository
    {
        Task<List<PaisDTO>> GetAllPais();
    }
}
