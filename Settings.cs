﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jini;

namespace Hotspring
{
    public partial class Settings : Form
    {
        private string Config_Path = Application.StartupPath + "\\Config.ini";

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox_serialPort1_portname.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            comboBox_serialPort2_portname.DataSource = System.IO.Ports.SerialPort.GetPortNames();

            if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")
            {
                serialPort1_enable.Checked = true;
                comboBox_serialPort1_portname.Enabled = true;
                comboBox_serialPort1_baudrate.Enabled = true;
            }
            else
            {
                serialPort1_enable.Checked = false;
                comboBox_serialPort1_portname.Enabled = false;
                comboBox_serialPort1_baudrate.Enabled = false;
            }

            if (ini12.INIRead(Config_Path, "serialPort2", "Exist", "") == "1")
            {
                if (ini12.INIRead(Config_Path, "serialPort2", "HP34401A", "") == "1")
                {
                    radioButton_HP34401A.Checked = true;
                    groupBox_serialPort2.Text = "Keysight 34401A 6½ Digit Multimeter";
                    comboBox_serialPort2_baudrate.Enabled = true;
                    comboBox_serialPort2_portname.Enabled = true;
                }
                else
                {
                    radioButton_fluke45.Checked = true;
                    groupBox_serialPort2.Text = "Fluke 45 Multi-meter";
                    comboBox_serialPort2_baudrate.Enabled = true;
                    comboBox_serialPort2_portname.Enabled = true;
                }
            }
            else
            {
                comboBox_serialPort2_baudrate.Enabled = false;
                comboBox_serialPort2_portname.Enabled = false;
            }

            comboBox_serialPort1_baudrate.Text = ini12.INIRead(Config_Path, "serialPort1", "BaudRate", "");
            comboBox_serialPort1_portname.Text = ini12.INIRead(Config_Path, "serialPort1", "PortName", "");
            comboBox_serialPort2_baudrate.Text = ini12.INIRead(Config_Path, "serialPort2", "BaudRate", "");
            comboBox_serialPort2_portname.Text = ini12.INIRead(Config_Path, "serialPort2", "PortName", "");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort1_enable.Checked == true)
            {
                ini12.INIWrite(Config_Path, "serialPort1", "Exist", "1");
                comboBox_serialPort1_portname.Enabled = true;
                comboBox_serialPort1_baudrate.Enabled = true;
            }
            else
            {
                ini12.INIWrite(Config_Path, "serialPort1", "Exist", "0");
                comboBox_serialPort1_portname.Enabled = false;
                comboBox_serialPort1_baudrate.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1_enable.Checked == true)
            {
                if (ini12.INIRead(Config_Path, "AutoKit", "PortName", "") != comboBox_serialPort1_portname.Text.Trim() && comboBox_serialPort1_portname.Text.Trim() != comboBox_serialPort2_portname.Text.Trim())
                {
                    ini12.INIWrite(Config_Path, "serialPort1", "PortName", comboBox_serialPort1_portname.Text.Trim());
                    label_serialPort_status.Text = "serialPort1 portname already save.";
                }
                else
                {
                    label_serialPort_status.Text = "serialPort1 portname can't save to config.";
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton_fluke45.Checked == true || radioButton_HP34401A.Checked == true)
            {
                if (ini12.INIRead(Config_Path, "AutoKit", "PortName", "") != comboBox_serialPort2_portname.Text.Trim() && comboBox_serialPort1_portname.Text.Trim() != comboBox_serialPort2_portname.Text.Trim())
                {
                    ini12.INIWrite(Config_Path, "serialPort2", "PortName", comboBox_serialPort2_portname.Text.Trim());
                    label_serialPort_status.Text = "serialPort2 portname already save.";
                }
                else
                {
                    label_serialPort_status.Text = "serialPort2 portname can't save to config.";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini12.INIWrite(Config_Path, "serialPort1", "BaudRate", comboBox_serialPort1_baudrate.Text.Trim());
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini12.INIWrite(Config_Path, "serialPort2", "BaudRate", comboBox_serialPort2_baudrate.Text.Trim());
        }

        private void radioButton_fluke45_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_fluke45.Checked == true)
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "1");
                ini12.INIWrite(Config_Path, "serialPort2", "HP34401A", "0");
                groupBox_serialPort2.Text = "Fluke 45 Multi-meter";
                comboBox_serialPort2_baudrate.Enabled = true;
                comboBox_serialPort2_portname.Enabled = true;
            }
            else
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "0");
                comboBox_serialPort2_baudrate.Enabled = false;
                comboBox_serialPort2_portname.Enabled = false;
            }
        }

        private void radioButton_HP34401A_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_HP34401A.Checked == true)
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "1");
                ini12.INIWrite(Config_Path, "serialPort2", "HP34401A", "1");
                groupBox_serialPort2.Text = "Keysight(HP) 34401A 6½ Digit Multimeter";
                comboBox_serialPort2_baudrate.Enabled = true;
                comboBox_serialPort2_portname.Enabled = true;
            }
            else
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "0");
                comboBox_serialPort2_baudrate.Enabled = false;
                comboBox_serialPort2_portname.Enabled = false;
            }
        }
    }
}
