using System;

namespace trrne.Box
{
    public static class Typing
    {
        public static string ReplaceLump(this string target, string[] befores, string after)
        {
            befores.ForEach(before => target = target.Replace(before, after));
            return target;
        }

        public static void ReplaceLump2(ref string target, string[] befores, string after)
        {
            string temp = target;
            befores.ForEach(before => temp = temp.Replace(before, after));
            target = temp;
        }

        public static string Delete(this string target, string be) => target.Replace(be, "");
        public static string DeleteLump(this string basis, params string[] targets)
        {
            targets.ForEach(target => basis = basis.Delete(target));
            return basis;
        }

        public static bool Subclass(this object obj, Type t) => obj.GetType().IsSubclassOf(t);
        public static bool Subclass(this object[] objs, Type t) => objs.GetType().IsSubclassOf(t);

        public static string Join(this object[] objs, string sep) => string.Join(sep, objs);

        public static string Link(this char[] objs) => string.Join("", objs);
        public static string Link(this byte[] b) => string.Join("", b);

        public static int Length<T>(this T t) where T : Enum => Enum.GetValues(t.GetType()).Length;
        public static int Length2<T>() where T : Enum => Enum.GetValues(typeof(T)).Length;
    }
}
