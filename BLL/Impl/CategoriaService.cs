using BLL.Interfaces;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common;
using System.IO;
using System.Web;

namespace BLL.Impl
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        //VOID????? CADÊ O RESPONSE??????
        public async Task Insert(CategoriaDTO categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nome))
            {
                AddError("Nome", "O nome deve ser informado.");
            }
            else
            {
                categoria.Nome = categoria.Nome.Trim();
                if (categoria.Nome.Length < 2 || categoria.Nome.Length > 70)
                {
                    AddError("Nome", "Nome deve conter entre 2 e 70 caracteres.");
                }
            }
            try
            {
                using (SSContext context = new SSContext())
                {
                    //Irá no banco procurar se a categoria com este nome
                    //já foi cadastrado
                    CategoriaDTO categoriaJaCadastrada = await
                        context.Categorias.FirstOrDefaultAsync(c => c.Nome == categoria.Nome);

                    if (categoriaJaCadastrada != null)
                    {
                        //Se entrou aqui, categoria já cadastrada, lançar um erro!
                        //OU, NO MELHOR DOS CASOS, CRIAR UM RESPONSE.
                        throw new NecoException("Categoria já cadastrada!");
                    }
                    context.Categorias.Add(categoria);
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                if (ex is NecoException)
                {
                    throw ex;
                }
                //TODO: 
                //Logar Erro em algum lugar

                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<List<CategoriaDTO>> GetCategorias()
        {
            using (SSContext context = new SSContext())
            {
                return await context.Categorias.ToListAsync();
            }
        }
    }
}
