using BLL.Interfaces;
using Common;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        UsuarioRepository repository = new UsuarioRepository();
        public async Task<UsuarioDTO> Autenticar(string email, string senha)
        {
            return await repository.Autenticar(email, senha);
        }

        public async Task Insert(UsuarioDTO usuario)
        {
            List<Error> errors = new List<Error>();

            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                base.AddError("Nome", "Nome deve ser informado");
            }
            else if (usuario.Nome.Length < 5 || usuario.Nome.Length > 50)
            {
                base.AddError("Nome", "O nome deve conter entre 5 e 50 caracteres");
            }

            //APÓS VALIDAR TODOS OS CAMPOS, VERIFIQUE SE POSSUIMOS ERROS
            base.CheckErrors();
            try
            {
                using (SSContext context = new SSContext())
                {
                    context.Usuarios.Add(usuario);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o admnistrador.");
            }
        }




       
    }
}
