using FD.ShortUrl.Domain;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace FD.ShortUrl.Api
{
    public class MyConfigValidation : IValidateOptions<PositionOption>
    {
        public PositionOption _config { get; private set; }

        public MyConfigValidation(IConfiguration config)
        {
            _config = config.GetSection(PositionOption.PositionOptions)
                .Get<PositionOption>();
        }

        public ValidateOptionsResult Validate(string name, PositionOption options)
        {
            string? vor = null;
            var rx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
            var match = rx.Match(options.Name!);

            if (string.IsNullOrEmpty(match.Value))
            {
                vor = $"{options.Name} doesn't match RegEx \n";
            }

            if (options.Value < 0 || options.Value > 1000)
            {
                vor = $"{options.Value} doesn't match Range 0 - 1000 \n";
            }

            if (options.Value2 != default)
            {
                if (options.Value <= options.Value2)
                {
                    vor += "Key3 must be > than Key2.";
                }
            }

            if (vor != null)
            {
                return ValidateOptionsResult.Fail(vor);
            }

            return ValidateOptionsResult.Success;
        }

    }
}
