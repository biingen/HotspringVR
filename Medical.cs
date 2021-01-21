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
        bool flag_wait_for_receive = false;

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

 
        /*
                private void hScrollBar_backlight_set_Scroll(object sender, ScrollEventArgs e)
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
                        flag_wait_for_receive = true;
                    }
                    else if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1" && serialPort1.IsOpen == true)          //送至Comport
                    {
                        serialPort1.Write(command, 0, command.Length);
                        flag_wait_for_receive = true;
                    }

                    while (flag_wait_for_receive) { }
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
                */
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

        private bool CheckSerialOpen()
        {
            Thread LogA_analysis = new Thread(new ThreadStart(serialPortA_analysis));
            Thread LogA_record = new Thread(new ThreadStart(serialPortA_recorder));
            bool ret_value = false;

            if (serialPort1.IsOpen == false)          //送至Comport
            {
                if (ini12.INIRead(Config_Path, "serialPort1", "Exist", "") == "1")
                {
                    Open_serialPort1();
                    LogA_analysis.Start();
                    LogA_record.Start();
                    ret_value = true;
                }
            }
            else
            {
                ret_value = true;
            }
            return ret_value;
        }

        // copy to mei
        enum command_index
        {
            // Calibration Command
            SET_GAMMA_INDEX = 0,
            GET_GAMMA_INDEX,
            //SET_OUTPUT_GAMMA_TABLE_INDEX,
            GET_OUTPUT_GAMMA_TABLE_INDEX,
            SET_COLOR_GAMUT_INDEX,
            GET_COLOR_GAMUT_INDEX,
            //SET_INPUT_GAMMA_TABLE_INDEX,
            GET_INPUT_GAMMA_TABLE_INDEX,
            //SET_PCM_MARTIX_TABLE_INDEX,
            GET_PCM_MARTIX_TABLE_INDEX,
            SET_COLOR_TEMP_INDEX,
            GET_COLOR_TEMP_INDEX,
            SET_RGB_GAIN_INDEX,
            GET_RGB_GAIN_INDEX,
            
            // Control Command
            SET_BACKLIGHT_INDEX,
            GET_BACKLIGHT_INDEX,
            SET_PQ_ONOFF_INDEX,
            SET_INTERNAL_PATTERN_INDEX,
            SET_PATTERN_RGB_INDEX,
            SET_SHARPNESS_INDEX,
            GET_SHARPNESS_INDEX,
            GET_BACKLIGHT_SENSOR_INDEX,
            GET_THERMAL_SENSOR_INDEX,
            SET_SPI_PORT_INDEX,
            GET_SPI_PORT_INDEX,
            SET_UART_PORT_INDEX,
            GET_UART_PORT_INDEX,
            SET_BRIGHTNESS_INDEX,
            GET_BRIGHTNESS_INDEX,
            SET_CONTRAST_INDEX,
            GET_CONTRAST_INDEX,
            SET_MAIN_INPUT_INDEX,
            GET_MAIN_INPUT_INDEX,
            SET_SUB_INPUT_INDEX,
            GET_SUB_INPUT_INDEX,
            SET_PIP_MODE_INDEX,
            GET_PIP_MODE_INDEX,
            
            // Write Data Command
            GET_SCALER_TYPE_INDEX,
            //SET_MODEL_NAME_INDEX,
            GET_MODEL_NAME_INDEX,
            //SET_EDID_INDEX,
            GET_EDID_INDEX,
            //SET_HDCP14_INDEX,
            GET_HDCP14_INDEX,
            //SET_HDCP2x_INDEX,
            GET_HDCP2x_INDEX,
            //SET_SERIAL_NUMBER_INDEX,
            GET_SERIAL_NUMBER_INDEX,
            GET_FW_VERSION_INDEX,
            GET_FAC_EEPROM_DATA_INDEX,
            
            // BenQ Command
            //SET_BENQ_MODEL_NAME_INDEX,
            //SET_BENQ_SERIAL_NAME_INDEX,
            //SET_BENQ_FW_VERSION_INDEX,
            //SET_BENQ_MONITOR_ID_INDEX,
            //SET_BENQ_DNA_VERSION_INDEX,
            //SET_BENQ_MANUFACTURE_YEARANDDATE_INDEX,
            //SET_BENQ_EEPROM_INIT_INDEX,
            //GET_BENQ_EEPROM_INDEX,
        }

        byte[][] Command_Packet =
        {
			// Calibration Command
            new byte[] { 0x06, 0x00, 0xE0, 0x00, 0xff, 0xff },              ///SET_GAMMA_INDEX,
            new byte[] { 0x05, 0x00, 0xE0, 0x01, 0xff },                    ///GET_GAMMA_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x02, 0xff, 0xff, 0xff },      ///SET_OUTPUT_GAMMA_TABLE_INDEX,
            new byte[] { 0x07, 0x00, 0xE0, 0x03, 0xff, 0xff, 0xff },        ///GET_OUTPUT_GAMMA_TABLE_INDEX,
            new byte[] { 0x06, 0x00, 0xE0, 0x04, 0xff, 0xff },              ///SET_COLOR_GAMUT_INDEX,
            new byte[] { 0x05, 0x00, 0xE0, 0x05, 0xff },                    ///GET_COLOR_GAMUT_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x06, 0xff, 0xff, 0xff, 0xff, 0xff },						///SET_INPUT_GAMMA_TABLE_INDEX,
            new byte[] { 0x05, 0x00, 0xE0, 0x07, 0xff },              		///GET_INPUT_GAMMA_TABLE_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x08, 0xff, 0xff, 0xff },      ///SET_PCM_MARTIX_TABLE_INDEX,
            new byte[] { 0x05, 0x00, 0xE0, 0x09, 0xff },                    ///GET_PCM_MARTIX_TABLE_INDEX,
            new byte[] { 0x06, 0x00, 0xE0, 0x0A, 0xff, 0xff },              ///SET_COLOR_TEMP_INDEX,
            new byte[] { 0x05, 0x00, 0xE0, 0x0B, 0xff },              		///GET_COLOR_TEMP_INDEX,
            new byte[] { 0x07, 0x00, 0xE0, 0x0C, 0xff, 0xff, 0xff },		///SET_RGB_GAIN_INDEX,
            new byte[] { 0x05, 0x00, 0xE0, 0x0D, 0xff },              		///GET_RGB_GAIN_INDEX,		
            
            // Control Command
            new byte[] { 0x06, 0x01, 0xE0, 0x00, 0xff, 0xff },		    	///SET_BACKLIGHT_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x01, 0xff },           			///GET_BACKLIGHT_INDEX,			
            new byte[] { 0x07, 0x01, 0xE0, 0x02, 0xff, 0xff, 0xff },        ///SET_PQ_ONOFF_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x03, 0xff, 0xff },              ///SET_INTERNAL_PATTERN_INDEX,
            new byte[] { 0x0B, 0x01, 0xE0, 0x04, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff },            ///SET_PATTERN_RGB_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x05, 0xff, 0xff },              ///SET_SHARPNESS_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x06, 0xff },              		///GET_SHARPNESS_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x07, 0xff },              		///GET_BACKLIGHT_SENSOR_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x08, 0xff },                    ///GET_THERMAL_SENSOR_INDEX,
            //new byte[] { 0x06, 0x01, 0xE0, 0x08, 0xff, 0xff },            ///GET_THERMAL_SENSOR_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x09, 0xff, 0xff },              ///SET_SPI_PORT_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x0A, 0xff },              		///GET_SPI_PORT_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x0B, 0xff, 0xff },              ///SET_UART_PORT_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x0C, 0xff },              		///GET_UART_PORT_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x0D, 0xff, 0xff },              ///SET_BRIGHTNESS_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x0E, 0xff },        		    ///GET_BRIGHTNESS_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x0F, 0xff, 0xff },              ///SET_CONTRAST_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x10, 0xff },              		///GET_CONTRAST_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x11, 0xff, 0xff },              ///SET_MAIN_INPUT_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x12, 0xff },              		///GET_MAIN_INPUT_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x13, 0xff, 0xff },              ///SET_SUB_INPUT_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x14, 0xff },              		///GET_SUB_INPUT_INDEX,
            new byte[] { 0x06, 0x01, 0xE0, 0x15, 0xff, 0xff },              ///SET_PIP_MODE_INDEX,
            new byte[] { 0x05, 0x01, 0xE0, 0x16, 0xff },              		///GET_PIP_MODE_INDEX,
			
            // Write Data Command
            new byte[] { 0x05, 0x02, 0xE0, 0x00, 0xff },              		///GET_SCALER_TYPE_INDEX,
            //new byte[] { 0xff, 0x02, 0xE0, 0x01, 0xff, 0xff, 0xff },      ///SET_MODEL_NAME_INDEX,
            new byte[] { 0x05, 0x02, 0xE0, 0x02, 0xff },              		///GET_MODEL_NAME_INDEX,
            //new byte[] { 0xff, 0x02, 0xE0, 0x03, 0xff, 0xff, 0xff, 0xff, 0xff },              ///SET_EDID_INDEX,
            new byte[] { 0x06, 0x02, 0xE0, 0x04, 0xff, 0xff },              ///GET_EDID_INDEX,
            //new byte[] { 0xff, 0x02, 0xE0, 0x05, 0xff, 0xff, 0xff, 0xff },///SET_HDCP14_INDEX,
            new byte[] { 0x05, 0x02, 0xE0, 0x06, 0xff },              		///GET_HDCP14_INDEX,
            //new byte[] { 0xff, 0x02, 0xE0, 0x07, 0xff, 0xff, 0xff, 0xff },///SET_HDCP2x_INDEX,
            new byte[] { 0x06, 0x02, 0xE0, 0x08, 0xff },              		///GET_HDCP2x_INDEX,
            //new byte[] { 0xff, 0x02, 0xE0, 0x09, 0xff, 0xff, 0xff },      ///SET_SERIAL_NUMBER_INDEX,
            new byte[] { 0x05, 0x02, 0xE0, 0x0A, 0xff },              		///GET_SERIAL_NUMBER_INDEX,
            new byte[] { 0x05, 0x02, 0xE0, 0x0B, 0xff },              		///GET_FW_VERSION_INDEX,
            new byte[] { 0x05, 0x02, 0xE0, 0x0C, 0xff },              		///GET_FAC_EEPROM_DATA_INDEX,
			
            // BenQ Command
            //new byte[] { 0xff, 0x00, 0xE0, 0x00, 0xff, 0xff, 0xff },      ///SET_BENQ_MODEL_NAME_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x01, 0xff, 0xff, 0xff },      ///SET_BENQ_SERIAL_NAME_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x02, 0xff, 0xff, 0xff },      ///SET_BENQ_FW_VERSION_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x03, 0xff, 0xff, 0xff },      ///SET_BENQ_MONITOR_ID_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x04, 0xff, 0xff, 0xff },      ///SET_BENQ_DNA_VERSION_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x05, 0xff, 0xff, 0xff },      ///SET_BENQ_MANUFACTURE_YEARANDDATE_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x06, 0xff, 0xff, 0xff },      ///SET_BENQ_EEPROM_INIT_INDEX,
            //new byte[] { 0xff, 0x00, 0xE0, 0x07, 0xff, 0xff, 0xff },      ///GET_BENQ_EEPROM_INDEX,
        };
        // copy to mei

        byte[][] Parsing_Packet =
        {
            //// Calibration Command
            new byte [] { }, //SET_GAMMA_INDEX = 0,
            new byte [] { 0x06, 0x00, 0xE0, 0x01 }, //GET_GAMMA_INDEX,
            //new byte [] { }, //SET_OUTPUT_GAMMA_TABLE_INDEX,
            new byte [] { }, //GET_OUTPUT_GAMMA_TABLE_INDEX,
            new byte [] { }, //SET_COLOR_GAMUT_INDEX,
            new byte [] { 0x06, 0x00, 0xE0, 0x05 }, //GET_COLOR_GAMUT_INDEX,
            //new byte [] { }, //SET_INPUT_GAMMA_TABLE_INDEX,
            new byte [] { }, //GET_INPUT_GAMMA_TABLE_INDEX,
            //new byte [] { }, //SET_PCM_MARTIX_TABLE_INDEX,
            new byte [] { }, //GET_PCM_MARTIX_TABLE_INDEX,
            new byte [] { }, //SET_COLOR_TEMP_INDEX,
            new byte [] { 0x06, 0x00, 0xE0, 0x0B }, //GET_COLOR_TEMP_INDEX,
            new byte [] { }, //SET_RGB_GAIN_INDEX,
            new byte [] { 0x08, 0x00, 0xE0, 0x0D }, //GET_RGB_GAIN_INDEX,
            
            //// Control Command
            new byte [] { }, //SET_BACKLIGHT_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x01 },  //GET_BACKLIGHT_INDEX,
            new byte [] { }, //SET_PQ_ONOFF_INDEX,
            new byte [] { }, //SET_INTERNAL_PATTERN_INDEX,
            new byte [] { }, //SET_PATTERN_RGB_INDEX,
            new byte [] { }, //SET_SHARPNESS_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x06 }, //GET_SHARPNESS_INDEX,
            new byte [] { 0x07, 0x01, 0xE0, 0x07 }, //GET_BACKLIGHT_SENSOR_INDEX,
            new byte [] { 0x09, 0x01, 0xE0, 0x08 }, //GET_THERMAL_SENSOR_INDEX,
            new byte [] { }, //SET_SPI_PORT_INDEX,
            new byte [] { 0x07, 0x01, 0xE0, 0x0A }, //GET_SPI_PORT_INDEX,
            new byte [] { }, //SET_UART_PORT_INDEX,
            new byte [] { 0x07, 0x01, 0xE0, 0x0C }, //GET_UART_PORT_INDEX,
            new byte [] { }, //SET_BRIGHTNESS_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x0E }, //GET_BRIGHTNESS_INDEX,
            new byte [] { }, //SET_CONTRAST_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x10 }, //GET_CONTRAST_INDEX,
            new byte [] { }, //SET_MAIN_INPUT_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x12 }, //GET_MAIN_INPUT_INDEX,
            new byte [] { }, //SET_SUB_INPUT_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x14 }, //GET_SUB_INPUT_INDEX,
            new byte [] { }, //SET_PIP_MODE_INDEX,
            new byte [] { 0x06, 0x01, 0xE0, 0x16 }, //GET_PIP_MODE_INDEX,
            
            //new byte [] { }, // Write Data Command
            new byte [] { }, //GET_SCALER_TYPE_INDEX,
            //new byte [] { }, //SET_MODEL_NAME_INDEX,
            new byte [] { }, //GET_MODEL_NAME_INDEX,
            //new byte [] { }, //SET_EDID_INDEX,
            new byte [] { }, //GET_EDID_INDEX,
            //new byte [] { }, //SET_HDCP14_INDEX,
            new byte [] { }, //GET_HDCP14_INDEX,
            //new byte [] { }, //SET_HDCP2x_INDEX,
            new byte [] { }, //GET_HDCP2x_INDEX,
            //new byte [] { }, //SET_SERIAL_NUMBER_INDEX,
            new byte [] { }, //GET_SERIAL_NUMBER_INDEX,
            new byte [] { }, //GET_FW_VERSION_INDEX,
            new byte [] { }, //GET_FAC_EEPROM_DATA_INDEX,
            
            //// BenQ Command
            //new byte [] { }, //SET_BENQ_MODEL_NAME_INDEX,
            //new byte [] { }, //SET_BENQ_SERIAL_NAME_INDEX,
            //new byte [] { }, //SET_BENQ_FW_VERSION_INDEX,
            //new byte [] { }, //SET_BENQ_MONITOR_ID_INDEX,
            //new byte [] { }, //SET_BENQ_DNA_VERSION_INDEX,
            //new byte [] { }, //SET_BENQ_MANUFACTURE_YEARANDDATE_INDEX,
            //new byte [] { }, //SET_BENQ_EEPROM_INIT_INDEX,
            //new byte [] { }, //GET_BENQ_EEPROM_INDEX,
       };


        private bool Send_and_Receive_Packet(command_index cmd_index, byte[] data_array)
        {
            return Send_and_Receive_Packet((int)cmd_index, data_array);
        }

        private bool Send_and_Receive_Packet(int cmd_index, byte[] data_array)
        {
            bool ret_value = false;

            // prepare and send get_value 
            int PACKET_INDEX = (int)cmd_index;
            int packet_len = Command_Packet[PACKET_INDEX].Length;
            for (int index = 0; index < data_array.Length; index++)
            {
                Command_Packet[PACKET_INDEX][index + 4] = data_array[index];
            }
            Command_Packet[PACKET_INDEX][packet_len - 1] = XOR_Byte(Command_Packet[PACKET_INDEX], (packet_len - 1));
            serialPort1.Write(Command_Packet[PACKET_INDEX], 0, packet_len);

            // wait until packet received
            flag_wait_for_receive = true;
            while (flag_wait_for_receive) { }

            if (dataListbyte.Count() > 0)
            {
                ret_value = true;
            }

            return ret_value;
        }

        private int Set_Backlight_value(byte set_value)   // update here
        {
            int cmd_index = (int)command_index.SET_BACKLIGHT_INDEX; // update index here

            if (set_value > 100)        // update range check
            {
                // error handling
            }

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte []input_data = new byte[input_data_length];

            // Update input data
            input_data[0] = set_value;

            Send_and_Receive_Packet(cmd_index, input_data);

            int check_packet = 0xff;
            if (dataListbyte.Count() > 0)
            {
                check_packet = check_Ack_packet();
            }
            return check_packet;
        }
 
        private bool Get_Backlight_value(out byte return_value)  // update here
        {
            int cmd_index = (int)command_index.GET_BACKLIGHT_INDEX; // update index here
            bool ret_value = false;
            return_value = 0;

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            //input_data[0] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_backlight_packet(log_analysis, out return_value) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        // update out byte/int16/uint32/.....
        private bool Parse_backlight_packet(List<byte>input_packet, out byte return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_BACKLIGHT_INDEX;

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

        private int Set_RGBGain_value(byte set_select, byte set_value)
        {
            int cmd_index = (int)command_index.SET_RGB_GAIN_INDEX;
            int check_packet = 0xff;

            if (set_select > 2)
            {
                // error handling
            }

            if (set_value > 255)
            {
                // error handling
            }

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            input_data[0] = set_select;
            input_data[1] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            /*
            // prepare and send get_value 
            int PACKET_INDEX = (int)command_index_old.RGB_GAIN_INDEX;
            int packet_len = Set_Value_Packet[PACKET_INDEX].Length;
            Set_Value_Packet[PACKET_INDEX][packet_len - 3] = set_select;
            Set_Value_Packet[PACKET_INDEX][packet_len - 2] = set_value;
            Set_Value_Packet[PACKET_INDEX][packet_len - 1] = XOR_Byte(Set_Value_Packet[PACKET_INDEX], (packet_len - 1));
            serialPort1.Write(Set_Value_Packet[PACKET_INDEX], 0, packet_len);

            // wait until packet received
            flag_wait_for_receive = true;
            while (flag_wait_for_receive) { }
*/
            if (dataListbyte.Count() > 0)
            {
                check_packet = check_Ack_packet();
            }
            return check_packet;
        }

        private bool Get_RGBGain_value(out byte[] rgb_gain_value)
        {
            int cmd_index = (int)command_index.GET_RGB_GAIN_INDEX;
            bool ret_value = false;
            rgb_gain_value = new byte[3];

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            //input_data[0] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();
                if (Parse_rgb_gain_packet(log_analysis, out rgb_gain_value) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        private bool Parse_rgb_gain_packet(List<byte> input_packet, out byte r_gain, out byte g_gain, out byte b_gain)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_RGB_GAIN_INDEX;

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
            int PACKET_INDEX = (int)command_index.GET_RGB_GAIN_INDEX;

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



        private int Set_Main_input_value(byte set_value)
        {
            int cmd_index = (int)command_index.SET_MAIN_INPUT_INDEX; // update index here

            if (set_value > 7)        // update range check
            {
                // error handling
            }

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];

            // Update input data
            input_data[0] = set_value;

            Send_and_Receive_Packet(cmd_index, input_data);

            int check_packet = 0xff;
            if (dataListbyte.Count() > 0)
            {
                check_packet = check_Ack_packet();
            }
            return check_packet;
        }

        private bool Get_Main_input_value(out byte return_value)  // update here
        {
            int cmd_index = (int)command_index.GET_MAIN_INPUT_INDEX; // update index here
            bool ret_value = false;
            return_value = 0;

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            //input_data[0] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_main_input_packet(log_analysis, out return_value) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        // update out byte/int16/uint32/.....
        private bool Parse_main_input_packet(List<byte> input_packet, out byte return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_MAIN_INPUT_INDEX;

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

            if (ret_value == true)
            {
                // update here
                return_value = input_packet.ElementAt(4);
            }

            return ret_value;
        }

        private bool Get_Backlight_sensor_value(out int return_value)  // update here
        {
            int cmd_index = (int)command_index.GET_BACKLIGHT_SENSOR_INDEX; // update index here
            bool ret_value = false;
            return_value = 0;

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            //input_data[0] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_backlight_sensor_packet(log_analysis, out return_value) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        // update out byte/int16/uint32/.....
        private bool Parse_backlight_sensor_packet(List<byte> input_packet, out int return_value)
        {
            bool ret_value;
            byte [] return_byte_array = new byte[2];
            ret_value = Parse_backlight_sensor_packet(input_packet, out return_byte_array);
            return_value = (int)return_byte_array[0] * 256 + return_byte_array[1];
            return ret_value;
        }

        private bool Parse_backlight_sensor_packet(List<byte> input_packet, out byte [] return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_BACKLIGHT_SENSOR_INDEX;

            bool ret_value = true;
            return_value = new byte [2];

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
                // update here
                return_value[0] = input_packet.ElementAt(4);
                return_value[1] = input_packet.ElementAt(5);
            }

            return ret_value;
        }

        private bool Get_Thermal_sensor_value(out int sensor1, out int sensor2)  // update here
        {
            int cmd_index = (int)command_index.GET_THERMAL_SENSOR_INDEX; // update index here
            bool ret_value = false;

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;

            byte[] input_data = new byte[input_data_length];
            sensor1 = 0;
            sensor2 = 0;

            //new byte[] { 0x05, 0x01, 0xE0, 0x08, 0xff },              ///GET_THERMAL_SENSOR_INDEX,
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_thermal_sensor_packet(log_analysis, out sensor1, out sensor2) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        private bool Get_Thermal_sensor_value(byte set_value, out int sensor1, out int sensor2)  // update here
        {
            int cmd_index = (int)command_index.GET_THERMAL_SENSOR_INDEX; // update index here
            bool ret_value = false;
            if (set_value > 1)        // update range check
            {
                // error handling
            }

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;

            byte[] input_data = new byte[input_data_length];
            sensor1 = 0;
            sensor2 = 0;

            //new byte[] { 0x06, 0x01, 0xE0, 0x08, 0xff, 0xff },              ///GET_THERMAL_SENSOR_INDEX,
            Command_Packet[cmd_index][4] = set_value;                         // set_value equal [4] value.
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_thermal_sensor_packet(log_analysis, out sensor1, out sensor2) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        // update out byte/int16/uint32/.....
        private bool Parse_thermal_sensor_packet(List<byte> input_packet, out int return_value_1, out int return_value_2)
        {
            bool ret_value;
            byte[] return_byte_array = new byte[4];
            ret_value = Parse_thermal_sensor_packet(input_packet, out return_byte_array);
            return_value_1 = (int)return_byte_array[0] * 256 + return_byte_array[1];
            return_value_2 = (int)return_byte_array[2] * 256 + return_byte_array[3];
            return ret_value;
        }

        // update out byte/int16/uint32/.....
        private bool Parse_thermal_sensor_packet(List<byte> input_packet, out byte [] return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_THERMAL_SENSOR_INDEX;

            bool ret_value = true;
            return_value = new byte [4];

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
                // update here
                return_value[0] = input_packet.ElementAt(4);
                return_value[1] = input_packet.ElementAt(5);
                return_value[2] = input_packet.ElementAt(6);
                return_value[3] = input_packet.ElementAt(7);
            }

            return ret_value;
        }

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

        public static byte XOR_Byte(byte[] bHEX1, int length)
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
                                flag_wait_for_receive = false;
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

        private void button_backlight_get_Click(object sender, EventArgs e)
        {
            byte backlight_value;

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            if (Get_Backlight_value(out backlight_value) == true)
            {
                label_backlight_show.Text = backlight_value.ToString();
            }

        }

        private void button_rgbgain_get_Click(object sender, EventArgs e)
        {
            byte[] rgbgain_value = new byte [3];

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            if (Get_RGBGain_value(out rgbgain_value) == true)
            {
                 label_rgbgain_show.Text = rgbgain_value[0] + "," + rgbgain_value[1] + "," + rgbgain_value[2];
            }
        }

        private void hScrollBar_backlight_set_Scroll(object sender, ScrollEventArgs e)
        {
            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            int check_packet = Set_Backlight_value((byte)hScrollBar_backlight_set.Value);

            switch (check_packet)
            {
                case 0:
                    label_backlight_show.Text = "No data";
                    break;
                case 1:
                    label_backlight_show.Text = "ACK";
                    break;
                case 2:
                    label_backlight_show.Text = "NACK";
                    break;
                case 3:
                    label_backlight_show.Text = "NAV";
                    break;
            }

        }

        private void hScrollBar_rgbgain_set_Scroll(object sender, ScrollEventArgs e)
        {
            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            int check_packet = Set_RGBGain_value((byte)numericUpDown_rgbgain_set.Value, (byte)hScrollBar_rgbgain_set.Value);

            string return_text ="";
            switch (check_packet)
            {
                case 0:
                    return_text = "No data";
                    break;
                case 1:
                    return_text = "ACK";
                    break;
                case 2:
                    return_text = "NACK";
                    break;
                case 3:
                    return_text = "NAV";
                    break;
            }
            label_rgbgain_show.Text = return_text;
        }

        private void numericUpDown_maininput_ValueChanged(object sender, EventArgs e)
        {
            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            int check_packet = Set_Main_input_value((byte)numericUpDown_maininput.Value);

            string return_text = "";
            switch (check_packet)
            {
                case 0:
                    return_text = "No data";
                    break;
                case 1:
                    return_text = "ACK";
                    break;
                case 2:
                    return_text = "NACK";
                    break;
                case 3:
                    return_text = "NAV";
                    break;
            }
            label_maininput_show.Text = return_text;
        }

        private void button_maininput_get_Click(object sender, EventArgs e)
        {
            byte main_input_value;

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            if (Get_Main_input_value(out main_input_value) == true)
            {
                string return_text = "";
                switch (main_input_value)
                {
                    case 0:
                        return_text = "VGA";
                        break;
                    case 1:
                        return_text = "YPbPr";
                        break;
                    case 2:
                        return_text = "DP";
                        break;
                    case 3:
                        return_text = "DVI1";
                        break;
                    case 4:
                        return_text = "DVI2";
                        break;
                    case 5:
                        return_text = "CVBS";
                        break;
                    case 6:
                        return_text = "Svideo";
                        break;
                    case 7:
                        return_text = "SDI";
                        break;
                }
                label_maininput_show.Text = return_text;
            }
        }

        private void button_backlight_sensor_get_Click(object sender, EventArgs e)
        {
            int sensor_value = 0;

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            if (Get_Backlight_sensor_value(out sensor_value) == true)
            {
                label_sensor_show.Text = sensor_value.ToString();
            }
        }

        private void button_thermal_sensor_get_Click(object sender, EventArgs e)
        {
            int sensor_value_1 = 0;
            int sensor_value_2 = 0;

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            if (Get_Thermal_sensor_value(out sensor_value_1, out sensor_value_2) == true)
            {
                label_sensor_show.Text = sensor_value_1 + "," + sensor_value_2;
            }
        }

        private void numericUpDown_gamma_set_ValueChanged(object sender, EventArgs e)
        {
            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            int check_packet = Set_Gamma_value((byte)numericUpDown_gamma_set.Value);        // update here

            string return_text = "";
            switch (check_packet)
            {
                case 0:
                    return_text = "No data";
                    break;
                case 1:
                    return_text = "ACK";
                    break;
                case 2:
                    return_text = "NACK";
                    break;
                case 3:
                    return_text = "NAV";
                    break;
            }
            label_gamma_show.Text = return_text;
        }

        private void button_gamma_get_Click(object sender, EventArgs e)
        {
            byte gamma_value;

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            if (Get_Gamma_value(out gamma_value) == true)           // update here
            {
                string return_text = "";
                switch (gamma_value)    // update here
                {
                    case 0:
                        return_text = "1.4";
                        break;
                    case 1:
                        return_text = "1.6";
                        break;
                    case 2:
                        return_text = "1.8";
                        break;
                    case 3:
                        return_text = "2.0";
                        break;
                    case 4:
                        return_text = "2.2";
                        break;
                    case 5:
                        return_text = "2.4";
                        break;
                    case 6:
                        return_text = "Video";
                        break;
                    case 7:
                        return_text = "HLG";
                        break;
                    case 8:
                        return_text = "DICOM";
                        break;
                }
                label_gamma_show.Text = return_text;            // update here
            }
        }

        private int Set_Gamma_value(byte set_value)
        {
            int cmd_index = (int)command_index.SET_GAMMA_INDEX; // update index here

            if (set_value > 8)        // update range check
            {
                // error handling
            }

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];

            // Update input data
            input_data[0] = set_value;

            Send_and_Receive_Packet(cmd_index, input_data);

            int check_packet = 0xff;
            if (dataListbyte.Count() > 0)
            {
                check_packet = check_Ack_packet();
            }
            return check_packet;
        }

        private bool Get_Gamma_value(out byte return_value)  // update here
        {
            int cmd_index = (int)command_index.GET_GAMMA_INDEX; // update index here
            bool ret_value = false;
            return_value = 0;       // update here

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            //input_data[0] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_gamma_packet(log_analysis, out return_value) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        private bool Parse_gamma_packet(List<byte> input_packet, out byte return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_GAMMA_INDEX;

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

            if (ret_value == true)
            {
                // update here
                return_value = input_packet.ElementAt(4);
            }

            return ret_value;
        }

        private void numericUpDown_colortemp_set_ValueChanged(object sender, EventArgs e)
        {
            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            // update here
            int check_packet = Set_colortemp_value((byte)numericUpDown_colortemp_set.Value);        // update here

            string return_text = "";
            switch (check_packet)
            {
                case 0:
                    return_text = "No data";
                    break;
                case 1:
                    return_text = "ACK";
                    break;
                case 2:
                    return_text = "NACK";
                    break;
                case 3:
                    return_text = "NAV";
                    break;
            }
            // update here
            label_colortemp_show.Text = return_text;            
        }

        private void button_colortemp_get_Click(object sender, EventArgs e)
        {
            byte colortemp_value;

            // Make sure Serial is open
            if (CheckSerialOpen() == false)
            {
                // error handling and return
            }

            // update here
            if (Get_colortemp_value(out colortemp_value) == true)           
            {
                string return_text = "";
                switch (colortemp_value)    // update here
                {
                    case 0:
                        return_text = "DCI-P3";
                        break;
                    case 1:
                        return_text = "5500K";
                        break;
                    case 2:
                        return_text = "6500K";
                        break;
                    case 3:
                        return_text = "7500K";
                        break;
                    case 4:
                        return_text = "9300K";
                        break;
                    case 5:
                        return_text = "User";
                        break;
                    case 6:
                        return_text = "Natural";
                        break;
                }
                // update here
                label_colortemp_show.Text = return_text;            
            }
        }

        // update here
        private int Set_colortemp_value(byte set_value)
        {
            // update index here
            int cmd_index = (int)command_index.SET_COLOR_TEMP_INDEX;

            // update range check
            if (set_value > 7)        
            {
                // error handling
            }

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];

            // Update input data
            input_data[0] = set_value;

            Send_and_Receive_Packet(cmd_index, input_data);

            int check_packet = 0xff;
            if (dataListbyte.Count() > 0)
            {
                check_packet = check_Ack_packet();
            }
            return check_packet;
        }

        // update here
        private bool Get_colortemp_value(out byte return_value)
        {
            // update index here
            int cmd_index = (int)command_index.GET_COLOR_TEMP_INDEX; 
            bool ret_value = false;
            // update here
            return_value = 0;       

            int input_data_length = Command_Packet[cmd_index].Length - 0x05;
            byte[] input_data = new byte[input_data_length];
            //input_data[0] = set_value;
            Send_and_Receive_Packet(cmd_index, input_data);

            // 檢查封包是否回傳正確的value.
            if (dataListbyte.Count() > 0)
            {
                List<byte> log_analysis = new List<byte>();
                log_analysis = dataListbyte.Dequeue();

                // update parsing here
                if (Parse_colortemp_packet(log_analysis, out return_value) == true)
                {
                    ret_value = true;
                }
                else
                {

                }
            }
            return ret_value;
        }

        // update here
        private bool Parse_colortemp_packet(List<byte> input_packet, out byte return_value)
        {
            // update here
            int PACKET_INDEX = (int)command_index.GET_COLOR_TEMP_INDEX;

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

            if (ret_value == true)
            {
                // update here
                return_value = input_packet.ElementAt(4);
            }

            return ret_value;
        }
    }
}
