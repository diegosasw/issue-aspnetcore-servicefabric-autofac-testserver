using System;
using Microsoft.AspNetCore.Mvc;

namespace SampleStatelessWebApi.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute
        : TypeFilterAttribute
    {
        public BasicAuthAttribute(string realm = "diegosasw samples")
            : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }
}
