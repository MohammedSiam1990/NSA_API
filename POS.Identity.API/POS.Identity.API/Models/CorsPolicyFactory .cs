using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace POS.API.Models
{
  
public class CorsPolicyFactory : ICorsPolicyProviderFactory
{
    ICorsPolicyProvider _provider = new MyCorsPolicyAttribute();

    public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
    {
        return _provider;
    }
}
}