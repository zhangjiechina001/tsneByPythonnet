using Python.Runtime;
using System;
using System.Collections.Generic;

namespace TSNEByPython
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic sklearn = Py.Import("sklearn");
                dynamic tsne = sklearn.manifold.TSNE;
                var ksargs = GetPrammeters();
                tsne.Invoke(ksargs);
                //dynamic tsne= manifold.TSNE();

                dynamic np = Py.Import("numpy");
                Console.WriteLine(np.cos(np.pi * 2));

                dynamic sin = np.sin;
                Console.WriteLine(sin(5));

                double c = (double)(np.cos(5) + sin(5));
                Console.WriteLine(c);

                dynamic a = np.array(new List<float> { 1, 2, 3 });
                Console.WriteLine(a.dtype);

                dynamic b = np.array(new List<float> { 6, 5, 4 }, dtype: np.int32);
                Console.WriteLine(b.dtype);

                Console.WriteLine(a * b);
                Console.ReadKey();
            }
        }

        private static PyDict GetPrammeters()
        {
            //n_components=2, random_state=42
            PyDict result = new PyDict();
            result["n_components"] =new PyFloat(2.0f);
            result["random_state"] = new PyInt(42);
            return result;
        }
    }
}
