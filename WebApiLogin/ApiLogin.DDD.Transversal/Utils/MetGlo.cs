using System.Net.Mail;

namespace ApiLogin.DDD.Transversal.Utils
{
    public static class MetGlo
    {
        #region [Properties]

        #endregion

        #region [Constructor]

        #endregion

        #region [Methods]
        public static bool IsEmail(string pEmail)
        {
            bool correcto = false;

            try
            {
                new MailAddress(pEmail);
                correcto = false;
            }
            catch (Exception ex)
            {
                correcto = false;
            }
            return correcto;
        }
        #endregion
    }
}
