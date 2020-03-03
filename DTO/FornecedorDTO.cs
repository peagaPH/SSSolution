using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FornecedorDTO
    {
        public int ID { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public Endereco Endereco { get; set; }

        public virtual ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
