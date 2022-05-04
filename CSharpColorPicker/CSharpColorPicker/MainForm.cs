using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpColorPicker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void colorPicker1_ColorChanged(object sender, ColorPicker.ColorChangedEventArgs e)
        {
            pbColor.BackColor = e.Color;
        }

        private void colorPickerVertical1_ColorChanged(object sender, ColorPickerVertical.ColorChangedEventArgs e)
        {
            colorPicker1.MainColor = e.Color;
        }
    }
}
