using System;
using System.Web.Http;
using BLL;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/negociacao")]
    public class NegociacaoController : ApiController
    {   
        [AcceptVerbs("POST")]
        [Route("Liberanegociacoes")]
        //http://localhost:63312/api/negociacao/Liberanegociacoes?negociacaoId={negociacaoId}
        public void Liberanegociacoes(double negociacaoId)
        {
            try
            {                
                new NegociacaoBLL().ConsultaLiberacao(negociacaoId);  
            }
            catch { }            
        }
    }
}
