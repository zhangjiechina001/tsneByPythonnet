using Keras.Utils;
using Keras;
using Numpy;
using Numpy.Models;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSNEByPython
{
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
}
