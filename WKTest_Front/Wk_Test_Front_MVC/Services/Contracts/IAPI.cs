using System.IO;

namespace Wk_Test_Front_MVC.Services.Contracts
{
    public interface IAPI
    {
        public string ExecuteRequest(string method, string url, object? content);
    }
}
