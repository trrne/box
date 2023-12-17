﻿using UnityEngine;

namespace trrne.Box
{
    public static partial class Vec
    {
        public static void SetPosition(this Transform t, float? x = null, float? y = null, float? z = null)
        => t.position = new(x ?? t.position.x, y ?? t.position.y, z ?? t.position.z);
        public static void SetPosition(this GameObject gob, Vector2 pos) => gob.transform.position = pos;
        public static void SetPosition(this Transform t, Vector3 pos) => t.position = pos;
        public static void SetPosition(this Transform t, Vector2 pos) => t.position = pos;
        public static void SetPosition(this RaycastHit2D hit, Vector2 pos) => hit.collider.transform.position = pos;
        public static void SetPosition(this Collider2D info, Vector2 pos) => info.transform.position = pos;
        public static void SetPosition(this RectTransform rt, Vector2 pos) => rt.transform.position = pos;
        public static void SetPosition(this RectTransform rt, Vector3 pos) => rt.transform.position = (Vector2)pos;

        public static void ClampPosition(this Transform t,
            float? minX = null, float? maxX = null, float? minY = null, float? maxY = null)
        => t.position = new(Mathf.Clamp(t.position.x, (float)minX, (float)maxX),
            Mathf.Clamp(t.position.y, (float)minY, (float)maxY));
        public static void ClampPosition(this Transform t, float? x = null, float? y = null)
        => t.position = new(Mathf.Clamp(t.position.x, (float)x, (float)-x),
            Mathf.Clamp(t.position.y, (float)y, (float)-y));

        public static void SetVelocity(this Rigidbody2D rb, float? x = null, float? y = null)
        => rb.velocity = new(x ?? rb.velocity.x, y ?? rb.velocity.y);

        public static void ClampVelocity(this Rigidbody2D rb,
            (float min, float max)? x = null, (float min, float max)? y = null)
        => rb.velocity = new(x is null ? rb.velocity.x : Mathf.Clamp(rb.velocity.x, x.Value.min, x.Value.max),
            y is null ? rb.velocity.y : Mathf.Clamp(rb.velocity.y, y.Value.min, y.Value.max));

        public static void SetEuler(this Transform t, float? x = null, float? y = null, float? z = null)
        => t.rotation = Quaternion.Euler(x ?? t.localScale.x, y ?? t.localScale.y, z ?? t.lossyScale.z);
        public static void SetEuler(this Transform t, Vector3? p) => t.rotation = Quaternion.Euler(p ?? t.eulerAngles);

        public static void SetRotation(this Transform t, Quaternion q) => t.rotation = q;
        public static void SetRotation(this Transform t,
            float? x = null, float? y = null, float? z = null, float? w = null)
        => t.rotation = new(x ?? t.rotation.x, y ?? t.rotation.y, z ?? t.rotation.z, w ?? t.rotation.w);

        public static void SetScale(this Transform t, float? x = null, float? y = null, float? z = null)
        => t.rotation = Quaternion.Euler(x ?? t.localScale.x, y ?? t.localScale.y, z ?? t.lossyScale.z);
        public static void SetScale(this Transform t, Vector3 scale) => t.localScale = scale;
    }
}