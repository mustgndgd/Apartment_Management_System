using Apartment.App.Web.Background;
using Apartment.App.Web.Models.MailModels;
using Microsoft.AspNetCore.Mvc;

namespace Apartment.App.Web.Controllers
{
    public class MailController : Controller
    {

        private readonly IBackgroundQueue<Mail> queue;

        public MailController(IBackgroundQueue<Mail> queue)
        {
            this.queue = queue;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody] Mail mail)
        {
            queue.Enqueue(mail);
            return Accepted();
        }
    }
}
