using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ExamenPrimerParcial__Imágen_
{
    public partial class Form1 : Form
    {

        Image<Bgr, byte> imgInput;
        Image<Gray, byte> _GrayImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgInput = new Image<Bgr, byte>(ofd.FileName);
                imageBox1.Image = imgInput;
            }


        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Salir?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();


            }
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> imgCanny = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray());
            imgCanny = imgInput.Canny(50, 50);
            imageBox1.Image = imgCanny;
        }

        private void histogramBox1_Load(object sender, EventArgs e)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate(new Image<Gray, byte>[] { imgInput[0] }, false, null);
            Mat m = new Mat();
            hist.CopyTo(m);
            histogramBox1.AddHistogram("Histograma de color rojo", Color.Red, m, 256, new float[] { 0, 255 });
            histogramBox1.Refresh();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
            hist.Calculate(new Image<Gray, byte>[] { imgInput[2] }, false, null);
            Mat m = new Mat();
            hist.CopyTo(m);
            histogramBox1.AddHistogram("Histograma de color Rojo", Color.Red, m, 256, new float[] { 0, 255 });
            histogramBox1.Refresh();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Salir?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();


            }
        }
    }
}
