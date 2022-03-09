using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FD.ShortUrl.Repository
{
    public class EFConfigurationSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public EFConfigurationSource(Action<DbContextOptionsBuilder> optionsAction) => _optionsAction = optionsAction;

        public IConfigurationProvider Build(IConfigurationBuilder builder) => new EFConfigurationProvider(_optionsAction);
    }
}
