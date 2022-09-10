using System;

namespace WKTechnology.Common
{
    public class Config
    {
        private const string SERVER = "194.163.149.65";
        private const string DB_NAME = "Almoxt";
        private const string USER = "sysdba";
        private const string PASSWORD = "L$5a7*(B";
        public string GetConnectionString()
        {
            return $@"server={SERVER};database={DB_NAME};user={USER};password={PASSWORD}";
        }
    }
}
