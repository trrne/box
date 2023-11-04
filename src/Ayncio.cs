﻿using UnityEngine;

namespace trrne.Box
{
    public sealed class Asyncio
    {
        public static WaitForSeconds Wait(float seconds) => new WaitForSeconds(seconds);
        public static WaitForSeconds Wait() => Wait(1f);
    }
}
