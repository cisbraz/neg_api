using DBFactory;
using System;
using System.Data.Common;

namespace DAL
{
    public class NegociacaoDAL
    {
        #region Métodos públicos        
        public string ConsultaLiberacao(double negociacaoId)
        {
            try
            {
                bool result = true;
                string produtor = string.Empty;
                string distribuidor = string.Empty;
                double valorLimite = 0d;
                double valorUtilizado = 0d;
                bool ativo = false;
                using (DbConnection connection = DbFactory.CreateConnection())
                {
                    connection.Open();

                    //Consulta negociação
                    try
                    {
                        using (DbCommand command = connection.CreateCommand())
                        {
                            string sql = " SELECT PRODUTOR_ID, DISTRIBUIDOR_ID FROM CAPA_NEGOCIACAO ";
                            sql += "  WHERE NEGOCIACAO_ID = " + negociacaoId;
                            command.CommandText = sql;
                            DbDataReader reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                produtor = reader["PRODUTOR_ID"].ToString();
                                distribuidor = reader["DISTRIBUIDOR_ID"].ToString();
                            }
                        }
                    } catch { }

                    result = !(string.IsNullOrEmpty(produtor) && string.IsNullOrEmpty(distribuidor));

                    if (result)
                    {
                        //Consulta produtor
                        try
                        {
                            using (DbCommand command = connection.CreateCommand())
                            {
                                string sql = " SELECT ATIVO FROM PRODUTOR ";
                                sql += "  WHERE PRODUTOR_ID = '" + produtor + "'";
                                command.CommandText = sql;
                                DbDataReader reader = command.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    ativo = reader["ATIVO"].ToString().Equals("S");
                                }
                            }
                        } catch { }                        
                    }

                    result = ativo;

                    if (result)
                    {
                        //Consulta limite do produto com o distribuidor
                        try
                        {
                            using (DbCommand command = connection.CreateCommand())
                            {
                                string sql = " SELECT VALOR_LIMITE FROM VW_LIMITE ";
                                sql += "  WHERE PRODUTOR_ID = '" + produtor + "'";
                                sql += "    AND DISTRIBUIDOR_ID = '" + distribuidor + "'";
                                command.CommandText = sql;
                                DbDataReader reader = command.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    valorLimite = double.Parse(reader["VALOR_LIMITE"].ToString());
                                }
                            }
                        }
                        catch { }                        
                    }

                    result = valorLimite != 0;

                    if (result)
                    {
                        //Consulta valor utilizado do produtor com o distribuidor
                        try
                        {
                            using (DbCommand command = connection.CreateCommand())
                            {
                                string sql = " SELECT VALOR_UTILIZADO FROM VW_UTILIZADO ";
                                sql += "  WHERE PRODUTOR_ID = '" + produtor + "'";
                                sql += "    AND DISTRIBUIDOR_ID = '" + distribuidor + "'";
                                command.CommandText = sql;
                                DbDataReader reader = command.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    valorUtilizado = double.Parse(reader["VALOR_UTILIZADO"].ToString());
                                }
                            }
                        }
                        catch { }                        
                    }

                    result = valorLimite >= valorUtilizado;

                    //Atualizar o status da negociação
                    try
                    {
                        using (DbCommand command = connection.CreateCommand())
                        {
                            string sql = " UPDATE CAPA_NEGOCIACAO SET STATUS = '" + (result ? "A" : "C") + "'";
                            sql += "  WHERE NEGOCIACAO_ID = " + negociacaoId;
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        return "Erro gravar status: " + e.Message;
                    }                    
                    
                    connection.Close();
                }
                return result ? "A" : "C";
            }
            catch (Exception e)
            {
                return "Erro ao liberar: " + e.Message;
            }
            
        }
        #endregion
    }
}