using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotspring
{
    public partial class Form_hotspring : Form
    {
        public Form_hotspring()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    var Usertest = new Usertest();
                    //不要顯示Title
                    Usertest.FormBorderStyle = FormBorderStyle.None;

                    //非最上層
                    Usertest.TopLevel = false;

                    //顯示From，要加上去才會顯示Form
                    Usertest.Visible = true;

                    //設定From位置
                    Usertest.Top = 0;
                    Usertest.Left = 0;

                    //將Form加入tabPage中
                    tabPage_user.Controls.Add(Usertest);

                    //顯示tabPage
                    tabPage_user.Show();
                    break;
                case 1:
                    var Selftest = new Selftest();
                    //不要顯示Title
                    Selftest.FormBorderStyle = FormBorderStyle.None;

                    //非最上層
                    Selftest.TopLevel = false;

                    //顯示From，要加上去才會顯示Form
                    Selftest.Visible = true;

                    //設定From位置
                    Selftest.Top = 0;
                    Selftest.Left = 0;

                    //將Form加入tabPage中
                    tabPage_self.Controls.Add(Selftest);

                    //顯示tabPage
                    tabPage_self.Show();
                    break;
            }
        }

        private void Form_hotspring_Load(object sender, EventArgs e)
        {
            var Usertest = new Usertest();
            //不要顯示Title
            Usertest.FormBorderStyle = FormBorderStyle.None;

            //非最上層
            Usertest.TopLevel = false;

            //顯示From，要加上去才會顯示Form
            Usertest.Visible = true;

            //設定From位置
            Usertest.Top = 0;
            Usertest.Left = 0;

            //將Form加入tabPage中
            tabPage_user.Controls.Add(Usertest);

            //顯示tabPage
            tabPage_user.Show();
        }
    }
}
