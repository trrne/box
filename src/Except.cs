﻿using System;

namespace trrne.Box
{
    [Serializable]
    public class Karappoyanke : Exception
    {
        public Karappoyanke() : base("からっぽえんぷてぃ") {; }
        public Karappoyanke(string msg = null) : base(msg) {; }
    }
}
