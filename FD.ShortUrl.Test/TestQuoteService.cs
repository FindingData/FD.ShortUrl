using FD.ShortUrl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Test
{
    // Quote ©1975 BBC: The Doctor (Tom Baker); Pyramids of Mars
    // https://www.bbc.co.uk/programmes/p00pys55
    public class TestQuoteService : IQuoteService
    {
        public Task<string> GenerateQuote()
        {
            return Task.FromResult<string>(
                "Something's interfering with time, Mr. Scarman, " +
                "and time is my business.");
        }
    }
}
