using System.Data;
using System.Data.SqlClient;

namespace testeDapper.API;

public sealed class DbSession : IDisposable
{
    private Guid _id;
    private readonly ILogger<DbSession> _log;
    private readonly IConfiguration _config;
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }
    
    public DbSession(ILogger<DbSession> log, IConfiguration config)
    {
        _config = config;
        _log = log;
        _id = Guid.NewGuid();
        Connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        Connection.Open();
    }
    
    public void Dispose()
    {
        Connection?.Dispose();
        _log.LogInformation("Fechando conexão!");
    }
}