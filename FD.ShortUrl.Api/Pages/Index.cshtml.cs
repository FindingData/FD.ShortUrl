using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FD.ShortUrl.Core;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FD.ShortUrl.Api.Pages
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly TodoDb _db;
        private readonly IQuoteService _quoteService;

        public IndexModel(TodoDb db, IQuoteService quoteService)
        {
            _db = db;
            _quoteService = quoteService;
        }

       

        [BindProperty]
        public Todo TodoModel { get; set; }

        public IList<Todo> ToDos { get; private set; }

        [TempData]
        public string MessageAnalysisResult { get; set; }

        public string Quote { get; private set; }

       

        public async Task OnGetAsync()
        {
            ToDos = await _db.GetAsync();

            Quote = await _quoteService.GenerateQuote();
        }
        #endregion

        public async Task<IActionResult> OnPostAddMessageAsync()
        {
            if (!ModelState.IsValid)
            {
                ToDos = await _db.GetAsync();

                return Page();
            }

            var tokens = new InitialApplicationState
            {
                AccessToken = await HttpContext.GetTokenAsync("access_token"),
                RefreshToken = await HttpContext.GetTokenAsync("refresh_token")
            };


            await _db.AddAsync(TodoModel);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAllMessagesAsync()
        {
            await _db.DeleteAllAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteMessageAsync(int id)
        {
            await _db.DeleteAsync(id);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAnalyzeMessagesAsync()
        {
            ToDos = await _db.GetAsync();

            if (ToDos.Count == 0)
            {
                MessageAnalysisResult = "There are no messages to analyze.";
            }
            else
            {
                var wordCount = 0;

                foreach (var item in ToDos)
                {
                    wordCount += item.Name.Split(' ').Length;
                }

                var avgWordCount = Decimal.Divide(wordCount, ToDos.Count);
                MessageAnalysisResult = $"The average message length is {avgWordCount:0.##} words.";
            }

            return RedirectToPage();
        }
    }
}
