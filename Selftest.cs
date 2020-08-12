using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jini;
using System.Threading;
using System.IO.Ports;
using System.Globalization;

namespace Hotspring
{
    public partial class Selftest : Form
    {
        private string Config_Path = Application.StartupPath + "\\Config.ini";

        List<int> primeLists;
        string serialPort1_text, serialPort2_text;
        int resistance_value = 0;
        double target_resistance_value = 0;

        const int byteMessage_max_Hex = 16;
        const int byteMessage_max_Ascii = 256;

        bool port_status = false;
        bool flag_receive = false;
        byte[] byteMessage_A = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_A = 0;
        byte[] byteMessage_B = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_B = 0;

        string output_csv = "Hotspring Value, Fluke receive current value, Fluke receive deduction resistance value, Percentage, " + Environment.NewLine;

        public Selftest()
        {
            InitializeComponent();
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

        //  開啟SerialPort
        protected void Open_serialPort2()
        {
            try
            {
                if (serialPort2.IsOpen == false)
                {
                    serialPort2.StopBits = StopBits.One;
                    serialPort2.PortName = ini12.INIRead(Config_Path, "serialPort2", "PortName", "");
                    serialPort2.BaudRate = int.Parse((ini12.INIRead(Config_Path, "serialPort2", "BaudRate", "")));
                    serialPort2.DataBits = 8;
                    serialPort2.Parity = (Parity)0;
                    serialPort2.ReceivedBytesThreshold = 1;
                    serialPort2.Open();
                }
            }
            catch (Exception Ex)
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "0");
                MessageBox.Show(Ex.Message.ToString(), "serialPort2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  關閉SerialPort
        protected void Close_serialPort2()
        {
            serialPort2.Dispose();
            serialPort2.Close();
        }

        //  SerialPort分析
        private void serialPort2_analysis()
        {
            while (serialPort2.IsOpen == true)
            {
                int data_to_read = serialPort2.BytesToRead;
                if (data_to_read > 0)
                {
                    byte[] dataset = new byte[data_to_read];
                    serialPort2.Read(dataset, 0, data_to_read);

                    for (int index = 0; index < data_to_read; index++)
                    {
                        byte input_ch = dataset[index];
                        serialPort2_recorder(input_ch);
                    }
                }
            }
        }

        //  SerialPort記錄
        private void serialPort2_recorder(byte ch, bool SaveToLog = false)
        {
            if ((ch == 0x0A) || (byteMessage_length_B >= byteMessage_max_Ascii))
            {
                string dataValue = Encoding.ASCII.GetString(byteMessage_B).Substring(0, byteMessage_length_B);
                DateTime dt = DateTime.Now;
                string logValue = "[Receive_serialport2] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + dataValue + "\r\n"; //OK
                serialPort2_text = string.Concat(serialPort2_text, logValue);
                if (dataValue.Contains("E"))
                {
                    double receive = double.Parse(dataValue, CultureInfo.InvariantCulture);
                    if (receive != 0)
                        output_csv = string.Concat(output_csv, receive + ",");
                    double resistance = Convert.ToSingle(textBox_resistance.Text);
                    if (resistance != 0 && receive > 512)
                    {
                        resistance = 0;
                    }
                    output_csv = string.Concat(output_csv, receive - resistance + ",");
                    double percentage = (receive - resistance - target_resistance_value) / target_resistance_value;
                    output_csv = string.Concat(output_csv, percentage + "," + Environment.NewLine);
                    flag_receive = false;
                }
                byteMessage_length_B = 0;
            }
            else
            {
                byteMessage_B[byteMessage_length_B] = ch;
                byteMessage_length_B++;
            }
        }

        private void checkBox_RA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RA.Checked == true)
            {
                checkBox_RB.Checked = false;
                checkBox_RC.Checked = false;
            }
        }

        private void checkBox_RB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RB.Checked == true)
            {
                checkBox_RA.Checked = false;
                checkBox_RC.Checked = false;
            }
        }

        private void checkBox_RC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RC.Checked == true)
            {
                checkBox_RA.Checked = false;
                checkBox_RB.Checked = false;
            }
        }

        private void textBox_resistance_TextChanged(object sender, EventArgs e)
        {
            check_resistance_value();
        }

        private void button_prime_Click(object sender, EventArgs e)
        {
            Thread SelfThread = new Thread(new ThreadStart(SelfModefunction));
            primeLists = new List<int> { 2, 3, 5, 7, 10, 11, 13, 17, 19 };
            SelfThread.Start();
        }

        private void button_prime2_Click(object sender, EventArgs e)
        {
            Thread SelfThread = new Thread(new ThreadStart(SelfModefunction));
            primeLists = new List<int> { 2 };
            SelfThread.Start();
        }

        private void button_prime10_Click(object sender, EventArgs e)
        {
            Thread SelfThread = new Thread(new ThreadStart(SelfModefunction));
            primeLists = new List<int> { 10 };
            SelfThread.Start();
        }
        
        private void check_resistance_value()
        {
            int resistance_number = 0;
            bool textBox_resistance_bool = Int32.TryParse(textBox_resistance.Text, out resistance_number);

            if (textBox_resistance_bool)
                resistance_value = resistance_number;
            else
                resistance_value = 0;
        }

        private void SelfModefunction()
        {
            if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")          //送至Comport
            {
                for (int i = 0; i < primeLists.Count; i++)
                {
                    int endvalue = 1048575;
                    int delay = 2000;
                    string frontdata, receive_command = "VAL?";

                    if (checkBox_RA.Checked == true && serialPort1.IsOpen == true)
                    {
                        frontdata = "set RA ";
                        send_basis_command(endvalue, delay, primeLists[i], frontdata, receive_command);
                    }
                    else if (checkBox_RB.Checked == true && serialPort1.IsOpen == true)
                    {
                        frontdata = "set RB ";
                        send_basis_command(endvalue, delay, primeLists[i], frontdata, receive_command);
                    }
                    else if (checkBox_RC.Checked == true && serialPort1.IsOpen == true)
                    {
                        frontdata = "set RC ";
                        send_basis_command(endvalue, delay, primeLists[i], frontdata, receive_command);
                    }
                }
            }

            while (flag_receive) { }
            Output_csv_log();
        }

        private void button_port_Click(object sender, EventArgs e)
        {
            Thread LogAThread = new Thread(new ThreadStart(serialPort1_analysis));
            Thread LogBThread = new Thread(new ThreadStart(serialPort2_analysis));

            port_status = !port_status;
            if (port_status == true)
            {
                if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == false)          //送至Comport
                {
                    Open_serialPort1();
                    LogAThread.Start();
                }

                if (ini12.INIRead(Config_Path, "serialPort2", "Exist", "") == "1" && serialPort2.IsOpen == false)          //送至Comport
                {
                    Open_serialPort2();
                    LogBThread.Start();
                }
                button_port.Text = "Disconnect";
            }
            else
            {
                if (serialPort1.IsOpen == true)          //送至Comport
                {
                    LogAThread.Abort();
                    Close_serialPort1();
                }
                if (serialPort2.IsOpen == true)          //送至Comport
                {
                    LogBThread.Abort();
                    Close_serialPort2();
                }
                button_port.Text = "Connect";
            }
        }

        private void send_basis_command(int endvalue, int delay, int basis, string frontdata, string recevice_command)
        {
            int power = 1;
            long value = 0;
            while (value < endvalue && serialPort1.IsOpen == true)
            {
                try
                {
                    value = (long)Math.Pow(basis, power);
                    if (value < endvalue)
                    {
                        string send_data = frontdata + value;
                        while (flag_receive) { }
                        serialPort1.WriteLine(send_data);
                        target_resistance_value = value;
                        DateTime dt = DateTime.Now;
                        string send_serialport1_text = "[Send_serialport1] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + send_data + "\r\n";
                        serialPort1_text = string.Concat(serialPort1_text, send_serialport1_text);
                        output_csv = string.Concat(output_csv, value + ",");
                        Thread.Sleep(delay);
                        serialPort2.WriteLine(recevice_command);
                        dt = DateTime.Now;
                        string send_serialport2_text = "[Send_serialport2] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + recevice_command + "\r\n";
                        serialPort2_text = string.Concat(serialPort2_text, send_serialport2_text);
                        flag_receive = true;
                        power++;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString(), "SerialPort1 || SerialPort2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Output_csv_log()
        {
            DateTime myDate = DateTime.Now;
            if (checkBox_RA.Checked == true)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RA_Report.csv", true))
                {
                    try
                    {
                        file.Write(output_csv);
                        output_csv = "Hotspring Value, Fluke receive current value, Fluke receive deduction resistance value, Percentage, " + Environment.NewLine;
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RA_Serialport1.txt", true))
                {
                    if (serialPort1_text != "")
                    {
                        try
                        {
                            file.Write(serialPort1_text);
                            serialPort1_text = "";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RA_Serialport2.txt", true))
                {
                    if (serialPort2_text != "")
                    {
                        try
                        {
                            file.Write(serialPort2_text);
                            serialPort2_text = "";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (checkBox_RB.Checked == true)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RB_Report.csv", true))
                {
                    try
                    {
                        file.Write(output_csv);
                        output_csv = "Hotspring Value, Fluke receive current value, Fluke receive deduction resistance value, Percentage, " + Environment.NewLine;
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RB_Serialport1.txt", true))
                {
                    if (serialPort1_text != "")
                    {
                        try
                        {
                            file.Write(serialPort1_text);
                            serialPort1_text = "";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RB_Serialport2.txt", true))
                {
                    if (serialPort2_text != "")
                    {
                        try
                        {
                            file.Write(serialPort2_text);
                            serialPort2_text = "";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (checkBox_RC.Checked == true)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RC_Report.csv", true))
                {
                    try
                    {
                        file.Write(output_csv);
                        output_csv = "Hotspring Value, Fluke receive current value, Fluke receive deduction resistance value, Percentage, " + Environment.NewLine;
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RC_Serialport1.txt", true))
                {
                    if (serialPort1_text != "")
                    {
                        try
                        {
                            file.Write(serialPort1_text);
                            serialPort1_text = "";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_RC_Serialport2.txt", true))
                {
                    if (serialPort2_text != "")
                    {
                        try
                        {
                            file.Write(serialPort2_text);
                            serialPort2_text = "";
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "Output file Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
