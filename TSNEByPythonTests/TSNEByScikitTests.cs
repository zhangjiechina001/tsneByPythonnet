using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numpy;
using TSNEByPython;

namespace TSNEByPythonTests
{
    [TestClass]
    public class TSNEByScikitTests
    {
        [TestMethod]
        public void TestFitTransform()
        {
            TSNEByScikit tsne=new TSNEByScikit();
            var input = new float[,] { { 1, 2 }, { 2, 3} };
            var y =new float[] { 1,2 };
            
            tsne.FitTransform(np.array(input));
        }
    }
}
