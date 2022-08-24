using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using SOE.Interfaces;

namespace SOE.Core
{
    public delegate void DelSOEMessageHandler(SOEClient sender, SOEMessage message);

    [AttributeUsage(AttributeTargets.Method)]
    public class SOEMessageHandler : Attribute
    {
        public string MessageName;
        public string Protocol;
        public ushort OpCode;

        public SOEMessageHandler(string messageName, ushort opCode, string protocol="SOE")
        {
            MessageName = messageName;
            Protocol = protocol;
            OpCode = opCode;
        }
    }

    public static class MessageHandlers
    {
        public static Dictionary<string, Dictionary<ushort, string>> Protocol2MessageName =
            new Dictionary<string, Dictionary<ushort, string>>();

        public static Dictionary<string, Dictionary<ushort, DelSOEMessageHandler>> Protocol2Handlers =
            new Dictionary<string, Dictionary<ushort, DelSOEMessageHandler>>();

        private static bool Initalized = false;

        public static void Initialize()
        {
            if (Initalized)
                return;

            LoadMessageHandlers();
            Initalized = true;
        }

        private static void LoadMessageHandlers()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
                    {
                        SOEMessageHandler handlerAttribute = (SOEMessageHandler)method
                            .GetCustomAttributes(typeof(SOEMessageHandler), false).SingleOrDefault();

                        if (handlerAttribute != null)
                        {
                            Delegate del = Delegate.CreateDelegate(typeof(DelSOEMessageHandler), method);
                            DelSOEMessageHandler handler = (DelSOEMessageHandler) del;

                            if (handlerAttribute.Protocol == "SOE")
                            {
                                for (int i = 0; i < Protocol2Handlers.Keys.Count; i++)
                                {
                                    string protocol = Protocol2Handlers.Keys.ElementAt(i);
                                    Protocol2Handlers[protocol].Add(handlerAttribute.OpCode, handler);
                                    Protocol2MessageName[protocol].Add(handlerAttribute.OpCode, handlerAttribute.MessageName);
                                }
                            }
                            else
                            {
                                if (!Protocol2Handlers.ContainsKey(handlerAttribute.Protocol))
                                {
                                    Protocol2Handlers.Add(handlerAttribute.Protocol, new Dictionary<ushort, DelSOEMessageHandler>());
                                }

                                Protocol2Handlers[handlerAttribute.Protocol].Add(handlerAttribute.OpCode, handler);
                                Protocol2MessageName[handlerAttribute.Protocol].Add(handlerAttribute.OpCode, handlerAttribute.MessageName);
                            }
                        }
                    }
                }
            }
        }

        public static bool HasHandler(string protocol, ushort OpCode)
        {
            if (Protocol2Handlers.ContainsKey(protocol))
            {
                if (Protocol2Handlers[protocol].ContainsKey(OpCode))
                {
                    return true;
                }
            }

            return false;
        }

        public static DelSOEMessageHandler GetHandler(string protocol, ushort OpCode)
        {
            return Protocol2Handlers[protocol][OpCode];
        }

        public static void MakeProtocol(string protocol)
        {
            Protocol2Handlers.Add(protocol, new Dictionary<ushort, DelSOEMessageHandler>());
            Protocol2MessageName.Add(protocol, new Dictionary<ushort, string>());
        }
    }
}
