using Makonis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makonis.Services
{
    public interface IFileSaverService
    {
        string SaveUserDetailsToFile(User user);
    }
}
