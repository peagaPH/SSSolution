using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using BLL.Validators;
using Common;
using DAO.Interfaces;
using DAO;

namespace BLL.Impl
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task Create(FornecedorDTO fornecedor)
        {
            var resposta = fornecedor.CNPJ.IsValidCNPJ();

            if (resposta != "") base.AddError("CNPJ", resposta);

            List<Error> errors = new EnderecoValidator().Validate(fornecedor.Endereco);

            //Adiciona os erros do endereco nos erros do fornecedor (caso encontre)
            foreach (Error erroDoEndereco in errors)
            {
                base.AddError(erroDoEndereco.FieldName, erroDoEndereco.Message);
            }

            CheckErrors();

            try
            {
                FornecedorRepository repository = new FornecedorRepository();
                await repository.Create(fornecedor);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    List<Error> error = new List<Error>();
                    error.Add(new Error() { FieldName = "CNPJ", Message = "CNPJ já cadastrado" });
                    throw new NecoException(error);
                }
                //Log.Write("erro 666 " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }

        }
    }
}
