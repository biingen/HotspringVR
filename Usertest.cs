﻿using System;
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
    public partial class Usertest : Form
    {
        private string Config_Path = Application.StartupPath + "\\Config.ini";

        string serialPort1_text, serialPort2_text;
        int resistance_value = 0;
        double target_resistance_value = 0;

        const int byteMessage_max_Hex = 16;
        const int byteMessage_max_Ascii = 256;

        bool start_button;
        bool flag_receive = false;
        byte[] byteMessage_A = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_A = 0;
        byte[] byteMessage_B = new byte[Math.Max(byteMessage_max_Ascii, byteMessage_max_Hex)];
        int byteMessage_length_B = 0;

        string output_csv = "Setting value, Equipment value, Equipment value - internal resistance value, Difference, " + Environment.NewLine;

        public Usertest()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Thread UserThread = new Thread(new ThreadStart(UserModefunction));
            Thread LogAThread = new Thread(new ThreadStart(serialPort1_analysis));
            Thread LogBThread = new Thread(new ThreadStart(serialPort2_analysis));

            start_button = !start_button;
            if (start_button == true)
            {
                button_start.Text = "Stop";
                checkBox_RA.Enabled = false;
                checkBox_RB.Enabled = false;
                checkBox_RC.Enabled = false;
                textBox_startValue.Enabled = false;
                textBox_endValue.Enabled = false;
                textBox_delaytime.Enabled = false;
                textBox_step.Enabled = false;
                textBox_resistance.Enabled = false;
                textBox_basis.Enabled = false;

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

                if (checkBox_RA.Checked == true || checkBox_RB.Checked == true || checkBox_RB.Checked == true)
                    UserThread.Start();
            }
            else
            {
                button_start.Text = "Start";
                checkBox_RA.Enabled = true;
                checkBox_RB.Enabled = true;
                checkBox_RC.Enabled = true;
                textBox_startValue.Enabled = true;
                textBox_endValue.Enabled = true;
                textBox_delaytime.Enabled = true;
                textBox_step.Enabled = true;
                textBox_resistance.Enabled = true;
                textBox_basis.Enabled = true;

                if (checkBox_RA.Checked == true || checkBox_RB.Checked == true || checkBox_RB.Checked == true)
                    UserThread.Abort();
                if (serialPort1.IsOpen == true)          //送至Comport
                {
                    LogAThread.Abort();
                    Close_serialPort1();
                }
                if (serialPort2.IsOpen == true && flag_receive == false)          //送至Comport
                {
                    LogBThread.Abort();
                    Close_serialPort2();
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
                    serialPort2.PortName = ini12.INIRead(Config_Path, "serialPort2", "PortName", "");
                    serialPort2.BaudRate = int.Parse((ini12.INIRead(Config_Path, "serialPort2", "BaudRate", "")));
                    serialPort2.DataBits = 8;
                    serialPort2.Parity = (Parity)0;
                    serialPort2.ReceivedBytesThreshold = 1;
                    if (ini12.INIRead(Config_Path, "serialPort2", "HP34401A", "") == "1")
                    {
                        serialPort2.StopBits = StopBits.Two;
                        serialPort2.DtrEnable = true;
                    }
                    else
                        serialPort2.StopBits = StopBits.One;
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

        private void textBox_startValue_TextChanged(object sender, EventArgs e)
        {
            check_start_end_value();
        }

        private void textBox_endValue_TextChanged(object sender, EventArgs e)
        {
            check_start_end_value();
        }

        private void textBox_step_TextChanged(object sender, EventArgs e)
        {
            check_step_value();
        }

        private void textBox_resistance_TextChanged(object sender, EventArgs e)
        {
            check_resistance_value();
        }

        private void textBox_basis_TextChanged(object sender, EventArgs e)
        {
            check_basis_value();
        }

        private void check_start_end_value()
        {
            int start_number = 0;
            int end_number = 0;
            bool textBox_start_bool = Int32.TryParse(textBox_startValue.Text, out start_number);
            bool textBox_end_bool = Int32.TryParse(textBox_endValue.Text, out end_number);
            if (textBox_start_bool && start_number < 1 || start_number > 1048576)
            {
                textBox_startValue.Text = "2";
                MessageBox.Show("Please re-keyin the correct value.", "Start value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (textBox_end_bool && end_number < 1 || end_number > 1048576)
            {
                textBox_endValue.Text = "1048576";
                MessageBox.Show("Please re-keyin the correct value.", "End value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_step_value()
        {
            int step_number = 0;
            bool textBox_step_bool = Int32.TryParse(textBox_step.Text, out step_number);
            if (textBox_step_bool && step_number == 0)
            {
                textBox_basis.Enabled = true;
                textBox_step.Enabled = false;
            }
            else if (textBox_step_bool && step_number < -1048576 || step_number > 1048576)
            {
                textBox_step.Text = "1";
                MessageBox.Show("Please re-keyin the correct value.", "End value Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox_basis.Enabled = false;
                textBox_step.Enabled = true;
            }
        }

        private void check_basis_value()
        {
            int basis_number = 0;
            bool textBox_basis_bool = Int32.TryParse(textBox_basis.Text, out basis_number);

            if (textBox_basis_bool)
            {
                if (basis_number == 0)
                {
                    textBox_basis.Enabled = false;
                    textBox_step.Enabled = true;
                }
                else
                {
                    textBox_basis.Enabled = true;
                    textBox_step.Enabled = false;
                }
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            check_start_end_value();
            check_step_value();
            check_basis_value();
            check_resistance_value();
        }

        private void UserModefunction()
        {
            string frontdata, receive_command;
            if (start_button == true)
            {
                if (textBox_startValue.Text != "" && textBox_endValue.Text != "" && textBox_step.Text != "" && textBox_delaytime.Text != "")
                {
                    int startvalue = Convert.ToInt32(textBox_startValue.Text);
                    int endvalue = Convert.ToInt32(textBox_endValue.Text);
                    int step = Convert.ToInt32(textBox_step.Text);
                    int delay = Convert.ToInt32(textBox_delaytime.Text);
                    int basis = Convert.ToInt32(textBox_basis.Text);

                    if (ini12.INIRead(Config_Path, "serialPort2", "HP34401A", "") == "1")
                        receive_command = ":Read?";
                    else
                        receive_command = "VAL?";

                    if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")          //送至Comport
                    {
                        if (checkBox_RA.Checked == true && serialPort1.IsOpen == true)
                        {
                            frontdata = "set RA ";
                            send_hotspring_command(startvalue, endvalue, step, delay, basis, frontdata, receive_command);
                        }
                        else if (checkBox_RB.Checked == true && serialPort1.IsOpen == true)
                        {
                            frontdata = "set RB ";
                            send_hotspring_command(startvalue, endvalue, step, delay, basis, frontdata, receive_command);
                        }
                        else if (checkBox_RC.Checked == true && serialPort1.IsOpen == true)
                        {
                            frontdata = "set RC ";
                            send_hotspring_command(startvalue, endvalue, step, delay, basis, frontdata, receive_command);
                        }
                    }

                    while (flag_receive) { }
                    Output_csv_log();
                }
            }
        }

        private void send_hotspring_command(int startvalue, int endvalue, int step, int delay, int basis, string frontdata, string receive_command)
        {
            if (ini12.INIRead(Config_Path, "serialPort2", "HP34401A", "") == "1")
            {
                serialPort2.WriteLine(":syst:rem;");
                serialPort2.WriteLine(":conf:RES;");
            }
            else
                serialPort2.WriteLine("OHMS;");

            if (step != 0)
            {
                if (startvalue < endvalue)
                {
                    for (int value = startvalue; value <= endvalue; value += step)
                    {
                        if (start_button == true)
                        {
                            try
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
                                serialPort2.WriteLine(receive_command);
                                dt = DateTime.Now;
                                string send_serialport2_text = "[Send_serialport2] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + receive_command + "\r\n";
                                serialPort2_text = string.Concat(serialPort2_text, send_serialport2_text);
                                flag_receive = true;
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString(), "SerialPort1 || SerialPort2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    for (int value = startvalue; value >= endvalue; value += step)
                    {
                        if (start_button == true)
                        {
                            try
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
                                serialPort2.WriteLine(receive_command);
                                dt = DateTime.Now;
                                string send_serialport2_text = "[Send_serialport2] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + receive_command + "\r\n";
                                serialPort2_text = string.Concat(serialPort2_text, send_serialport2_text);
                                flag_receive = true;
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.Message.ToString(), "SerialPort1 || SerialPort2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else if (basis != 0 && basis != 1)
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
                            serialPort2.WriteLine(receive_command);
                            dt = DateTime.Now;
                            string send_serialport2_text = "[Send_serialport2] [" + dt.ToString("yyyy/MM/dd HH:mm:ss.fff") + "]  " + receive_command + "\r\n";
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
