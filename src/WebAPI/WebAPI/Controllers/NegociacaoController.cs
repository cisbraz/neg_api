using System;
using System.Web.Http;
using BLL;

namespace WebAPI.Controllers
{

    [RoutePrefix("api/negociacao")]
    public class NegociacaoController : ApiController
    {   
        [AcceptVerbs("GET")]
        [Route("Liberanegociacoes")]
        //http://localhost:63312/api/negociacao/Liberanegociacoes?negociacaoId={negociacaoId}
        public String Liberanegociacoes(double negociacaoId)
        {
            try
            {                
                return (new NegociacaoBLL()).ConsultaLiberacao(negociacaoId);  
            }
            catch(Exception e)
            {
                return "Erro ao liberar: "+ e.Message;
            }            
        }
    }
}
