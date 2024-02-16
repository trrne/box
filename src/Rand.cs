using System;
using System.Collections.Generic;
using System.Linq;

namespace trrne.Box
{
    public static class Rand
    {
        readonly static Random rand;
        static Rand() => rand = new((int)DateTime.Now.Ticks);

        /// <summary>
        /// 乱数生成器 -> <b>double</b><br/>
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値(含む)</param>
        /// <returns>minからmaxまでの乱数を返す</returns>
        public static double Double(double min = 0.0, double max = 0.0) => rand.NextDouble() * (max - min) + min;

        /// <summary>
        /// 乱数生成器 -> <b>float</b><br/>
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値(含む)</param>
        /// <returns>minからmaxまでの乱数を返す</returns>
        public static float Float(float min = 0, float max = 0) => (float)Double(min, max); // (float)Double(min, max);

        /// <summary>
        /// 乱数生成器 -> <b>float</b><br/>
        /// </summary>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値(含む)</param>
        /// <returns>minからmaxまでの乱数を返す</returns>
        public static int Int(int min = 0, int max = 0) => (int)Double(min, max); // MF.Cutail((float)Double(min, max));

        /// <summary>
        /// 文字列生成 -> <b>string</b><br/>
        /// <c>String(length, RandStringType.Number)</c>
        /// </summary>
        /// <param name="length">文字数</param>
        /// <param name="type">null</param>
        /// <returns>length文字ランダムに選択し、返す</returns>
        public static string String(int length, RandStringType? type = null)
        {
            char[] numbers = "0123456789".ToCharArray(),
               alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

            string Mixer(char[] array, int start, int end)
            {
                bool isMixed = array is null && start == -1 && end == -1;
                var chars = new char[length];
                for (int i = 0; i < length; i++)
                {
                    chars[i] = isMixed ?
                        alphabets.Concat(numbers).ToArray().Choice() :
                        array[Int(start, end - 1)];
                }
                return chars.Link();
            }

            return type switch
            {
                RandStringType.ABMixed => Mixer(alphabets, 0, alphabets.Length),
                RandStringType.ABUpper => Mixer(alphabets, alphabets.Length / 2, alphabets.Length),
                RandStringType.ABLower => Mixer(alphabets, 0, alphabets.Length),
                RandStringType.Number => Mixer(numbers, 0, numbers.Length),
                RandStringType.Mixed or _ => Mixer(null, -1, -1)
            };
        }

        public static string String() => String(Int(2, 10), RandStringType.Mixed);
        public static string String(int length) => String(length, RandStringType.Mixed);
        public static void String(ref string output, int length) => output = String(length);

        public static int Choice0<T>(this T[] arr) => rand.Next(0, arr.Length - 1);

        /// <summary>
        /// 配列からランダムに選択する
        /// </summary>
        /// <typeparam name="T">配列の型</typeparam>
        /// <param name="arr">対象の配列</param>
        /// <returns>配列から選択された要素を返す</returns>
        public static T Choice<T>(this T[] arr) => arr[arr.Choice0()];

        /// <summary>
        /// リストからランダムに選択する
        /// </summary>
        /// <typeparam name="T">リストの型</typeparam>
        /// <param name="arr">対象のリスト</param>
        /// <returns>リストから選択された要素を返す</returns>
        public static T Choice<T>(this List<T> arr) => arr.ToArray().Choice(); // arr[rand.Next(0, arr.Count)];
    }
}