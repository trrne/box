﻿using UnityEngine;
using UniApp = UnityEngine.Application;

namespace trrne.Box
{
    public static class Paths
    {
        public static string Data => UniApp.dataPath;
        public static string Persistant => UniApp.persistentDataPath;
    }

    public class App
    {
        public static void SetFPS(int fps = -1) => UniApp.targetFrameRate = fps;
        public static void SetFPS(FrameRate fps) => UniApp.targetFrameRate = (int)fps;

        public static float FPSf => Mathf.Floor(1 / Time.deltaTime);
        public static int FPSint => Maths.Cutail(FPSf);

        public static void SetCursorStatus(CursorAppearance appear, CursorRangeOfMotion rangeOfMotion)
        {
            Cursor.visible = appear == CursorAppearance.Visible;
            Cursor.lockState = (CursorLockMode)rangeOfMotion;
        }

        public static bool TimeScale(float scale, out float truth)
        {
            truth = Time.timeScale;
            return Time.timeScale == scale;
        }

        public static void SetTimeScale(float scale) => Time.timeScale = scale;

        public static RuntimePlatform Platform => UniApp.platform;

        public static bool IsPlatform(RuntimePlatform platform, out RuntimePlatform truth)
        {
            truth = UniApp.platform;
            return platform == UniApp.platform;
        }

        public static Vector2 GetScreenInfo(KindaScreen kinda)
        => kinda switch
        {
            KindaScreen.Resolution => new(Screen.currentResolution.width, Screen.currentResolution.height),
            KindaScreen.Size => new(Screen.width, Screen.height),
            KindaScreen.Center => GetScreenInfo(KindaScreen.Size) / 2,
            _ => throw null
        };

        public static void SetCameraSize(float size) => Camera.main.orthographicSize = size;
        public static float CameraSize => Camera.main.orthographicSize;
    }
}
