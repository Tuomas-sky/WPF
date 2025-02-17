using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentManagetUpdata
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            old.Text = openFileDialog.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            openFileDialog.ShowDialog();
            new1.Text = openFileDialog.FileName;
            var rse = MessageBox.Show("是否升级替换","升级提示",MessageBoxButtons.YesNo);
            if (rse == DialogResult.Yes)
            {
                File.Delete(old.Text);
                File.Copy(new1.Text, old.Text);
                MessageBox.Show("更新成功");
            }
        }
    }
}
