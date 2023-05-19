namespace HiscomEngine.ThirdParty.LeanTween.Runtime.Scripts
{
    using System;
    using UnityEngine;
    
    public static class LeanTweenExt
    {
        //LeanTween.addListener
        //LeanTween.alpha
        public static LTDescr LeanAlpha(this GameObject gameObject, float to, float time) { return global::LeanTween.alpha(gameObject, to, time); }
        //LeanTween.alphaCanvas
        public static LTDescr LeanAlphaVertex(this GameObject gameObject, float to, float time) { return global::LeanTween.alphaVertex(gameObject, to, time); }
        //LeanTween.alpha (RectTransform)
        public static LTDescr LeanAlpha(this RectTransform rectTransform, float to, float time) { return global::LeanTween.alpha(rectTransform, to, time); }
        //LeanTween.alphaCanvas
        public static LTDescr LeanAlpha(this CanvasGroup canvas, float to, float time) { return global::LeanTween.alphaCanvas(canvas, to, time); }
        //LeanTween.alphaText
        public static LTDescr LeanAlphaText(this RectTransform rectTransform, float to, float time) { return global::LeanTween.alphaText(rectTransform, to, time); }
        //LeanTween.cancel
        public static void LeanCancel(this GameObject gameObject) { global::LeanTween.cancel(gameObject); }
        public static void LeanCancel(this GameObject gameObject, bool callOnComplete) { global::LeanTween.cancel(gameObject, callOnComplete); }
        public static void LeanCancel(this GameObject gameObject, int uniqueId, bool callOnComplete = false) { global::LeanTween.cancel(gameObject, uniqueId, callOnComplete); }
        //LeanTween.cancel
        public static void LeanCancel(this RectTransform rectTransform) { global::LeanTween.cancel(rectTransform); }
        //LeanTween.cancelAll
        //LeanTween.color
        public static LTDescr LeanColor(this GameObject gameObject, Color to, float time) { return global::LeanTween.color(gameObject, to, time); }
        //LeanTween.colorText
        public static LTDescr LeanColorText(this RectTransform rectTransform, Color to, float time) { return global::LeanTween.colorText(rectTransform, to, time); }
        //LeanTween.delayedCall
        public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, System.Action callback) { return global::LeanTween.delayedCall(gameObject, delayTime, callback); }
        public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, System.Action<object> callback) { return global::LeanTween.delayedCall(gameObject, delayTime, callback); }

        //LeanTween.isPaused
        public static bool LeanIsPaused(this GameObject gameObject) { return global::LeanTween.isPaused(gameObject); }
        public static bool LeanIsPaused(this RectTransform rectTransform) { return global::LeanTween.isPaused(rectTransform); }

        //LeanTween.isTweening
        public static bool LeanIsTweening(this GameObject gameObject) { return global::LeanTween.isTweening(gameObject); }
        //LeanTween.isTweening
        //LeanTween.move
        public static LTDescr LeanMove(this GameObject gameObject, Vector3 to, float time) { return global::LeanTween.move(gameObject, to, time); }
        public static LTDescr LeanMove(this Transform transform, Vector3 to, float time) { return global::LeanTween.move(transform.gameObject, to, time); }
        public static LTDescr LeanMove(this RectTransform rectTransform, Vector3 to, float time) { return global::LeanTween.move(rectTransform, to, time); }
        //LeanTween.move
        public static LTDescr LeanMove(this GameObject gameObject, Vector2 to, float time) { return global::LeanTween.move(gameObject, to, time); }
        public static LTDescr LeanMove(this Transform transform, Vector2 to, float time) { return global::LeanTween.move(transform.gameObject, to, time); }
        //LeanTween.move
        public static LTDescr LeanMove(this GameObject gameObject, Vector3[] to, float time) { return global::LeanTween.move(gameObject, to, time); }
        public static LTDescr LeanMove(this GameObject gameObject, LTBezierPath to, float time) { return global::LeanTween.move(gameObject, to, time); }
        public static LTDescr LeanMove(this GameObject gameObject, LTSpline to, float time) { return global::LeanTween.move(gameObject, to, time); }
        public static LTDescr LeanMove(this Transform transform, Vector3[] to, float time) { return global::LeanTween.move(transform.gameObject, to, time); }
        public static LTDescr LeanMove(this Transform transform, LTBezierPath to, float time) { return global::LeanTween.move(transform.gameObject, to, time); }
        public static LTDescr LeanMove(this Transform transform, LTSpline to, float time) { return global::LeanTween.move(transform.gameObject, to, time); }
        //LeanTween.moveLocal
        public static LTDescr LeanMoveLocal(this GameObject gameObject, Vector3 to, float time) { return global::LeanTween.moveLocal(gameObject, to, time); }
        public static LTDescr LeanMoveLocal(this GameObject gameObject, LTBezierPath to, float time) { return global::LeanTween.moveLocal(gameObject, to, time); }
        public static LTDescr LeanMoveLocal(this GameObject gameObject, LTSpline to, float time) { return global::LeanTween.moveLocal(gameObject, to, time); }
        public static LTDescr LeanMoveLocal(this Transform transform, Vector3 to, float time) { return global::LeanTween.moveLocal(transform.gameObject, to, time); }
        public static LTDescr LeanMoveLocal(this Transform transform, LTBezierPath to, float time) { return global::LeanTween.moveLocal(transform.gameObject, to, time); }
        public static LTDescr LeanMoveLocal(this Transform transform, LTSpline to, float time) { return global::LeanTween.moveLocal(transform.gameObject, to, time); }
        //LeanTween.moveLocal
        public static LTDescr LeanMoveLocalX(this GameObject gameObject, float to, float time) { return global::LeanTween.moveLocalX(gameObject, to, time); }
        public static LTDescr LeanMoveLocalY(this GameObject gameObject, float to, float time) { return global::LeanTween.moveLocalY(gameObject, to, time); }
        public static LTDescr LeanMoveLocalZ(this GameObject gameObject, float to, float time) { return global::LeanTween.moveLocalZ(gameObject, to, time); }
        public static LTDescr LeanMoveLocalX(this Transform transform, float to, float time) { return global::LeanTween.moveLocalX(transform.gameObject, to, time); }
        public static LTDescr LeanMoveLocalY(this Transform transform, float to, float time) { return global::LeanTween.moveLocalY(transform.gameObject, to, time); }
        public static LTDescr LeanMoveLocalZ(this Transform transform, float to, float time) { return global::LeanTween.moveLocalZ(transform.gameObject, to, time); }
        //LeanTween.moveSpline
        public static LTDescr LeanMoveSpline(this GameObject gameObject, Vector3[] to, float time) { return global::LeanTween.moveSpline(gameObject, to, time); }
        public static LTDescr LeanMoveSpline(this GameObject gameObject, LTSpline to, float time) { return global::LeanTween.moveSpline(gameObject, to, time); }
        public static LTDescr LeanMoveSpline(this Transform transform, Vector3[] to, float time) { return global::LeanTween.moveSpline(transform.gameObject, to, time); }
        public static LTDescr LeanMoveSpline(this Transform transform, LTSpline to, float time) { return global::LeanTween.moveSpline(transform.gameObject, to, time); }
        //LeanTween.moveSplineLocal
        public static LTDescr LeanMoveSplineLocal(this GameObject gameObject, Vector3[] to, float time) { return global::LeanTween.moveSplineLocal(gameObject, to, time); }
        public static LTDescr LeanMoveSplineLocal(this Transform transform, Vector3[] to, float time) { return global::LeanTween.moveSplineLocal(transform.gameObject, to, time); }
        //LeanTween.moveX
        public static LTDescr LeanMoveX(this GameObject gameObject, float to, float time) { return global::LeanTween.moveX(gameObject, to, time); }
        public static LTDescr LeanMoveX(this Transform transform, float to, float time) { return global::LeanTween.moveX(transform.gameObject, to, time); }
        //LeanTween.moveX (RectTransform)
        public static LTDescr LeanMoveX(this RectTransform rectTransform, float to, float time) { return global::LeanTween.moveX(rectTransform, to, time); }
        //LeanTween.moveY
        public static LTDescr LeanMoveY(this GameObject gameObject, float to, float time) { return global::LeanTween.moveY(gameObject, to, time); }
        public static LTDescr LeanMoveY(this Transform transform, float to, float time) { return global::LeanTween.moveY(transform.gameObject, to, time); }
        //LeanTween.moveY (RectTransform)
        public static LTDescr LeanMoveY(this RectTransform rectTransform, float to, float time) { return global::LeanTween.moveY(rectTransform, to, time); }
        //LeanTween.moveZ
        public static LTDescr LeanMoveZ(this GameObject gameObject, float to, float time) { return global::LeanTween.moveZ(gameObject, to, time); }
        public static LTDescr LeanMoveZ(this Transform transform, float to, float time) { return global::LeanTween.moveZ(transform.gameObject, to, time); }
        //LeanTween.moveZ (RectTransform)
        public static LTDescr LeanMoveZ(this RectTransform rectTransform, float to, float time) { return global::LeanTween.moveZ(rectTransform, to, time); }
        //LeanTween.pause
        public static void LeanPause(this GameObject gameObject) { global::LeanTween.pause(gameObject); }
        //LeanTween.play
        public static LTDescr LeanPlay(this RectTransform rectTransform, UnityEngine.Sprite[] sprites) { return global::LeanTween.play(rectTransform, sprites); }
        //LeanTween.removeListener
        //LeanTween.resume
        public static void LeanResume(this GameObject gameObject) { global::LeanTween.resume(gameObject); }
        //LeanTween.resumeAll
        //LeanTween.rotate 
        public static LTDescr LeanRotate(this GameObject gameObject, Vector3 to, float time) { return global::LeanTween.rotate(gameObject, to, time); }
        public static LTDescr LeanRotate(this Transform transform, Vector3 to, float time) { return global::LeanTween.rotate(transform.gameObject, to, time); }
        //LeanTween.rotate
        //LeanTween.rotate (RectTransform)
        public static LTDescr LeanRotate(this RectTransform rectTransform, Vector3 to, float time) { return global::LeanTween.rotate(rectTransform, to, time); }
        //LeanTween.rotateAround
        public static LTDescr LeanRotateAround(this GameObject gameObject, Vector3 axis, float add, float time) { return global::LeanTween.rotateAround(gameObject, axis, add, time); }
        public static LTDescr LeanRotateAround(this Transform transform, Vector3 axis, float add, float time) { return global::LeanTween.rotateAround(transform.gameObject, axis, add, time); }
        //LeanTween.rotateAround (RectTransform)
        public static LTDescr LeanRotateAround(this RectTransform rectTransform, Vector3 axis, float add, float time) { return global::LeanTween.rotateAround(rectTransform, axis, add, time); }
        //LeanTween.rotateAroundLocal
        public static LTDescr LeanRotateAroundLocal(this GameObject gameObject, Vector3 axis, float add, float time) { return global::LeanTween.rotateAroundLocal(gameObject, axis, add, time); }
        public static LTDescr LeanRotateAroundLocal(this Transform transform, Vector3 axis, float add, float time) { return global::LeanTween.rotateAroundLocal(transform.gameObject, axis, add, time); }
        //LeanTween.rotateAround (RectTransform)
        public static LTDescr LeanRotateAroundLocal(this RectTransform rectTransform, Vector3 axis, float add, float time) { return global::LeanTween.rotateAroundLocal(rectTransform, axis, add, time); }
        //LeanTween.rotateLocal
        //LeanTween.rotateX
        public static LTDescr LeanRotateX(this GameObject gameObject, float to, float time) { return global::LeanTween.rotateX(gameObject, to, time); }
        public static LTDescr LeanRotateX(this Transform transform, float to, float time) { return global::LeanTween.rotateX(transform.gameObject, to, time); }
        //LeanTween.rotateY
        public static LTDescr LeanRotateY(this GameObject gameObject, float to, float time) { return global::LeanTween.rotateY(gameObject, to, time); }
        public static LTDescr LeanRotateY(this Transform transform, float to, float time) { return global::LeanTween.rotateY(transform.gameObject, to, time); }
        //LeanTween.rotateZ
        public static LTDescr LeanRotateZ(this GameObject gameObject, float to, float time) { return global::LeanTween.rotateZ(gameObject, to, time); }
        public static LTDescr LeanRotateZ(this Transform transform, float to, float time) { return global::LeanTween.rotateZ(transform.gameObject, to, time); }
        //LeanTween.scale
        public static LTDescr LeanScale(this GameObject gameObject, Vector3 to, float time) { return global::LeanTween.scale(gameObject, to, time); }
        public static LTDescr LeanScale(this Transform transform, Vector3 to, float time) { return global::LeanTween.scale(transform.gameObject, to, time); }
        //LeanTween.scale (GUI)
        //LeanTween.scale (RectTransform)
        public static LTDescr LeanScale(this RectTransform rectTransform, Vector3 to, float time) { return global::LeanTween.scale(rectTransform, to, time); }
        //LeanTween.scaleX
        public static LTDescr LeanScaleX(this GameObject gameObject, float to, float time) { return global::LeanTween.scaleX(gameObject, to, time); }
        public static LTDescr LeanScaleX(this Transform transform, float to, float time) { return global::LeanTween.scaleX(transform.gameObject, to, time); }
        //LeanTween.scaleY
        public static LTDescr LeanScaleY(this GameObject gameObject, float to, float time) { return global::LeanTween.scaleY(gameObject, to, time); }
        public static LTDescr LeanScaleY(this Transform transform, float to, float time) { return global::LeanTween.scaleY(transform.gameObject, to, time); }
        //LeanTween.scaleZ
        public static LTDescr LeanScaleZ(this GameObject gameObject, float to, float time) { return global::LeanTween.scaleZ(gameObject, to, time); }
        public static LTDescr LeanScaleZ(this Transform transform, float to, float time) { return global::LeanTween.scaleZ(transform.gameObject, to, time); }
        //LeanTween.sequence
        //LeanTween.size (RectTransform)
        public static LTDescr LeanSize(this RectTransform rectTransform, Vector2 to, float time) { return global::LeanTween.size(rectTransform, to, time); }
        //LeanTween.tweensRunning
        //LeanTween.value (Color)
        public static LTDescr LeanValue(this GameObject gameObject, Color from, Color to, float time) { return global::LeanTween.value(gameObject, from, to, time); }
        //LeanTween.value (Color)
        //LeanTween.value (float)
        public static LTDescr LeanValue(this GameObject gameObject, float from, float to, float time) { return global::LeanTween.value(gameObject, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Vector2 from, Vector2 to, float time) { return global::LeanTween.value(gameObject, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Vector3 from, Vector3 to, float time) { return global::LeanTween.value(gameObject, from, to, time); }
        //LeanTween.value (float)
        public static LTDescr LeanValue(this GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time) { return global::LeanTween.value(gameObject, callOnUpdate, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Action<float, float> callOnUpdate, float from, float to, float time) { return global::LeanTween.value(gameObject, callOnUpdate, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time) { return global::LeanTween.value(gameObject, callOnUpdate, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time) { return global::LeanTween.value(gameObject, callOnUpdate, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time) { return global::LeanTween.value(gameObject, callOnUpdate, from, to, time); }
        public static LTDescr LeanValue(this GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time) { return global::LeanTween.value(gameObject, callOnUpdate, from, to, time); }

        public static void LeanSetPosX(this Transform transform, float val){
            transform.position = new Vector3(val, transform.position.y, transform.position.z);
        }
        public static void LeanSetPosY(this Transform transform, float val) {
            transform.position = new Vector3(transform.position.x, val, transform.position.z);
        }
        public static void LeanSetPosZ(this Transform transform, float val) {
            transform.position = new Vector3(transform.position.x, transform.position.y, val);
        }

        public static void LeanSetLocalPosX(this Transform transform, float val)
        {
            transform.localPosition = new Vector3(val, transform.localPosition.y, transform.localPosition.z);
        }
        public static void LeanSetLocalPosY(this Transform transform, float val)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, val, transform.localPosition.z);
        }
        public static void LeanSetLocalPosZ(this Transform transform, float val)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, val);
        }

        public static Color LeanColor(this Transform transform)
        {
            return transform.GetComponent<Renderer>().material.color;
        }
    }
}
