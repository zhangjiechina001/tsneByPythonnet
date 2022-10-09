using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Keras.Utils;
using Keras;
using Numpy;
using Numpy.Models;
using Python.Runtime;
using TSNEByPython;
using System.Diagnostics;

namespace TSNEForms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        NDarray X = null;
        NDarray y = null;
        private void btnLoad_Click(object sender, EventArgs e)
        {
            var X=np.load("mnist_data.npy");
            lstLog.Items.Add(X.shape);

            var y = np.load("mnist_target.npy");
            lstLog.Items.Add(y.shape);

            int count = (int)numScale.Value;
            this.X = X[$":{count},:"].astype(np.float16);
            this.y = y[$":{count}"]; ;
        }

        private void btnTSNE_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            TSNEByScikit tsne = new TSNEByScikit();
            var result=tsne.FitTransform(X);
            sw.Stop();
            lstLog.Items.Add($"{this.X.shape[0]}条数据，耗时{sw.ElapsedMilliseconds}ms");
            var xs = result[":,0"].GetData<float>().Select(t => (double)t).ToArray(); 
            var ys = result[":,1"].GetData<float>().Select(t => (double)t).ToArray();
            var t = y.GetData<byte>();
            var splitSamples = SplitSamples(xs, ys, t);
            pltResult.Plot.Clear();
            var colors = GetColors();
            foreach (var item in splitSamples)
            {
                int colorData = item.target;
                pltResult.Plot.AddScatter(new double[] {item.xs}, new double[] {item.ys }, colors[colorData]);
            }
            
            pltResult.Refresh();
        }

        private List<(int target, double xs, double ys)> SplitSamples(double[] xs,double[] ys,byte[] target)
        {
            List<(int, double, double)> datas = new List<(int, double, double)>();
            for (int i = 0; i < xs.Length; i++)
            {
                datas.Add((target[i], xs[i], ys[i]));
            }
            return datas;
        }

        private Color[] GetColors()
        {
            return new Color[] { Color.Red, Color.Yellow, Color.Gray, Color.Gold, Color.HotPink, Color.LemonChiffon, Color.Black, Color.Black, Color.Brown,Color.Cyan };
        }
    }
}
