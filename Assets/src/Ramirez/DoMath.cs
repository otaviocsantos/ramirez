using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
namespace Ramirez
{
    /// <summary>
    /// String manipulation toolbox
    /// </summary>
    public class DoMath
    {
        private static System.Random _rnd = new System.Random();

        public static float Sum(float[] values = default(float[]))
        {
            if (values == default(float[]))
            {
                return 0;
            }

            float total = 0;
            foreach (float i in values)
            {
                total += i;
            }

            return total;
        }

        public static int WeightedRandom(float[] values = default(float[]))
        {
            if (values == default(float[]))
            {
                throw new System.Exception("Weighted array cannot be empty.");
            }

            float totalWeight = DoMath.Sum(values);

            float randomNumber = Random.value * totalWeight;

            for (int i = 0; i < values.Length; i++)
            {
                float broker = values[i];
                if (randomNumber <= broker)
                {
                    return i;
                }

                randomNumber = randomNumber - broker;
            }

            throw new System.Exception("Error picking random weighted item");
        }

    }
}
