using FastEmailNotifier.Interfaces;
using FastEmailNotifier.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastEmailNotifier
{
    public class EmailNotificationPackage
    {
        private List<EmailMessage> _emailBuffer = new List<EmailMessage>();
        private List<string> _errorBuffer = new List<string>();
        private List<EmailMessage> _notificationBuffer = new List<EmailMessage>();

        #region Add Email Message to buffer helper methods

        public void AddEmailToBuffer(EmailMessage message)
        {
            _emailBuffer.Add(message);
        }

        public void AddErrorToBuffer(string errorMessage)
        {
            _errorBuffer.Add(errorMessage);
        }

        public void AddNotificationToBuffer(EmailMessage message)
        {
            _notificationBuffer.Add(message);
        }

        #endregion

        #region FlushBuffer Multiple Overload Methods

        public async Task FlushEmailBufferAsync(IEmailSender emailSender)
        {
            await SendEmailsAsync(emailSender);
            ClearEmailBuffer();
        }

        public async Task FlushErrorBufferAsync(IEmailLogger emailLogger)
        {
            await LogErrorsAsync(emailLogger);
            ClearErrorBuffer();
        }

        public async Task FlushNotificationBufferAsync(IEmailNotifier emailNotifier)
        {
            await NotifyAsync(emailNotifier);
            ClearNotificationBuffer();
        }

        public async Task FlushBuffersAsync(IEmailSender emailSender)
        {
            await SendEmailsAsync(emailSender);
            ClearBuffers();
        }

        public async Task FlushBuffersAsync(IEmailLogger emailLogger)
        {
            await LogErrorsAsync(emailLogger);
            ClearBuffers();
        }

        public async Task FlushBuffersAsync(IEmailNotifier emailNotifier)
        {
            await NotifyAsync(emailNotifier);
            ClearBuffers();
        }

        public async Task FlushBuffersAsync(IEmailSender emailSender, IEmailLogger emailLogger)
        {
            await Task.WhenAll(
                SendEmailsAsync(emailSender),
                LogErrorsAsync(emailLogger)
            );

            ClearBuffers();
        }

        public async Task FlushBuffersAsync(IEmailSender emailSender, IEmailNotifier emailNotifier)
        {
            await Task.WhenAll(
                SendEmailsAsync(emailSender),
                NotifyAsync(emailNotifier)
            );

            ClearBuffers();
        }

        public async Task FlushBuffersAsync(IEmailLogger emailLogger, IEmailNotifier emailNotifier)
        {
            await Task.WhenAll(
                LogErrorsAsync(emailLogger),
                NotifyAsync(emailNotifier)
            );

            ClearBuffers();
        }

        public async Task FlushBuffersAsync(IEmailSender emailSender, IEmailLogger emailLogger, IEmailNotifier emailNotifier)
        {
            await Task.WhenAll(
                SendEmailsAsync(emailSender),
                LogErrorsAsync(emailLogger),
                NotifyAsync(emailNotifier)
            );

            ClearBuffers();
        }

        #endregion


        #region Clear Buffer's Overload Methods

        public void ClearEmailBuffer()
        {
            _emailBuffer.Clear();
        }

        public void ClearErrorBuffer()
        {
            _errorBuffer.Clear();
        }

        public void ClearNotificationBuffer()
        {
            _notificationBuffer.Clear();
        }

        #endregion


        #region Private Methods

        private async Task SendEmailsAsync(IEmailSender emailSender)
        {
            if (emailSender != null)
            {
                foreach (var message in _emailBuffer)
                {
                    await emailSender.SendEmailAsync(message);
                }
            }
        }

        private async Task LogErrorsAsync(IEmailLogger emailLogger)
        {
            if (emailLogger != null)
            {
                foreach (var errorMessage in _errorBuffer)
                {
                    await emailLogger.LogErrorAsync(errorMessage);
                }
            }
        }

        private async Task NotifyAsync(IEmailNotifier emailNotifier)
        {
            if (emailNotifier != null)
            {
                foreach (var message in _notificationBuffer)
                {
                    await emailNotifier.NotifyAsync(message);
                }
            }
        }

        private void ClearBuffers()
        {
            _emailBuffer.Clear();
            _errorBuffer.Clear();
            _notificationBuffer.Clear();
        }

        #endregion
    }
}
