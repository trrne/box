﻿using System;

namespace trrne.Box
{
    public static class Lottery
    {
        // https://nekojara.city/unity-weighted-random-selection
        // https://youtu.be/3CQCBQRq0FA
        public static int Bst(params double[] weights)
        {
            if (weights.Length <= 0)
            {
                throw new KarappoyankeException("nanka kakankai");
            }

            var totals = new double[weights.Length];
            double total = .0;
            for (int i = 0; i < weights.Length; ++i)
            {
                total += weights[i];
                totals[i] = total;
            }

            double random = Rand.Double(max: total);
            int bottom = 0, top = totals.Length - 1;
            while (bottom < top)
            {
                int middle = (bottom + top) / 2;
                if (random > totals[middle])
                {
                    bottom = middle + 1;
                }
                else
                {
                    double point = middle > 0 ? totals[middle - 1] : 0;
                    if (random >= point)
                    {
                        return middle;
                    }
                    top = middle;
                }
            }
            return top;
        }

        public static int Bst(params float[] weights) => Bst(Array.ConvertAll(weights, w => (double)w));

        public static T Weighted<T>(this LotteryPair<T> pairs)
        => pairs.Length() switch
        {
            0 => throw null,
            1 => pairs.Subject(0),
            _ => pairs.Subject(Bst(pairs.Weights()))
        };
    }
}
