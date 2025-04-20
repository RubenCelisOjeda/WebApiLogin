using ApiLogin.Domain.Entities.RecoveryPassword.Request.ExistsCodeEmail;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.ExistsEmail;
using ApiLogin.Domain.Entities.RecoveryPassword.Request.SendCodeEmail;

namespace ApiLogin.Domain.Repository
{
    public interface IRecoveryPasswordRepository
    {
        public Task<bool> SendCodeEmail(SendCodeEmailRequestEntities request);
        public Task<bool> ExistsCodeEmail(ExistsCodeEmailRequestEntities request);
        public Task<bool> ExistsEmail(ExistsEmailRequestEntities request);
    }
}
