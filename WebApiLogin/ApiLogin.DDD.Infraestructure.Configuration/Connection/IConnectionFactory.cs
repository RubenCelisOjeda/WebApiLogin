using System.Data;

namespace ApiLogin.Infraestructure.Configuration.Connection
{
    public interface IConnectionFactory
    {
        public IDbConnection GetConnectionSeguridad { get; }
    }
}
