using System.Threading.Tasks;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FD.ShortUrl.Api.Controllers
{
    #region snippet_SessionController
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;

        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index), 
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            return Ok(viewModel);
        }
    }
    #endregion
}
