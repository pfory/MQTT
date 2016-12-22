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

        Topic[] topic = new Topic[10];
        Label[] label = new Label[10];

        private struct Topic
        {
            public string topic, title, unit, tab;

            public Topic(string _topic, string _title, string _unit, string _tab)
            {
                topic = _topic;
                title = _title;
                unit = _unit;
                tab = _tab;
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

            topic[0] = new Topic("/home/bedNew/esp03/tBedRoomOld", "Ložnice stará:", "°C", "Mistnosti");
            topic[1] = new Topic("/home/bedNew/esp03/tLivingRoom", "Obývák:", "°C", "Mistnosti");
            topic[2] = new Topic("/home/bedNew/esp03/tBedRoomNew", "Ložnice nová:", "°C", "Mistnosti");
            topic[3] = new Topic("/home/bedNew/esp03/tHall", "Hala:", "°C", "Mistnosti");
            topic[4] = new Topic("/home/bedNew/esp03/tBath", "Koupelna:", "°C", "Mistnosti");
            topic[5] = new Topic("/home/bedNew/esp03/tWorkRoom", "Dílna:", "°C", "Mistnosti");
            topic[6] = new Topic("/home/bedNew/esp03/tAttic", "Pod střechou:", "°C", "Mistnosti");
            topic[7] = new Topic("/home/bedNew/esp03/tCorridor", "Chodba:", "°C", "Mistnosti");
            topic[8] = new Topic("/home/EnergyMeter/esp02/Pulse", "Pulzů:", "", "Elektromery");
            topic[9] = new Topic("/home/EnergyMeter/esp02/pulseLength", "Délka pulzu:", "ms", "Elektromery");


            for (int i = 0; i < label.Length; i++)
            {
                label[i] = new Label();
                label[i].Left = 10;
                label[i].Top = i * 15 + 10;
                label[i].Height = 15;
                label[i].Width = 150;
                label[i].TextAlign = ContentAlignment.TopRight;
                
                tabControl1.TabPages[topic[i].tab].Controls.Add(label[i]);
            }

            // subscribe to the topic "/home/temperature" with QoS 2
            for (int i = 0; i < topic.Length; i++)
            {
                client.Subscribe(new string[] { topic[i].topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }


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
            for (int i = 0; i < topic.Length; i++)
            {
                if (zprava.Topic == topic[i].topic)
                {
                    label[i].Text = topic[i].title + text + topic[i].unit;
                }
            }
            //    label11.Text = (float.Parse(text, CultureInfo.InvariantCulture) / 800).ToString() + "kWh";
            //} else if (zprava.Topic == topic[10].topic) {
            //    label10.Text = topic10.title + text;
            //    label12.Text = (4500000 / float.Parse(text, CultureInfo.InvariantCulture)).ToString() + "W";
            //}
            lastUpdate.Text = System.DateTime.Now.ToString();
        }
    }
}
