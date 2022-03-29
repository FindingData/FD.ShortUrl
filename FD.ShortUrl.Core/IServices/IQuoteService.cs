using System.Threading.Tasks;

namespace FD.ShortUrl.Core
{
    #region snippet1
    public interface IQuoteService
    {
        Task<string> GenerateQuote();
    }
    #endregion
}
