using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.RegularExpressions;
using EPiServer.Core;
using EPiServer.Personalization;
using EPiServer.Security;
using EPiServer.Web;
using Valtech.Sandbox.Communication.Implementation.Builder.Message.Entity;
using Valtech.Sandbox.Communication.Models.Pages;
using Valtech.Sandbox.Core.Infrastructure.Lazy;
using Valtech.Sandbox.UserAndIdentity.Manager;
using Valtech.Sandbox.UserAndIdentity.Manager.UserProfile.Entity;

namespace Valtech.Sandbox.Communication.Implementation.Builder.Message
{
    class MessageBuilder : IMessageBuilder
    {
        private readonly ILazy<ICommunicationSettings> _communicationSettings;

        public MessageBuilder(ILazy<ICommunicationSettings> communicationSettings)
        {
            this._communicationSettings = communicationSettings;
        }
        
        public IMessage BuildPersonalizedMessageForUser(string subject, string body, IUserProfile profile)
        {
            //Get the shell of our message (layout)
            string message = this._communicationSettings.Service.EmailMessageLayout.ToHtmlString();
            
            message = ReplacePersonalizationTokens(message, profile);
            message = ReplaceBodyToken(message, body);
            message = ReplaceRelativeUrlsWithAbsolute(message);

            return new Entity.Message() { Subject = subject, Content = message };
        }

        public IMessage BuildMessage(string subject, string body)
        {
            //Get the shell of our message (layout)
            string message = this._communicationSettings.Service.EmailMessageLayout.ToHtmlString();
            
            message = ReplaceRelativeUrlsWithAbsolute(message);
            message = ReplaceBodyToken(message, body);

            return new Entity.Message() { Subject = subject, Content = message };
        }

        private string ReplaceBodyToken(string message, string body)
        {
            if(message.Contains("{{body}}"))
            {
                message = message.Replace("{{body}}", body);
            }
            return message;
        }

        private string ReplacePersonalizationTokens(string message, IUserProfile profile)
        {
            if (message.Contains("{{username}}"))
            {
                message = message.Replace("{{username}}", profile.Username);
            }

            if (message.Contains("{{upselling}}"))
            {
                //Retrieve products to upsell via Valtech.Sandbox.Upselling contract
                //Skipped from this code sample for simplification reasons

                message = message.Replace("{{upselling}}", profile.Username);
            }

            return message;
        }

        private string ReplaceRelativeUrlsWithAbsolute(string message)
        {

            //Replace all relative urls with absolute
            var pattern = @"(?<name>src|href)=""(?<value>/[^""]*)""";

            MatchEvaluator matchEvaluator = (
                match =>
                {
                    var value = match.Groups["value"].Value;
                    var attribute = match.Groups["name"].Value;
                    Uri uri;

                    //Try create the url
                    bool valid = Uri.TryCreate(SiteDefinition.Current.SiteUrl, value, out uri);

                    if (valid)
                        return string.Format("{0}=\"{1}\"", attribute, uri.OriginalString);

                    return null;
                });

            //Replace all relative urls with absolute
            return Regex.Replace(message, pattern, matchEvaluator);

        }
    }
}
