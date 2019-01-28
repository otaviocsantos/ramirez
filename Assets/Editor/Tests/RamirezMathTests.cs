using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Ramirez;

public class RamirezMathTests
{

    [Test]
    public void Sum()
    {
        Assert.AreEqual(0, DoMath.Sum(new float[] { 0, -1, 1 }), "Assert corret sum of values");
        Assert.AreEqual(0, DoMath.Sum(new float[] { }), "Assert 0 for sum of empty");
        Assert.AreEqual(0, DoMath.Sum(null), "Assert 0 for sum of null");
        Assert.IsInstanceOf(typeof(float), DoMath.Sum(new float[] { 0.1f, -1.5f, -1.3f }), "Assert floats are not converted to int");
    }

    [Test]
    public void WeightedRandom()
    {

        string[] letters = new string[]{
            "A",
            "B",
            "C",
            "D"
        };

        for (int testFor = 0; testFor < 20; testFor++)
        {

            int[] result = new int[] { 0, 0, 0, 0 };

            int selectedLetter = -1;
            float[] weights = new float[] { 10, 20, 30, 40 };

            for (int i = 0; i < 1000000; i++)
            {

                selectedLetter = DoMath.WeightedRandom(weights);

                result[selectedLetter] = result[selectedLetter] + 1;

            }

            int v0 = Mathf.RoundToInt(result[0]) / 10000;
            int v1 = Mathf.RoundToInt(result[1]) / 10000;
            int v2 = Mathf.RoundToInt(result[2]) / 10000;
            int v3 = Mathf.RoundToInt(result[3]) / 10000;
            Assert.IsTrue(weights[0] <= v0 + 1 && weights[0] >= v0 - 1);
            Assert.IsTrue(weights[1] <= v1 + 1 && weights[1] >= v1 - 1);
            Assert.IsTrue(weights[2] <= v2 + 1 && weights[2] >= v2 - 1);
            Assert.IsTrue(weights[3] <= v3 + 1 && weights[3] >= v3 - 1);

        }

    }

}
