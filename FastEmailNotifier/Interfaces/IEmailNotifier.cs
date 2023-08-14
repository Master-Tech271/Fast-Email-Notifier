﻿using FastEmailNotifier.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastEmailNotifier.Interfaces
{
    public interface IEmailNotifier
    {
        Task NotifyAsync(EmailMessage message);
    }
}
