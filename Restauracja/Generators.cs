using System;

namespace Restaurant
{
    public static class Generators
    {
        private const double E = 2.718281828459;
        private const double PI = 3.14159265359;
        private static readonly XorShiftRandom Random;
        static Generators()
        {
            Random = new XorShiftRandom();
        }
        public static int GaussianDistribution(int average, int variance)           //Boxa-Mullera  //normalny, gaussa
        {

            var U1 = 1.0 - Random.NextDouble();
            var U2 = 1.0 - Random.NextDouble();
            var RandStdNormal = Math.Sqrt(-2.0 * Math.Log(U1)) * Math.Sin(2.0 * PI * U2);
            var RandNormal = average + variance * RandStdNormal;
            return (int)RandNormal;
        }

        public static int ExponentialDistribution(int mean)                         //wykładniczy, metoda odwrotnej dystrybuanty 
        {
            return Convert.ToInt32(-mean * Math.Log((1 - Random.NextDouble()), E));
        }

        public static double UniformDistribution()      //xorshift
        {
            return Random.NextDouble();
        }

    }
}
