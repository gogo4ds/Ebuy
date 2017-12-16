using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Ebuy.Web.Models.ManageViewModels
{
    using Microsoft.AspNetCore.Authentication;

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationScheme> OtherLogins { get; set; }
    }
}
