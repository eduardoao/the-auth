using System;
using System.Collections.Generic;
using System.Text;

namespace Authenticator.Core.Interface
{
    public interface IJwtFactory
    {
        string EncodeToken(string userName);
    }
}
