using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastEmailNotifier.Interfaces
{
    public interface IEmailLogger
    {
        Task LogErrorAsync(string errorMessage);
    }
}
