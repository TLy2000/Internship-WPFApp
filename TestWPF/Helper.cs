/// Author
/// Thinh Ly
/// 11/12/2020
/// WPF app
///

using System.Configuration;

namespace WPFApp
{
    public class Helper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
