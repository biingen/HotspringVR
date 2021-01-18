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
using System.Threading;
using System.Collections;

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
        bool flag_receive = false;

        byte[] byteMessage_A = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_A = 0;

        Queue<byte> serialPortA = new Queue<byte>();
        Queue<List<byte>> dataListbyte = new Queue<List<byte>>();

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
            Thread LogA_analysis = new Thread(new ThreadStart(serialPortA_analysis));
            Thread LogA_record = new Thread(new ThreadStart(serialPortA_recorder));
            int check_packet = 0;

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
                LogA_analysis.Start();
                LogA_record.Start();
                serialPort1.Write(command,0,command.Length);
                flag_receive = true;
            }
            else if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == true)          //送至Comport
            {
                serialPort1.Write(command, 0, command.Length);
                flag_receive = true;
            }

            while (flag_receive) { }
            // 檢查封包是否回Ack或別的
            check_packet = check_Ack_packet();                     
            switch (check_packet)
            {
                case 0:
                    label_getvalue.Text = "No data";
                    break;
                case 1:
                    label_getvalue.Text = "ACK";
                    break;
                case 2:
                    label_getvalue.Text = "NACK";
                    break;
                case 3:
                    label_getvalue.Text = "NAV";
                    break;
            }
        }

        private int check_Ack_packet()
        {
            int value = 0;
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                if (log_analysis.Count == 4)
                {
                    if (log_analysis[1] == 0xFF)
                        value = 1;
                    else if (log_analysis[1] == 0xFE)
                        value = 2;
                    else if (log_analysis[1] == 0xFD)
                        value = 3;
                }

            }
            return value;
        }

        enum command_index
        {
            BACKLIGHT_INDEX = 0,
            RGB_GAIN_INDEX,
        }

        byte[][] Get_Value_Packet =
        {
            new byte[] { 0x05, 0x01, 0xE0, 0x01, 0xFF },          /// BACKLIGHT_INDEX
            new byte[] { 0x05, 0x00, 0xE0, 0x0D, 0xFF },          /// RGB_GAIN_INDEX
       };

        byte[][] Parsing_Packet =
        {
            new byte[] { 0x06, 0x01, 0xE0, 0x01 },          /// BACKLIGHT_INDEX
            new byte[] { 0x08, 0x00, 0xE0, 0x0D },          /// RGB_GAIN_INDEX
       };


        private void button_getvalue_Click(object sender, EventArgs e)
        {
            Thread LogA_analysis = new Thread(new ThreadStart(serialPortA_analysis));
            Thread LogA_record = new Thread(new ThreadStart(serialPortA_recorder));
 //           string check_packet = "";
            byte backlight_value;

           // int PACKET_INDEX = (int)command_index.BACKLIGHT_INDEX;
            byte[] command = new byte[5];
            command[0] = 0x05;
            command[1] = 0x01;
            command[2] = 0xE0;
            command[3] = 0x01;
            command[4] = XOR(command, 4);

             if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == false)          //送至Comport
            {
                Open_serialPort1();
                LogA_analysis.Start();
                LogA_record.Start();
                serialPort1.Write(command, 0, command.Length);
                flag_receive = true;
            }
            else if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == true)          //送至Comport
            {
                serialPort1.Write(command, 0, command.Length);
                flag_receive = true;
            }

            while (flag_receive) { }
            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();
                if(Parse_backlight_packet(log_analysis, out backlight_value)==true)
                {
                    label_getvalue.Text = backlight_value.ToString();
                }
                else
                {

                }
            }

        }

        // update out byte/int16/uint32/.....
        private bool Parse_backlight_packet(List<byte>input_packet, out byte return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.BACKLIGHT_INDEX;

            bool ret_value = true;
            return_value = 0;

            for (int index = 0; index < Parsing_Packet[PACKET_INDEX].Length; index++)
            {
                if (input_packet.ElementAt(index) != Parsing_Packet[PACKET_INDEX][index])
                {
                    ret_value = false;
                    break;
                }
            }

            if (ret_value==true)
            {
                // update here
                return_value = input_packet.ElementAt(4); 
            }

            return ret_value;
        }

        /*
        private bool Parse_rgb_gain_packet(List<byte> input_packet, out byte r_gain, out byte g_gain, out byte b_gain)
        {
            // update here
            int PACKET_INDEX = (int)command_index.RGB_GAIN_INDEX;

            bool ret_value = true;
            r_gain = g_gain = b_gain = 0;

            for (int index = 0; index < Parsing_Packet[PACKET_INDEX].Length; index++)
            {
                if (input_packet.ElementAt(index) != Parsing_Packet[PACKET_INDEX][index])
                {
                    ret_value = false;
                    break;
                }
            }

            if (ret_value == true)
            {
                r_gain = input_packet.ElementAt(4);
                g_gain = input_packet.ElementAt(5);
                b_gain = input_packet.ElementAt(6);
            }

            return ret_value;
        }


        private bool Parse_rgb_gain_packet(List<byte> input_packet, out byte []rgb_gain)
        {
            // update here
            int PACKET_INDEX = (int)command_index.RGB_GAIN_INDEX;

            bool ret_value = true;
            rgb_gain = new byte[3];

            for (int index = 0; index < Parsing_Packet[PACKET_INDEX].Length; index++)
            {
                if (input_packet.ElementAt(index) != Parsing_Packet[PACKET_INDEX][index])
                {
                    ret_value = false;
                    break;
                }
            }

            if (ret_value == true)
            {
                rgb_gain[0] = input_packet.ElementAt(4);
                rgb_gain[1] = input_packet.ElementAt(5);
                rgb_gain[2] = input_packet.ElementAt(6);
            }

            return ret_value;
        }
        */


        private string Check_value_packet()
        {
            string value = "No data";
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();
                if (log_analysis.Count > 4)
                    value = Convert.ToString(log_analysis[log_analysis.Count - 2], 10);
            }
            return value;
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

        public static byte XOR_List(List<byte> bHEX1 , int length)
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

        //  SerialPort 存入 Queue
        private void serialPortA_analysis()
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
                        serialPortA.Enqueue(input_ch);   // Enqueue rs232 data
                    }
                }
            }
        }

        //  SerialPort記錄
        private void serialPortA_recorder()
        {
            List<byte> DataLists = new List<byte>();
            while (serialPort1.IsOpen == true)
            {
                while (serialPortA.Count() > 0)                 //　Queue有資料就收取
                {
                    byte serial_byte = serialPortA.Dequeue();
                    DataLists.Add(serial_byte);                 //  Queue一個byte一個byte取出來被丟入List
                }

                if(DataLists.Count>=3)
                {
                    if(DataLists.ElementAt(2)!=0xE0)
                    {
                        DataLists.RemoveAt(0);
                    }
                    else
                    {
                        byte packet_len = DataLists.ElementAt(0);
                        if (DataLists.Count >= packet_len)
                        {
                            byte calculate_checksum;
                            calculate_checksum = XOR_List(DataLists, packet_len);
                            
                            if(calculate_checksum==0)
                            {
                                List<byte> CurrentDataList = new List<byte>();
                                CurrentDataList = DataLists.GetRange(0, packet_len);
                                dataListbyte.Enqueue(CurrentDataList);                  // Enqueue list byte data
                                flag_receive = false;
                                DataLists.RemoveRange(0, packet_len);
                            }
                            else
                            {
                                DataLists.RemoveAt(0);
                            }
                        }
                    }
                }
            }
        }
    }
}
