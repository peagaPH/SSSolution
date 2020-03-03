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
    public class FornecedorRepository : IFornecedorRepository
    {
        public async Task Create(FornecedorDTO fornecedor)
        {
            using (var context = new SSContext())
            {
                context.Fornecedores.Add(fornecedor);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<FornecedorDTO>> GetFornecedores()
        {
            using (var context = new SSContext())
            {
                return await context.Fornecedores.ToListAsync();
            }
        }
    }
}
