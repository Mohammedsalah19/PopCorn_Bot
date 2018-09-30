using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using PopCorn.Models;
using System;

namespace PopCorn
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {

            if (activity.GetActivityType() == ActivityTypes.Message)
            {
                var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                const string apiKey = "&apikey=13ba01ba";

                var ss = activity.Text;

                var r = await AnalyzerHelper.analyze("http://www.omdbapi.com/?t=" + ss + apiKey);
                r
        

                var rep = activity.CreateReply(r.ToString());
               //   var po = await AnalyzerHelper.poster("http://www.omdbapi.com/?t=" + ss + apiKey);
               //// AnalyzerHelper h = new AnalyzerHelper();
               // rep.Attachments.Add(new Attachment()

               // {
               //     ContentUrl =po,
               //      ContentType = "image/jpg",
               //     Name = "film poster"

               // });

                await connector.Conversations.ReplyToActivityAsync(rep);

            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            string messageType = message.GetActivityType();
            if (messageType == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (messageType == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (messageType == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (messageType == ActivityTypes.Typing)
            {
                // Handle knowing that the user is typing
            }
            else if (messageType == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}