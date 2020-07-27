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

namespace Hotspring
{
    public partial class Settings : Form
    {
        private string Config_Path = Application.StartupPath + "\\Config.ini";

        public Settings()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ini12.INIWrite(Config_Path, "serialPort1", "Exist", "1");
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
            }
            else
            {
                ini12.INIWrite(Config_Path, "serialPort1", "Exist", "0");
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "1");
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
            }
            else
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Exist", "0");
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != comboBox6.Text.Trim())
            {
                ini12.INIWrite(Config_Path, "serialPort1", "Type", comboBox1.Text.Trim());
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != comboBox6.Text.Trim())
            {
                ini12.INIWrite(Config_Path, "serialPort2", "Type", comboBox6.Text.Trim());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (ini12.INIRead(Config_Path, "AutoKit", "PortName", "") != comboBox2.Text.Trim() && comboBox2.Text.Trim() != comboBox5.Text.Trim())
                {
                    ini12.INIWrite(Config_Path, "serialPort1", "PortName", comboBox2.Text.Trim());
                    label11.Text = "serialPort1 portname already save.";
                }
                else
                {
                    label11.Text = "serialPort1 portname can't save to config.";
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (ini12.INIRead(Config_Path, "AutoKit", "PortName", "") != comboBox5.Text.Trim() && comboBox2.Text.Trim() != comboBox5.Text.Trim())
                {
                    ini12.INIWrite(Config_Path, "serialPort2", "PortName", comboBox5.Text.Trim());
                    label11.Text = "serialPort2 portname already save.";
                }
                else
                {
                    label11.Text = "serialPort2 portname can't save to config.";
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini12.INIWrite(Config_Path, "serialPort1", "BaudRate", comboBox3.Text.Trim());
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini12.INIWrite(Config_Path, "serialPort2", "BaudRate", comboBox4.Text.Trim());
        }
    }
}
