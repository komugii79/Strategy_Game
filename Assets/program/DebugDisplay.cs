using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    public TextMeshProUGUI LogText;  // デバッグ内容を表示するText
    public CanvasGroup canvasGroup;    // フェード制御用のCanvasGroup

    private float displayTime = 1f;    // 表示時間
    private float fadeDuration = 0.5f;   // フェード時間
    private Coroutine coroutine;

    void Start()
    {
        // canvasを非表示にする
        canvasGroup.alpha = 0f;
    }
    public void ShowLog(string msg)
    {
        // 現在のログの表示を消す
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        // 新しいログを表示を表示する
        coroutine = StartCoroutine(DisplayLogRoutine(msg));
    }
    private IEnumerator DisplayLogRoutine(string msg)
    {
        // ログをセットしてフェードイン
        LogText.text = msg;
        yield return StartCoroutine(FadeCanvasGroup(0f,1f,fadeDuration));  

        // 指定時間表示
        yield return new WaitForSeconds(displayTime);

        // フェードアウト
        yield return StartCoroutine(FadeCanvasGroup(0.5f,0f,fadeDuration));
    }

    private IEnumerator FadeCanvasGroup(float startAlpha,float endAlpha,float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            yield return null;
        }
        canvasGroup.alpha = endAlpha;
    }

}
