using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using jini;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotspring
{
    public partial class Medical : Form
    {
        public Medical()
        {
            InitializeComponent();
        }

        private string Config_Path = Application.StartupPath + "\\Config.ini";

        string serialPort1_text;

        const int byteMessage_max_Hex = 16;
        const int byteMessage_max_Ascii = 256;

        byte[] byteMessage_A = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_A = 0;

        //        byte command[255];
        //        command[0] = 0x06;
        //        command[1] = 0x01;
        //        command[2] = 0xE0;
        //        command[3] = 0x00;
        //        command[4] = (byte) hScrollBar_setvalue.Value;


        //        command[5] = calculate_checksum(command,5);
        //  RS232(command,6);


        private void hScrollBar_setvalue_Scroll(object sender, ScrollEventArgs e)
        {
            byte [] command = new byte[6];
            command[0] = 0x06;
            command[1] = 0x01;
            command[2] = 0xE0;
            command[3] = 0x00;
            command[4] = (byte)hScrollBar_setvalue.Value;
            command[5] = XOR(command, 5);

            if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == false)          //送至Comport
            {
                Open_serialPort1();
                serialPort1.Write(command,0,command.Length);
            }
            else if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == true)          //送至Comport
            {
                serialPort1.Write(command, 0, command.Length);
            }
        }


        private void button_getvalue_Click(object sender, EventArgs e)
        {
            byte[] command = new byte[5];
            command[0] = 0x05;
            command[1] = 0x01;
            command[2] = 0xE0;
            command[3] = 0x01;
            command[4] = XOR(command, 4);

            if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == false)          //送至Comport
            {
                Open_serialPort1();
                serialPort1.Write(command, 0, command.Length);
            }
            else if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == true)          //送至Comport
            {
                serialPort1.Write(command, 0, command.Length);
            }
        }

        public static byte XOR(byte[] bHEX1, int length)
        {
            byte bHEX_OUT = bHEX1[0];
            for (int i = 1; i < length; i++)
            {
                bHEX_OUT = (byte)(bHEX_OUT ^ bHEX1[i]);
            }
            return bHEX_OUT;
        }

        //  開啟SerialPort
        protected void Open_serialPort1()
        {
            try
            {
                if (serialPort1.IsOpen == false)
                {
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.PortName = ini12.INIRead(Config_Path, "serialPort1", "PortName", "");
                    serialPort1.BaudRate = int.Parse((ini12.INIRead(Config_Path, "serialPort1", "BaudRate", "")));
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = (Parity)0;
                    serialPort1.ReceivedBytesThreshold = 1;
                    serialPort1.Open();
                }
            }
            catch (Exception Ex)
            {
                ini12.INIWrite(Config_Path, "serialPort1", "Exist", "0");
                MessageBox.Show(Ex.Message.ToString(), "SerialPort1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  關閉SerialPort
        protected void Close_serialPort1()
        {
            serialPort1.Dispose();
            serialPort1.Close();
        }

        //  SerialPort分析
        private void serialPort1_analysis()
        {
            while (serialPort1.IsOpen == true)
            {
                int data_to_read = serialPort1.BytesToRead;
                if (data_to_read > 0)
                {
                    byte[] dataset = new byte[data_to_read];
                    serialPort1.Read(dataset, 0, data_to_read);

                    for (int index = 0; index < data_to_read; index++)
                    {
                        byte input_ch = dataset[index];
                        serialPort1_recorder(input_ch);
                    }
                }
            }
        }

        //  SerialPort記錄
        private void serialPort1_recorder(byte ch, bool SaveToLog = false)
        {
            if ((ch == 0x0A) || (byteMessage_length_A >= byteMessage_max_Ascii))
            {
                string dataValue = Encoding.ASCII.GetString(byteMessage_A).Substring(0, byteMessage_length_A);
                DateTime dt = DateTime.Now;
                string logValue = "[Receive_serialport1] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + dataValue + "\r\n"; //OK
                serialPort1_text = string.Concat(serialPort1_text, logValue);
                byteMessage_length_A = 0;
            }
            else
            {
                byteMessage_A[byteMessage_length_A] = ch;
                byteMessage_length_A++;
            }
        }
    }
}
