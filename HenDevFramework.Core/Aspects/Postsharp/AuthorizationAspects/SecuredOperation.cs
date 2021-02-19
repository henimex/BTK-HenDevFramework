using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace HenDevFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect //methoddan once calısacagı icin onmethod boundary cagrılır
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    Debug.WriteLine(System.Threading.Thread.CurrentPrincipal);
                    isAuthorized = true;
                }
            }

            if (!isAuthorized)
            {
                throw new SecurityException("You Are Not Authorized");
            }
        }
    }
}
