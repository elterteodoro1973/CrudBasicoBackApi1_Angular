using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndAngular.DTO
{
    public class FuncionarioDTO
    {       

        [StringLength(50)]
        [Unicode(false)]
        public string Nome { get; set; }

        [StringLength(150)]
        [Unicode(false)]
        public string Endereco { get; set; }

        public DateTime? DataNascimento { get; set; }

        public bool? Ativo { get; set; }

    }
}
