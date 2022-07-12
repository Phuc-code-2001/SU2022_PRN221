using System.Collections.Generic;

namespace ShinyTeeth.Utils
{

    public class Message
    {
        public string Type { get; set; }
        public string Content { get; set; }

        public Message ToSuccess()
        {
            Type = MessageTypes.Success;
            return this;
        }
        public Message ToDanger()
        {
            Type = MessageTypes.Danger;
            return this;
        }
        public Message ToInfo()
        {
            Type = MessageTypes.Info;
            return this;
        }
        public Message ToWarning()
        {
            Type = MessageTypes.Warning;
            return this;
        }
        public Message ToPrimary()
        {
            Type = MessageTypes.Primary;
            return this;
        }
        public Message ToSecondary()
        {
            Type = MessageTypes.Secondary;
            return this;
        }
        
    }

    public class MessageTypes
    {
        public static string Success = "success";
        public static string Danger = "danger";
        public static string Info = "info";
        public static string Warning = "warning";
        public static string Primary = "primary";
        public static string Secondary = "secondary";
    }

    public class MessageList : List<Message>
    {
        
    }

}
