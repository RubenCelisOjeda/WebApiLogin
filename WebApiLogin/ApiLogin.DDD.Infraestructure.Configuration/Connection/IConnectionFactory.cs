using System.Data;

namespace ApiLogin.DDD.Infraestructure.Configuration.Connection
{
    public interface IConnectionFactory
    {
        public IDbConnection GetConnectionSeguridad { get; }
    }
}
