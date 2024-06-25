using PIM.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Dao
{
    internal class DaoAdm
    {
        OleDbConnection conexao;

        public DaoAdm(string banco)
        {
            //conexao = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ="+banco+"; Extended Properties =’Excel 12.0 Xml; HDR = YES’;");
            //conexao = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + banco + " ; Extended Properties = 'Excel 8.0;HDR=YES;ReadOnly=False'");
            conexao = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + banco + ";Extended Properties='Excel 8.0;HDR=YES;ReadOnly=False'");
        }

        public void createAdm(administrador administrador)
        {

            string comandoSql1 = "INSERT INTO [Usuario_tbl$] ([Id_Usuario],[Cpf],[Nome], [Senha]) VALUES (@ID,@CPF,@NOME,@SENHA); ";
            string comandoSql2 = "INSERT INTO [Adm_tbl$] ([Id_Adm]) VALUES (@ADM);";
            string comandoSql3 = "INSERT INTO [Contato_tbl$] ([Tel1],[Tel2],[Email]) VALUES (@TEL1,@TEL2,@EMAIL);";
            string comandoSql4 = "INSERT INTO [Endereco_tbl$] ([Rua],[Bairro],[Cidade],[Estado]) VALUES (@RUA,@BAIRRO,@CIDADE,@ESTADO);";

            OleDbCommand comando1 = new OleDbCommand(comandoSql1, conexao);
            OleDbCommand comando2 = new OleDbCommand(comandoSql2, conexao);
            OleDbCommand comando3 = new OleDbCommand(comandoSql3, conexao);
            OleDbCommand comando4 = new OleDbCommand(comandoSql4, conexao);

            comando2.Parameters.Add("@ADM", OleDbType.Integer).Value = Convert.ToInt32(administrador.idAdm);
            comando1.Parameters.Add("@ID", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando1.Parameters.Add("@CPF", OleDbType.Integer).Value = Convert.ToInt32(administrador.cpf);
            comando1.Parameters.Add("@NOME", OleDbType.VarChar, 30).Value = administrador.nome;
            comando1.Parameters.Add("@SENHA", OleDbType.VarChar, 10).Value = administrador.senha;
            comando3.Parameters.Add("@TEL1", OleDbType.Integer).Value = Convert.ToInt32(administrador.contatos.tel1);
            comando3.Parameters.Add("@TEL2", OleDbType.Integer).Value = Convert.ToInt32(administrador.contatos.tel2);
            comando3.Parameters.Add("@EMAIL", OleDbType.VarChar, 50).Value = administrador.contatos.email;
            comando4.Parameters.Add("@RUA", OleDbType.VarChar, 255).Value = administrador.rua;
            comando4.Parameters.Add("@BAIRRO", OleDbType.VarChar, 255).Value = administrador.bairro;
            comando4.Parameters.Add("@CIDADE", OleDbType.VarChar, 255).Value = administrador.cidade;
            comando4.Parameters.Add("@ESTADO", OleDbType.VarChar, 255).Value = administrador.estado;
            //
            try
            {
                conexao.Open();

                comando1.ExecuteNonQuery();
                comando3.ExecuteNonQuery();
                comando4.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Erro ao Criar dados");
            }
            finally
            {
                conexao.Close();
            }
        }

        public administrador readAdm(administrador administrador)
        {

            string comandoSql = @"SELECT [A.Id_Adm],[U.Nome],
                                   [U.Cpf], [C.Tel1], [C.Tel2], [C.Email], 
                                   [E.Rua], [E.Bairro], [E.Numero], [E.Cidade], [E.Estado], [E.Cep]
                                   FROM (([Usuario_tbl$] U
                                   LEFT JOIN [Adm_tbl$] A ON U.Id_Usuario= A.Id_Usuario)
                                   LEFT JOIN [Contato_tbl$] C ON U.Id_Usuario = C.Id_Usuario)
                                   WHERE [F.Id_Usuario] = @USER";

            //string comandoSql = "select * from [Usuario_tbl$] Where [Id_Usuario] = @USER";


            OleDbCommand comando = new(comandoSql, conexao);

            comando.Parameters.Add("@USER", OleDbType.Integer).Value = administrador.numUser;

            try
            {
                conexao.Open();

                OleDbDataReader rd = comando.ExecuteReader();

                while (rd.Read())
                {
                    administrador.idAdm = Convert.ToInt16(rd["A.Id_Adm"]);
                    administrador.numUser = Convert.ToInt16(rd["F.Id_Usuario"]);
                    administrador.nome = Convert.ToString(rd["U.Nome"]);
                    administrador.cpf = Convert.ToInt32(rd["U.Cpf"]);
                    administrador.rua = Convert.ToString(rd["E.Rua"]);
                    administrador.bairro = Convert.ToString(rd["E.Bairro"]);
                    administrador.cidade = Convert.ToString(rd["E.Cidade"]);
                    administrador.estado = Convert.ToString(rd["E.Estado"]);
                    administrador.contatos.tel1 = Convert.ToInt32(rd["C.Tel1"]);
                    administrador.contatos.tel2 = Convert.ToInt32(rd["C.Tel2"]);
                    administrador.contatos.email = Convert.ToString(rd["C.Email"]);
                }
                return administrador;
            }
            catch
            {
                MessageBox.Show("Erro ao Buscar dados");
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

        public void updateAdm(administrador administrador)
        {
            string comandoSql1 = "UPDATE [Usuario_tbl$] SET [Cpf] = @CPF, [Nome] = @NOME, [Senha] = @SENHA WHERE [Id_Usuario] = @ID1;";
            string comandoSql2 = "UPDATE [Adm_tbl$] SET [Id_Adm] = @ADM WHERE [Id_Usuario] = @ID2; ";
            string comandoSql3 = "UPDATE [Contato_tbl$] SET [Tel1] = @TEL1, [Tel2] = @TEL2 WHERE [Id_Usuario] = @ID3; ";
            string comandoSql4 = "UPDATE [Endereco_tbl$] SET [Rua] = @RUA, [Bairro] = @BAIRRO, [Cidade] = @CIDADE, [Estado] = @ESTADO WHERE [Id_Usuario] = @ID4; ";

            OleDbCommand comando1 = new OleDbCommand(comandoSql1, conexao);
            OleDbCommand comando2 = new OleDbCommand(comandoSql2, conexao);
            OleDbCommand comando3 = new OleDbCommand(comandoSql3, conexao);
            OleDbCommand comando4 = new OleDbCommand(comandoSql4, conexao);

            comando1.Parameters.Add("@ID1", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando2.Parameters.Add("@ID2", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando3.Parameters.Add("@ID3", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando4.Parameters.Add("@ID4", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);

            comando2.Parameters.Add("@ADM", OleDbType.Integer).Value = Convert.ToInt32(administrador.idAdm);
            comando1.Parameters.Add("@CPF", OleDbType.Integer).Value = Convert.ToInt32(administrador.cpf);
            comando1.Parameters.Add("@NOME", OleDbType.VarChar, 30).Value = administrador.nome;
            comando1.Parameters.Add("@SENHA", OleDbType.VarChar, 10).Value = administrador.senha;
            comando3.Parameters.Add("@TEL1", OleDbType.Integer).Value = Convert.ToInt32(administrador.contatos.tel1);
            comando3.Parameters.Add("@TEL2", OleDbType.Integer).Value = Convert.ToInt32(administrador.contatos.tel2);
            //comando3.Parameters.Add("@EMAIL", OleDbType.VarChar, 50).Value = funcionario.contatos.email;
            comando4.Parameters.Add("@RUA", OleDbType.VarChar, 255).Value = administrador.rua;
            comando4.Parameters.Add("@BAIRRO", OleDbType.VarChar, 255).Value = administrador.bairro;
            //comando.Parameters.Add("@N", OleDbType.Integer).Value = Convert.ToInt16(funcionario.numero);
            comando4.Parameters.Add("@CIDADE", OleDbType.VarChar, 255).Value = administrador.cidade;
            comando4.Parameters.Add("@ESTADO", OleDbType.VarChar, 255).Value = administrador.estado;
            //comando.Parameters.Add("@CEP", OleDbType.Integer).Value = Convert.ToInt16(funcionario.cep);

            try
            {
                conexao.Open();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();
                comando3.ExecuteNonQuery();
                comando4.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Erro ao Alterar dados");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void deleteAdm(administrador administrador)
        {
            string comandoSql1 = "DELETE FROM [Adm_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql2 = "DELETE FROM [Contato_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql3 = "DELETE FROM [Endereco_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql6 = "DELETE FROM [Usuario_tbl$] WHERE [Id_Usuario] = @ID;";


            OleDbCommand comando1 = new OleDbCommand(comandoSql1, conexao);
            OleDbCommand comando2 = new OleDbCommand(comandoSql2, conexao);
            OleDbCommand comando3 = new OleDbCommand(comandoSql3, conexao);
            OleDbCommand comando6 = new OleDbCommand(comandoSql6, conexao);

            comando1.Parameters.Add("@ID1", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando2.Parameters.Add("@ID2", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando3.Parameters.Add("@ID3", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            comando6.Parameters.Add("@ID6", OleDbType.Integer).Value = Convert.ToInt32(administrador.numUser);
            try
            {
                conexao.Open();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();
                comando3.ExecuteNonQuery();
                comando6.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Erro ao Excluir dados");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
