using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace prjConnectionFactory
{
    /// <summary>
    /// =======================================================================
    /// Author:             Passos, Lucas
    /// Co-Author:          Henryque, Eduardo
    /// Create date:        01/06/2017
    /// Modification date:  02/06/2017
    /// Description:        Database Interface Layer
    /// Properties:         _connectionSql,
    ///                     _parameterCollection,
    ///                     _transaction
    /// Constructors:       Dil()
    /// Methods:            StartConnection(),
    ///                     BeginTran(),
    ///                     Commit(),
    ///                     Rollback(),
    ///                     AddParameter(string parameterName, object parameterValue),
    ///                     PrepareSqlCommand(CommandType commandtype, string command),
    ///                     ExecuteStoredProcedureQuery(string storedProcedureName),
    ///                     ExecuteStoredProcedureNonQuery(string storedProcedureName),
    ///                     ExecuteStoredProcedureScalar(string storedProcedureName),
    ///                     ClearParameterCollection(),
    ///                     CloseConnection()
    /// Dependencies:       System.Configuraton,
    ///                     System.Data.SqlClient,
    ///                     System.Data
    /// =======================================================================
    /// </summary>
    public class ConnectionFactory
    {
        #region PROPERTIES

        /// <summary>
        /// connectionSql representa uma conexão com um SQL Server banco de dados.
        /// </summary>
        private SqlConnection _connectionSql = null;

        /// <summary>
        /// SqlParameterCollection representa uma coleção de parâmetros associados a um SqlCommand
        /// e seus respectivos mapeamentos para colunas em um DataSet.
        /// DataSet representa dados em um cache de memória.
        /// </summary>
        private SqlParameterCollection _parameterCollection = new SqlCommand().Parameters;

        /// <summary>
        /// representa uma transação feita em um banco de dados SQL Server.
        /// </summary>
        private SqlTransaction _transaction;

        #endregion PROPERTIES

        #region CONSTRUCTORS

        /// <summary>
        /// Construtor iniciando uma conexão com o banco de dados
        /// </summary>
        public ConnectionFactory()
        {
            // Abre uma conexão com o banco de dados
            this._connectionSql = this.StartConnection();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Método que abre uma conexão com o banco de dados.
        /// </summary>
        /// <returns>
        /// Retorna uma nova Instâcia da classe SqlConnection com as configurações 
        /// de propriedade especificadas pelo ConnectionString.
        /// </returns>
        private SqlConnection StartConnection()
        {
            //Cria o objeto de conexão com o banco de dados passando no construtor a string de conexão vinda do App.config.
            this._connectionSql = new SqlConnection(ConfigurationManager.ConnectionStrings["minhaStringDeConexao"].ConnectionString);

            //Abre uma conexão de banco de dados usando as configurações de propriedade.
            _connectionSql.Open();

            //Retorna a conexão
            return _connectionSql;
        }

        /// <summary>
        /// Inicia uma transação com o banco de dados
        /// </summary>
        public void BeginTran()
        {
            //Guarda no SqlTransaction a transação iniciada no banco de dados
            _transaction = _connectionSql.BeginTransaction();
        }

        /// <summary>
        /// Confirma a transação do banco de dados e chama o método para fechar a conexão
        /// </summary>
        public void Commit()
        {
            //Confirma a transação do banco de dados.
            _transaction.Commit();

            //Limpa o SqlTransaction
            _transaction = null;

            //Fecha a conexão com o banco de dados.
            CloseConnection();
        }

        /// <summary>
        /// Reverte uma transação pendente do banco de dados  e chama o método para fechar a conexão
        /// </summary>
        public void Rollback()
        {
            //Reverte uma transação pendente
            _transaction.Rollback();

            //Limpa o SqlTransaction
            _transaction = null;

            //Fecha a conexão com o banco de dados.
            CloseConnection();
        }

        /// <summary>
        /// Método que adiciona parâmetros
        /// </summary>
        /// <param name="parameterName">nome do parâmetro</param>
        /// <param name="parameterValue">valor do parâmetro</param>
        public void AddParameter(string parameterName, object parameterValue)
        {
            //Adicionando os parâmetros na lista de parâmetros
            this._parameterCollection.Add(new SqlParameter(parameterName, parameterValue));
        }

        /// <summary>
        /// Prepara a stored procedure ou comando T-SQL para ser executado.
        /// </summary>
        /// <param name="commandtype">
        ///     Tipo do comando.
        ///     Os valores permitidos são: CommandType.StoredProcedure ou CommandType.Text.
        /// </param>
        /// <param name="command">Instrução Transact-SQL ou procedimento armazenado a ser executado.</param>
        /// <returns>Uma conexão com o database</returns>
        private SqlCommand PrepareSqlCommand(CommandType commandtype, string command)
        {
            // SqlCommand representa uma instrução Transact-SQL ou procedimento armazenado
            // para executar contra um banco de dados do SQL Server. Essa classe não pode ser herdada.
            SqlCommand sqlCommand = new SqlCommand()
            {
                // Associa o sqlCommand à conexão existente.
                Connection = this._connectionSql,

                // Define comando do tipo instrução Transact-SQL ou procedimento armazenado.
                CommandType = commandtype,

                // Define a instrução Transact-SQL ou o nome do procedimento armazenado.
                CommandText = command,

                // Tempo em segundos que o sistema aguarda pela execução da procedure.
                //CommandTimeout = int.Parse(ConfigurationManager.AppSettings["SqlTimeout"]),
            };

            //Adiciona a coleção de parametros no comando
            foreach (SqlParameter sqlParameter in _parameterCollection)
                sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));

            //Limpa a coleção de parametros
            ClearParameterCollection();

            //Verifica se tem alguma transação.
            if (_transaction != null)
                //adiciona a transação no comando.
                sqlCommand.Transaction = _transaction;

            return sqlCommand;
        }

        /// <summary>
        /// Executa uma stored procedure e retorna um datatable
        /// </summary>
        /// <param name="storedProcedureName">string storedProcedureName - nome da stored procedure</param>
        /// <returns>datatable contendo um conjunto de registros</returns>
        public DataTable ExecuteStoredProcedureQuery(string storedProcedureName)
        {
            // Preapara a stored procedure para execução
            SqlCommand sqlCommand = PrepareSqlCommand(CommandType.StoredProcedure, storedProcedureName);

            // SqlDataAdapter representa um conjunto de comandos de dados e uma conexão de banco de
            // dados que são usados para preencher o DataSet e atualizar um banco de dados do SQL Server.
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            // Representa uma tabela de dados na Memória.
            DataTable dataTable = new DataTable();

            // Manda o comando ir até o banco buscar os dados e o adaptador
            // preencher o dataTable
            sqlDataAdapter.Fill(dataTable);

            //Retorna o DataTable preenchido pela execução da stored procedure
            return dataTable;
        }

        /// <summary>
        /// Executa uma stored procedure que retorna as linhas afetadas
        /// </summary>
        /// <param name="storedProcedureName">Nome da stored procedure</param>
        /// <returns>Um valor inteiro</returns>
        public int ExecuteStoredProcedureNonQuery(string storedProcedureName)
        {
            // Preapara a stored procedure para execução
            SqlCommand sqlCommand = PrepareSqlCommand(CommandType.StoredProcedure, storedProcedureName);

            // Retorna o numero de registro afetados pela execução da stored procedure
            return sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Executa uma stored procedure que retorna um escalar
        /// </summary>
        /// <param name="storedProcedureName">Nome da stored procedure</param>
        /// <returns>Um objeto do banco</returns>
        public object ExecuteStoredProcedureScalar(string storedProcedureName)
        {
            // Preapara a stored procedure para execução
            SqlCommand sqlCommand = PrepareSqlCommand(CommandType.StoredProcedure, storedProcedureName);

            //Retorna a primeira linha da primeira coluna do conjunto de resultados
            return sqlCommand.ExecuteScalar();
        }

        /// <summary>
        /// Método que limpa a coleção de parametros.
        /// </summary>
        private void ClearParameterCollection()
        {
            //Limpa a coleção de parametros.
            _parameterCollection.Clear();
        }

        /// <summary>
        /// Método que fecha a conexão com o banco de dados.
        /// </summary>
        private void CloseConnection()
        {
            // Verifica se a conexão foi aberta.
            if (this._connectionSql.State == ConnectionState.Open)
            {
                //fecha a conexão com o banco de dados
                this._connectionSql.Close();
            }
        }

        #endregion METHODS
    }
}
