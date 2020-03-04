using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task Insert(UsuarioDTO usuario);
        Task<UsuarioDTO> Autenticar(string email, string senha);
    }
}
