using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jini;
using System.Threading;
using System.IO;
using System.Globalization;

namespace Hotspring
{
    public partial class Form1 : Form
    {
        private string Config_Path = Application.StartupPath + "\\Config.ini";

        string serialPort1_text, serialPort2_text;
        string serialPort1_csv, serialPort2_csv;
        const int byteMessage_max_Hex = 16;
        const int byteMessage_max_Ascii = 256;

        bool start_button;
        bool flag_receive = false, flag_send = false;
        byte[] byteMessage_A = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_A = 0;
        byte[] byteMessage_B = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_B = 0;

        string output_csv = "Hotspring Value, Fluke receive value," + Environment.NewLine;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            Settings Settings = new Settings();

            if (Settings.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            Thread MainThread = new Thread(new ThreadStart(MainFunction));
            Thread LogAThread = new Thread(new ThreadStart(serialPort1_analysis));
            Thread LogBThread = new Thread(new ThreadStart(serialPort2_analysis));

            start_button = !start_button;
            if (start_button == true)
            {
                button_play.Text = "Stop";
                checkBox_RA.Enabled = false;
                checkBox_RB.Enabled = false;
                checkBox_RC.Enabled = false;
                textBox_startValue.Enabled = false;
                textBox_endValue.Enabled = false;
                textBox_delaytime.Enabled = false;
                textBox_step.Enabled = false;
                textBox_basis.Enabled = false;
                textBox_power.Enabled = false;
                button_settings.Enabled = false;

                if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")          //送至Comport
                {
                    Open_serialPort1();
                    LogAThread.Start();
                }
                if (ini12.INIRead(Config_Path, "serialPort2", "Exist", "") == "1")          //送至Comport
                {
                    Open_serialPort2();
                    LogBThread.Start();
                }

                MainThread.Start();
            }
            else
            {
                button_play.Text = "Play";
                checkBox_RA.Enabled = true;
                checkBox_RB.Enabled = true;
                checkBox_RC.Enabled = true;
                textBox_startValue.Enabled = true;
                textBox_endValue.Enabled = true;
                textBox_delaytime.Enabled = true;
                textBox_step.Enabled = true;
                textBox_basis.Enabled = true;
                textBox_power.Enabled = true;
                button_settings.Enabled = true;

                MainThread.Abort();
                if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")          //送至Comport
                {
                    Close_serialPort1();
                    LogAThread.Abort();
                }
                if (ini12.INIRead(Config_Path, "serialPort2", "Exist", "") == "1")          //送至Comport
                {
                    Close_serialPort2();
                    LogBThread.Abort();
                }
            }
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
                if (dataValue.Contains("E"))
                {
                    double receive = double.Parse(dataValue, CultureInfo.InvariantCulture);
                    if (receive != 0)
                        serialPort2_csv += receive + ";";
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

        private void MainFunction()
        {
            string frontdata, receive_command = "VAL?";
            if (start_button == true)
            {
                if (checkBox_RA.Checked == true || checkBox_RB.Checked == true || checkBox_RB.Checked == true || textBox_startValue.Text != "" && textBox_endValue.Text != "" && textBox_step.Text != "" && textBox_delaytime.Text != "")
                {
                    int startvalue = Convert.ToInt32(textBox_startValue.Text);
                    int endvalue = Convert.ToInt32(textBox_endValue.Text);
                    int step = Convert.ToInt32(textBox_step.Text);
                    int delay = Convert.ToInt32(textBox_delaytime.Text);
                    int basis = Convert.ToInt32(textBox_basis.Text);
                    int power = Convert.ToInt32(textBox_power.Text);

                    if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")          //送至Comport
                    {
                        if (checkBox_RA.Checked == true)
                        {
                            frontdata = "set RA ";
                            send_hotspring_command(startvalue, endvalue, step, delay, basis, power, frontdata, receive_command);
                        }
                        else if (checkBox_RB.Checked == true)
                        {
                            frontdata = "set RB ";
                            send_hotspring_command(startvalue, endvalue, step, delay, basis, power, frontdata, receive_command);
                        }
                        else if (checkBox_RC.Checked == true)
                        {
                            frontdata = "set RC ";
                            send_hotspring_command(startvalue, endvalue, step, delay, basis, power, frontdata, receive_command);
                        }
                    }

                    while (flag_receive) { }
                    Output_csv_log();
                }
            }
        }

        private void send_hotspring_command(int startvalue, int endvalue, int step, int delay, int basis, int power, string frontdata, string recevice_command)
        {
            if (step != 0)
            {
                for (int i = startvalue; i <= endvalue; i += step)
                {
                    if (start_button == true)
                    {
                        try
                        {
                            string send_data = frontdata + i;
                            while (flag_receive) { }
                            serialPort1.WriteLine(send_data);
                            serialPort1_csv += i + ";";
                            Thread.Sleep(delay);
                            while (flag_send) { }
                            serialPort2.WriteLine(recevice_command);
                            flag_receive = true;
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "SerialPort1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (basis != 0 && basis != 1 && power != 0)
            {
                int value = 0;
                for (long i = startvalue; i <= endvalue; i += (long)Math.Pow(basis, value))
                {
                    if (value < power)
                    {
                        try
                        {
                            string send_data = frontdata + i;
                            while (flag_receive) { }
                            serialPort1.WriteLine(send_data);
                            serialPort1_csv += i + ";";
                            Thread.Sleep(delay);
                            while (flag_send) { }
                            serialPort2.WriteLine(recevice_command);
                            flag_receive = true;
                            value++;
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString(), "SerialPort1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Output_csv_log()
        {
            DateTime myDate = DateTime.Now;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\" +  DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv", true))
            {
                if (serialPort1_csv != "" && serialPort2_csv != "")
                {
                    string[] serialPort1_split_data = serialPort1_csv.Split(';');
                    string[] serialPort2_split_data = serialPort2_csv.Split(';');
                    int serialPort_length = 0;
                    if (serialPort1_split_data.Length > serialPort2_split_data.Length)
                        serialPort_length = serialPort2_split_data.Length;
                    else if (serialPort1_split_data.Length < serialPort2_split_data.Length)
                        serialPort_length = serialPort1_split_data.Length;
                    else
                        serialPort_length = serialPort1_split_data.Length;
                    for (int i = 0; i < serialPort_length; i++)
                    {
                        output_csv += serialPort1_split_data[i] + "," + serialPort2_split_data[i] + "," + Environment.NewLine;
                    }
                    file.Write(output_csv);
                    serialPort1_csv = "";
                    serialPort2_csv = "";
                    output_csv = "";
                    output_csv = "Hotspring Value, Fluke receive value," + Environment.NewLine;
                }
            }
        }
    }
}
