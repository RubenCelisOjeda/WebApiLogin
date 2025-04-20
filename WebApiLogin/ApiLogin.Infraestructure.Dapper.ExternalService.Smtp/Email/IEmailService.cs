namespace ApiLogin.Infraestructure.Dapper.ExternalService.Smtp.Email
{
    public interface IEmailService 
    {
        public Task<bool> SendCodeEmail(string code);
    }
}
