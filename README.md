# tsneByPythonnet
之前项目中用到C#调用python库，要不就是脚本调用，要不就是rpc服务调用，脚本调用无法传递复杂参数，rpc服务调用又觉得太麻烦，两边都需要制定协议。之前尝试过使用Keras.Net这个机器学习的库，是要通过后端调用python实现的，就试着去深入了解了一些这个东西，直到发现了pythonnet这个很🐂×的库，就尝试它来调用python上的sklearn。
# 1.准备数据
首先在python上下载手写字符的数据，这里下载很慢，在我给的git项目中会提供。

```python
from sklearn.datasets import fetch_openml
import numpy as np

mnist = fetch_openml('mnist_784', version=1, as_frame=False,cache=True)
mnist.target = mnist.target.astype(np.uint8)
mnist.data.shape
np.save("mnist_data",mnist.data)
np.save("mnist_target",mnist.target)
```
# 2.创建新项目
这里使用vs2022创建一个netcore3.1项目，然后安装Keras.Net3.8.5（这里面自带pythonnet依赖），这里后台安装的是python3.8.10，安装好对应的依赖库。

```csharp
public class TSNEByScikit: Base
    {
        PyObject PyInstance = null;

        public TSNEByScikit()
        {
            if (!PythonEngine.IsInitialized)
                PythonEngine.Initialize();

            using (Py.GIL())
            {
                dynamic manifold = Py.Import("sklearn.manifold");
                //这里很重要，不能带括号，否则后面FitTransform方法会报奇怪的错误
                dynamic tsne = manifold.TSNE;
                var ksargs = GetPrammeters();
                var pyargs = ToTuple(new object[]
                {
                    new PyInt(2)
                });
                PyInstance = tsne.Invoke(pyargs, ksargs);
            }
        }

        public NDarray FitTransform(NDarray X)
        {
            using (Py.GIL())
            {
                var obj = X.ToPython();
                PyTuple pyTuple = new PyTuple(new PyObject[] { X.PyObject});
                var kwargs = new PyDict();
                kwargs["X"] = X.PyObject;

                dynamic np = Py.Import("numpy");
                dynamic npX= np.array(new float[] {1,2,3});
                dynamic manifold = Py.Import("sklearn.linear_model");

                NDarray result= new NDarray(this.PyInstance.InvokeMethod("fit_transform", pyTuple));
                //float[] netResult = result.GetData<float>();
                return result;
            }
        }

        private PyDict GetPrammeters()
        {
            PyDict result = new PyDict();
            //result["n_components"] =new PyInt(2);
            result["random_state"] = new PyInt(42);
            return result;
        }
    }
```
# 3.调用tsne算法
先设置好参与训练的数据个数，点击读取数据，再点击tsne转换。
![在这里插入图片描述](https://img-blog.csdnimg.cn/9ee6df589a714491b155889846ead1db.png)

```csharp
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
```
