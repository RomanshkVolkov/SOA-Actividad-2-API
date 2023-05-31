using Microsoft.EntityFrameworkCore;
using System.Data;
using Repository.Context;

namespace Repository.DAO
{
    public class SPRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public SPRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteStoredProcedureAsync(string spName, Dictionary<string, Object> parameters)
        {
            try
            {
                using var connection = _dbContext.Database.GetDbConnection();
                using var command = connection.CreateCommand();

                command.CommandText = spName;
                command.CommandType = CommandType.StoredProcedure;

                foreach (var parameter in parameters)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = parameter.Key;
                    dbParameter.Value = parameter.Value;

                    // Manejar tipos de datos booleanos
                    if (parameter.Value is bool)
                    {
                        dbParameter.Value = (bool)parameter.Value ? 1 : 0; // Convertir a 1 o 0
                        dbParameter.DbType = DbType.Boolean;
                    }

                    // Manejar tipos de datos de fecha
                    if (parameter.Value is DateTime)
                    {
                        dbParameter.DbType = DbType.DateTime;
                    }

                    command.Parameters.Add(dbParameter);
                }

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing stored procedure '{spName}': {ex.Message}");
            }
        }
    }
}
