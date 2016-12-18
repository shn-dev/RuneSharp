using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuneSharp;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dLongGraph = RuneMethods.getGraph(26587);
            var dLongGraphData = dLongGraph.daily.GraphPoints;

            foreach(Models.GraphResponse.GraphPoint point in dLongGraphData){
                Console.WriteLine(point.date + " " + point.price);
            }
        }
    }
}
