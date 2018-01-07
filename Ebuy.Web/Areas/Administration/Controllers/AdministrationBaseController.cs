namespace Ebuy.Web.Areas.Administration.Controllers
{
    using Ebuy.Web.Common;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.Administration)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class AdministrationBaseController : BaseController
    {
    }
}