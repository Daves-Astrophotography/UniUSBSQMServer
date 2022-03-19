using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniUSBSQMServer
{
    public class SQMLatestMessageReading
    {

        //Singleton
        private static SQMLatestMessageReading? readings;
        private static readonly object syncRoot = new();


        public static SQMLatestMessageReading Readings
        {
            get
            {
                if (readings == null)
                {
                    lock (syncRoot)
                    {
                        if (readings == null)
                            readings = new SQMLatestMessageReading();
                    }
                }

                return readings;
            }
        }

        //latest readings, use command as key value
        private static readonly Dictionary<string, string> _messages = new();
        
        //accept only ix, rx, ux
        private static readonly string[]  _validCommands = new string[] { "ix", "rx", "ux" };
        
        public static bool HasReadingForCommand(string command)
        {
            return _messages.ContainsKey(command);
        }

        public static Dictionary<string,string> GetAllMessages()
        {
            return _messages;
        }

        public static bool GetReading(string command, out string? message)
        {
            
            if (_validCommands.Contains(command))
            {
                if (_messages.TryGetValue(command, out message))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception($"Invalid command {command}");
            }
        }

        public static void SetReading(string command, string message)
        {
            if (_validCommands.Contains(command))
                if (_messages.ContainsKey(command))
                {
                    _messages[command] = message;
                }
                else
                {
                    _messages.Add(command, message);
                }
            else
            {
                throw new Exception($"Invalid command {command}");
            }
               
        }

    }
}
