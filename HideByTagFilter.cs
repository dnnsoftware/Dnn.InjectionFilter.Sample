using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.UI.Modules;
using System;
using System.Linq;

namespace Dnn.InjectionFilter.Sample
{
    public class HideByTagFilter: IModuleInjectionFilter
    {
        public bool CanInjectModule(ModuleInfo module, PortalSettings portalSettings)
        {
            // Look for a Tag on the module named 'hide'
            var shouldHide = module.Terms.Any(t => string.Compare(t.Name, "hide", StringComparison.InvariantCultureIgnoreCase) == 0);
            var user = UserController.Instance.GetCurrentUserInfo();
            
            // Only hide the module for non-admins
            return user.IsSuperUser || user.IsInRole("Administrators") || !shouldHide;
        }
    }
}
