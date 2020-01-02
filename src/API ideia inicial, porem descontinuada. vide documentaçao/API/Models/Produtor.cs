using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Produtor
    {
        public string ProdutorId { get; set; }

        public string RazaoSocial { get; set; }

        public string Ativo { get; set; }

    }
}