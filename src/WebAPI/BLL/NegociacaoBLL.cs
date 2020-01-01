using DAL;

namespace BLL
{
    public class NegociacaoBLL
    {

        #region Métodos públicos
        public string ConsultaLiberacao(double negociacaoId)
        {
            return (new NegociacaoDAL()).ConsultaLiberacao(negociacaoId);           
        }
        #endregion
    }
}