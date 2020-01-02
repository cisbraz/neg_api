using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Negociacao
    {
        public double NegociacaoId { get; set; }
        public string ProdutorId { get; set; }
        public string DistribuidorId { get; set; }
        public string Status { get; set; }
    }
}
