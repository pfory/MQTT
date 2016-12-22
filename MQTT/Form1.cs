using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        delegate void MojDelegat(MqttMsgPublishEventArgs MujObjekt);
        String BrokerIPAddr = "178.77.238.20";
        Topic topic1;
        Topic topic2;
        Topic topic3;
        Topic topic4;
        Topic topic5;
        Topic topic6;
        Topic topic7;
        Topic topic8;
        Topic topic9;
        Topic topic10;

        private struct Topic
        {
            public string topic, title;

            public Topic(string _topic, string _title)
            {
                topic = _topic;
                title = _title;
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create client instance
            MqttClient client = new MqttClient(IPAddress.Parse(BrokerIPAddr));
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            // register to message received

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId, "datel", "hanka12");

            topic1 = new Topic("/home/bedNew/esp03/tBedRoomOld", "Ložnice stará:");
            topic2 = new Topic("/home/bedNew/esp03/tLivingRoom", "Obývák:");
            topic3 = new Topic("/home/bedNew/esp03/tBedRoomNew", "Ložnice nová:");
            topic4 = new Topic("/home/bedNew/esp03/tHall", "Hala:");
            topic5 = new Topic("/home/bedNew/esp03/tBath", "Koupelna:");
            topic6 = new Topic("/home/bedNew/esp03/tWorkRoom", "Dílna:");
            topic7 = new Topic("/home/bedNew/esp03/tAttic", "Pod střechou:");
            topic8 = new Topic("/home/bedNew/esp03/tCorridor", "Chodba:");
            topic9 = new Topic("/home/EnergyMeter/esp02/Pulse", "Pulzů:");
            topic10 = new Topic("/home/EnergyMeter/esp02/pulseLength", "Délka pulzu:");

            // subscribe to the topic "/home/temperature" with QoS 2
            client.Subscribe(new string[] { topic1.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic2.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic3.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic4.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic5.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic6.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic7.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic8.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic9.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            client.Subscribe(new string[] { topic10.topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Invoke(new MojDelegat(Zobraz), e);
            
        }


        private void Zobraz(MqttMsgPublishEventArgs zprava)
        {
            String text = String.Empty;
            foreach (byte b in zprava.Message)
            {
                text += (char)b;
            }
            if (zprava.Topic == topic1.topic) {
                label1.Text = topic1.title + text + "°C";
            } else if (zprava.Topic == topic2.topic) {
                label2.Text = topic2.title + text + "°C";
            } else if (zprava.Topic == topic3.topic) {
                label3.Text = topic3.title + text + "°C";
            } else if (zprava.Topic == topic4.topic) {
                label4.Text = topic4.title + text + "°C";
            } else if (zprava.Topic == topic5.topic) {
                label5.Text = topic5.title + text + "°C";
            } else if (zprava.Topic == topic6.topic) {
                label6.Text = topic6.title + text + "°C";
            } else if (zprava.Topic == topic7.topic) {
                label7.Text = topic7.title + text + "°C";
            } else if (zprava.Topic == topic8.topic) {
                label8.Text = topic8.title + text + "°C"; 
            } else if (zprava.Topic == topic9.topic) {
                label9.Text = topic9.title + text;
                label11.Text = (float.Parse(text, CultureInfo.InvariantCulture) / 800).ToString() + "kWh";
            } else if (zprava.Topic == topic10.topic) {
                label10.Text = topic10.title + text;
                label12.Text = (4500000 / float.Parse(text, CultureInfo.InvariantCulture)).ToString() + "W";
            }
            lastUpdate.Text = System.DateTime.Now.ToString();
        }
    }
}
