using ColdBananaUmbraco.Models;
using System.Net.Mail;
using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace ColdBananaUmbraco.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/";
        public ActionResult ContactForm()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "Index.cshtml");
        }

        [HttpPost]
        public ActionResult SubmitForm(Contact model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                TempData["ContactSuccess"] = true;
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(Contact model)
        {
            MailMessage message = new MailMessage(model.EmailAddress, "careers@coldbanana.com");
            message.Subject = string.Format("Enquiry from {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            message.Body = model.Message;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = false;
            client.Port = 25;
            client.Host = "127.0.0.1";
            try
            {
                client.Send(message);
            }

            catch
            {
                TempData["ContactSuccess"] = false;
            }
        }
    }
}
