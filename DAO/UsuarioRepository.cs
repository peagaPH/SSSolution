using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<UsuarioDTO> Autenticar(string email, string senha)
        {
            using (var ctx = new SSContext())
            {
                UsuarioDTO user =
                await ctx.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
                //tio celo falou sobre o ConfigureAwait(false);
                if (user == null)
                {
                    throw new Exception("Email e/ou senha inválidos");
                }
                return user;
            }
        }

        public async Task Create(UsuarioDTO usuario)
        {
            using (var context = new SSContext())
            {
                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();
            }
        }
    }
}
