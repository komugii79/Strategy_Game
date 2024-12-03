using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    public TextMeshProUGUI LogText;  // �f�o�b�O���e��\������Text
    public CanvasGroup canvasGroup;    // �t�F�[�h����p��CanvasGroup

    private float displayTime = 1f;    // �\������
    private float fadeDuration = 0.5f;   // �t�F�[�h����
    private Coroutine coroutine;

    void Start()
    {
        // canvas���\���ɂ���
        canvasGroup.alpha = 0f;
    }
    public void ShowLog(string msg)
    {
        // ���݂̃��O�̕\��������
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        // �V�������O��\����\������
        coroutine = StartCoroutine(DisplayLogRoutine(msg));
    }
    private IEnumerator DisplayLogRoutine(string msg)
    {
        // ���O���Z�b�g���ăt�F�[�h�C��
        LogText.text = msg;
        yield return StartCoroutine(FadeCanvasGroup(0f,1f,fadeDuration));  

        // �w�莞�ԕ\��
        yield return new WaitForSeconds(displayTime);

        // �t�F�[�h�A�E�g
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
