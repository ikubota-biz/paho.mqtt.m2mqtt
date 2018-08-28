/**
 * The intention of this is to allow for simple publish * subscribe applications and
 * easy unit testing
 * 
 * **/

using System;
using System.Collections.Generic;
using System.Text;

namespace uPLibrary.Networking.M2Mqtt
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MqttClient("localhost");
            client.MqttMsgPublishReceived += (s, m) => Console.WriteLine(Encoding.ASCII.GetString(m.Message));
            client.Connect(Guid.NewGuid().ToString());
            client.Subscribe(new String[] { "/#" }, new Byte[] { Messages.MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            Console.ReadKey();
        }
    }
}
