using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace DanceParties.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        protected StatusCodeResult NotImplemented()
        {
            return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
        }
    }
}
