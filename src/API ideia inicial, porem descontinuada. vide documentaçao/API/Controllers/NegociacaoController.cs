using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using API.Data;
using API.Models;

namespace API.Controllers
{     
    [ApiController]
    public class NegociacaoController : Controller
    {
        private readonly NegociacaoContext _context;

        public NegociacaoController(NegociacaoContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[controller]/Liberanegociacoes")]
        //https://localhost:44353/api/negociacao/Liberanegociacoes?negociacaoId={negociacaoId}
        public async Task<string> Liberanegociacoes(double negociacaoId)
        {
            try
            {
                bool liberar = true;
                Negociacao negociacao = await _context.Negociacao.SingleOrDefaultAsync(n => n.NegociacaoId == negociacaoId);
                if (negociacao != null)
                {                    
                    Produtor produtor = await _context.Produtor.FirstOrDefaultAsync(p => p.ProdutorId == negociacao.ProdutorId);
                    if (produtor != null)
                    {
                        if (!produtor.Ativo.Equals("S")) liberar = false;
                        Limite limite = await _context.Limite.SingleOrDefaultAsync(l => l.ProdutorId == negociacao.ProdutorId &&
                                                                                   l.DistribuidorId == negociacao.DistribuidorId);
                        Utilizado utilizado = await _context.Utilizado.SingleOrDefaultAsync(u => u.ProdutorId == negociacao.ProdutorId &&
                                                                                   u.DistribuidorId == negociacao.DistribuidorId);

                        if (limite == null) liberar = false;
                        double util = utilizado != null ? utilizado.ValorUtilizado : 0;
                        if (util > limite.ValorLimite) liberar = false;
                    }
                    else
                    {
                        liberar = false; 
                    }
                }
                else
                {
                    liberar = false;
                }
                
                negociacao.Status = liberar ? "A" : "C";
                _context.Update(negociacao);
                _context.SaveChanges();
                return liberar ? "S" : "N";
            }
            catch (Exception e)
            {
                return "Erro: "+ e.Message;
            }
        }
    }
}

