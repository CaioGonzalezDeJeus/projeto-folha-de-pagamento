using PIM.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Dao
{
    internal class DaoFun
    {
        OleDbConnection conexao;

        public DaoFun(string banco)
        {
            //string banco = "C:\\Users\\Caio\\Downloads\\PIM\\PIM\\BD\\Folha_Pagamento.xlsx";
            //conexao = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source ="+banco+"; Extended Properties =’Excel 12.0 Xml; HDR = YES’;");
            //conexao = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + banco + " ; Extended Properties = 'Excel 8.0;HDR=YES;ReadOnly=False'");
            conexao = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + banco + ";Extended Properties='Excel 8.0;HDR=YES;ReadOnly=False'");


        }

        public void createFun(funcionario funcionario)
        {
            empresa empresa = new empresa();
            contrato contrato = new contrato();

            string comandoSql1 = "INSERT INTO [Usuario_tbl$] ([Id_Usuario],[Cpf],[Nome], [Senha]) VALUES (@ID,@CPF,@NOME,@SENHA); ";
            string comandoSql2 = "INSERT INTO [Funcionario_tbl$] ([RA_Funcionario]) VALUES (@RA); ";
            string comandoSql3 = "INSERT INTO [Contato_tbl$] ([Tel1],[Tel2],[Email]) VALUES (@TEL1,@TEL2,@EMAIL);";
            string comandoSql4 = "INSERT INTO [Endereco_tbl$] ([Rua],[Bairro],[Cidade],[Estado]) VALUES (@RUA,@BAIRRO,@CIDADE,@ESTADO);";
            string comandoSql5 = "INSERT INTO [Empresa_tbl$] ([Cargo]) VALUES (@CARGO); ";
            string comandoSql6 = "INSERT INTO [Contrato_tbl$] ([Salario_Bruto]) VALUES (@SB)";

            OleDbCommand comando1 = new OleDbCommand(comandoSql1, conexao);
            OleDbCommand comando2 = new OleDbCommand(comandoSql2, conexao);
            OleDbCommand comando3 = new OleDbCommand(comandoSql3, conexao);
            OleDbCommand comando4 = new OleDbCommand(comandoSql4, conexao);
            OleDbCommand comando5 = new OleDbCommand(comandoSql5, conexao);
            OleDbCommand comando6 = new OleDbCommand(comandoSql6, conexao);

            comando1.Parameters.Add("@ID", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando1.Parameters.Add("@CPF", OleDbType.Integer).Value = Convert.ToInt32(funcionario.cpf);
            comando1.Parameters.Add("@NOME", OleDbType.VarChar, 30).Value = funcionario.nome;
            comando1.Parameters.Add("@SENHA", OleDbType.VarChar, 10).Value = funcionario.senha;
            comando2.Parameters.Add("@RA", OleDbType.Integer).Value = Convert.ToInt32(funcionario.ra);
            //comando.Parameters.Add("@CT", OleDbType.Integer).Value = Convert.ToInt32(funcionario.carteira_trabalho);
            //comando.Parameters.Add("@IDADE", OleDbType.Date).Value = Convert.ToDateTime(funcionario.idade);
            comando3.Parameters.Add("@TEL1", OleDbType.Integer).Value = Convert.ToInt32(funcionario.contatos.tel1);
            comando3.Parameters.Add("@TEL2", OleDbType.Integer).Value = Convert.ToInt32(funcionario.contatos.tel2);
            comando3.Parameters.Add("@EMAIL", OleDbType.VarChar, 50).Value = funcionario.contatos.email;
            comando4.Parameters.Add("@RUA", OleDbType.VarChar, 255).Value = funcionario.rua;
            comando4.Parameters.Add("@BAIRRO", OleDbType.VarChar, 255).Value = funcionario.bairro;
            //comando.Parameters.Add("@N", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numero);
            comando4.Parameters.Add("@CIDADE", OleDbType.VarChar, 255).Value = funcionario.cidade;
            comando4.Parameters.Add("@ESTADO", OleDbType.VarChar, 255).Value = funcionario.estado;
            //comando.Parameters.Add("@CEP", OleDbType.Integer).Value = Convert.ToInt32(funcionario.cep);
            comando5.Parameters.Add("@CARGO", OleDbType.VarChar, 255).Value = empresa.cargo;
            comando6.Parameters.Add("@SB", OleDbType.Integer).Value = Convert.ToInt32(contrato.salario_bruto);
            //
            try
            {
                conexao.Open();

                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();
                comando3.ExecuteNonQuery();
                comando4.ExecuteNonQuery();
                comando5.ExecuteNonQuery();
                comando6.ExecuteNonQuery();
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

        public funcionario readFun(funcionario funcionario)
        {
            string comandoSql = @"SELECT [F.RA_Funcionario], [F.Carteira_Trabalho],[F.Id_Usuario],[U.Nome],
                                   [U.Cpf], [C.Tel1], [C.Tel2], [C.Email], 
                                   [E.Rua], [E.Bairro], [E.Numero], [E.Cidade], [E.Estado], [E.Cep]
                                   FROM ((([Usuario_tbl$] U
                                   LEFT JOIN [Funcionario_tbl$] F ON U.Id_Usuario= F.Id_Usuario)
                                   LEFT JOIN [Contato_tbl$] C ON U.Id_Usuario = C.Id_Usuario)
                                   LEFT JOIN [Endereco_tbl$] E ON U.Id_Usuario = E.Id_Usuario)
                                   WHERE [F.Id_Usuario] = @USER";

            //string comandoSql = "select * from [Usuario_tbl$] Where [Id_Usuario] = @USER";


            OleDbCommand comando = new(comandoSql, conexao);

            comando.Parameters.Add("@USER", OleDbType.Integer).Value = funcionario.numUser;

            try
            {
                conexao.Open();

                OleDbDataReader rd = comando.ExecuteReader();

                while (rd.Read())
                {
                    funcionario.ra = Convert.ToInt16(rd["F.RA_Funcionario"]);
                    //funcionario.carteira_trabalho = Convert.ToInt32(rd["F.Carteira_Trabalho"]);
                    //funcionario.idade = Convert.ToDateTime(rd["Nascimento"]);
                    funcionario.numUser = Convert.ToInt16(rd["F.Id_Usuario"]);
                    funcionario.nome = Convert.ToString(rd["U.Nome"]);
                    funcionario.cpf = Convert.ToInt32(rd["U.Cpf"]);
                    funcionario.rua = Convert.ToString(rd["E.Rua"]);
                    funcionario.bairro = Convert.ToString(rd["E.Bairro"]);
                    funcionario.cidade = Convert.ToString(rd["E.Cidade"]);
                    funcionario.estado = Convert.ToString(rd["E.Estado"]);
                    //funcionario.numero = Convert.ToInt16(rd["E.Numero"]);
                    //funcionario.cep = Convert.ToInt16(rd["E.Cep"]);
                    funcionario.contatos.tel1 = Convert.ToInt32(rd["C.Tel1"]);
                    funcionario.contatos.tel2 = Convert.ToInt32(rd["C.Tel2"]);
                    funcionario.contatos.email = Convert.ToString(rd["C.Email"]);
                }               
                return funcionario;
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

        public void updateFun(funcionario funcionario)
        {
            empresa empresa = new empresa();
            contrato contrato = new contrato();

            string comandoSql1 = "UPDATE [Usuario_tbl$] SET [Cpf] = @CPF, [Nome] = @NOME, [Senha] = @SENHA WHERE [Id_Usuario] = @ID1;";
            string comandoSql2 = "UPDATE [Funcionario_tbl$] SET [RA_Funcionario] = @RA WHERE [Id_Usuario] = @ID2;";
            string comandoSql3 = "UPDATE [Contato_tbl$] SET [Tel1] = @TEL1, [Tel2] = @TEL2 WHERE [Id_Usuario] = @ID3; ";
            string comandoSql4 = "UPDATE [Endereco_tbl$] SET [Rua] = @RUA, [Bairro] = @BAIRRO, [Cidade] = @CIDADE, [Estado] = @ESTADO WHERE [Id_Usuario] = @ID4; ";
            string comandoSql5 = "UPDATE [Contrato_tbl$] SET [Salario_Bruto] = @SB WHERE [Id_Usuario] = @ID5; ";
            string comandoSql6 = "UPDATE [Empresa_tbl$] SET [Cargo] = @CARGO WHERE [Id_Usuario] = @ID6;";


            OleDbCommand comando1 = new OleDbCommand(comandoSql1, conexao);
            OleDbCommand comando2 = new OleDbCommand(comandoSql2, conexao);
            OleDbCommand comando3 = new OleDbCommand(comandoSql3, conexao);
            OleDbCommand comando4 = new OleDbCommand(comandoSql4, conexao);
            OleDbCommand comando5 = new OleDbCommand(comandoSql5, conexao);
            OleDbCommand comando6 = new OleDbCommand(comandoSql6, conexao);

            comando1.Parameters.Add("@ID1", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando2.Parameters.Add("@ID2", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando3.Parameters.Add("@ID3", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando4.Parameters.Add("@ID4", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando5.Parameters.Add("@ID5", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando6.Parameters.Add("@ID6", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);

            comando1.Parameters.Add("@CPF", OleDbType.Integer).Value = Convert.ToInt32(funcionario.cpf);
            comando1.Parameters.Add("@NOME", OleDbType.VarChar, 30).Value = funcionario.nome;
            comando1.Parameters.Add("@SENHA", OleDbType.VarChar, 10).Value = funcionario.senha;
            comando2.Parameters.Add("@RA", OleDbType.Integer).Value = Convert.ToInt32(funcionario.ra);
            //comando.Parameters.Add("@CT", OleDbType.Integer).Value = Convert.ToInt32(funcionario.carteira_trabalho);
            //comando.Parameters.Add("@IDADE", OleDbType.Date).Value = Convert.ToDateTime(funcionario.idade);
            comando3.Parameters.Add("@TEL1", OleDbType.Integer).Value = Convert.ToInt32(funcionario.contatos.tel1);
            comando3.Parameters.Add("@TEL2", OleDbType.Integer).Value = Convert.ToInt32(funcionario.contatos.tel2);
            //comando3.Parameters.Add("@EMAIL", OleDbType.VarChar, 50).Value = funcionario.contatos.email;
            comando4.Parameters.Add("@RUA", OleDbType.VarChar, 255).Value = funcionario.rua;
            comando4.Parameters.Add("@BAIRRO", OleDbType.VarChar, 255).Value = funcionario.bairro;
            //comando.Parameters.Add("@N", OleDbType.Integer).Value = Convert.ToInt16(funcionario.numero);
            comando4.Parameters.Add("@CIDADE", OleDbType.VarChar, 255).Value = funcionario.cidade;
            comando4.Parameters.Add("@ESTADO", OleDbType.VarChar, 255).Value = funcionario.estado;
            //comando.Parameters.Add("@CEP", OleDbType.Integer).Value = Convert.ToInt16(funcionario.cep);
            comando5.Parameters.Add("@CARGO", OleDbType.VarChar, 255).Value = empresa.cargo;
            comando6.Parameters.Add("@SB", OleDbType.Integer).Value = Convert.ToInt32(contrato.salario_bruto);

            try
            {
                conexao.Open();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();
                comando3.ExecuteNonQuery();
                comando4.ExecuteNonQuery();
                comando5.ExecuteNonQuery();
                comando6.ExecuteNonQuery();
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

        public void deleteFun(funcionario funcionario)
        {

            string comandoSql1 = "DELETE FROM [Funcionario_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql2 = "DELETE FROM [Contato_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql3 = "DELETE FROM [Endereco_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql4 = "DELETE FROM [Contrato_tbl$] WHERE [Id_Usuario] = @ID;";
            string comandoSql5 = "DELETE FROM [Empresa_tbl$] WHERE [Id_Usuario] = @ID";
            string comandoSql6 = "DELETE FROM [Usuario_tbl$] WHERE [Id_Usuario] = @ID;";


            OleDbCommand comando1 = new OleDbCommand(comandoSql1, conexao);
            OleDbCommand comando2 = new OleDbCommand(comandoSql2, conexao);
            OleDbCommand comando3 = new OleDbCommand(comandoSql3, conexao);
            OleDbCommand comando4 = new OleDbCommand(comandoSql4, conexao);
            OleDbCommand comando5 = new OleDbCommand(comandoSql5, conexao);
            OleDbCommand comando6 = new OleDbCommand(comandoSql6, conexao);

            comando1.Parameters.Add("@ID1", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando2.Parameters.Add("@ID2", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando3.Parameters.Add("@ID3", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando4.Parameters.Add("@ID4", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando5.Parameters.Add("@ID5", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando6.Parameters.Add("@ID6", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            try
            {
                conexao.Open();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();
                comando3.ExecuteNonQuery();
                comando4.ExecuteNonQuery();
                comando5.ExecuteNonQuery();
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
        /*public bool verifLogin(funcionario funcionario) //como não é possivel usar parametros sql, será retornado tipo bool
        {

            string comandoSql = "SELECT * FROM [Usuario_tbl$] WHERE [Nome] = @Nome AND [Senha] = @Senha";

            OleDbCommand comando = new OleDbCommand(comandoSql, conexao);

            comando.Parameters.Add("@Nome", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);
            comando.Parameters.Add("@Senha", OleDbType.Integer).Value = Convert.ToInt32(funcionario.numUser);

            try
            {

            conexao.Open();
            OleDbDataReader rd = comando.ExecuteReader();

            while (rd.Read())
            {
                funcionario.nome = Convert.ToString(rd["Nome"]);
                funcionario.senha = Convert.ToString(rd["Senha"]);
            }
            conexao.Close();
            return true;                 
        }
            catch
            {
                MessageBox.Show("Erro ao buscar dados");
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }*/
    }
}