using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance; // シングルトンインスタンス
    private AudioSource audioSource;   // AudioSourceフィールド

    [System.Serializable]
    public struct SceneBGM
    {
        public string sceneName;  // シーン名
        public AudioClip bgmClip; // 対応するBGMのAudioClip
    }

    public SceneBGM[] sceneBGMList; // シーンごとのBGMを設定

    private bool isFirstScene = true; // 最初のシーンかどうかを判定するフラグ

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // オブジェクトを永続化
            audioSource = GetComponentInChildren<AudioSource>(); // AudioSourceを子オブジェクトから取得

            if (audioSource == null)
            {
                Debug.LogError("BGMManagerにAudioSourceが設定されていません。");
            }
            else
            {
                Debug.Log("AudioSourceが正常に設定されました");
            }

            // シーン遷移時にBGMを変更
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // 重複するインスタンスを破棄
        }
    }

    // シーンが読み込まれた後に呼ばれるイベント
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("シーンが読み込まれました: " + scene.name);

        // 最初のシーンの場合はフェードアウトせずに直接再生
        if (isFirstScene)
        {
            isFirstScene = false; // 最初のシーンをフラグとして設定
            PlayBGMForScene(scene); // BGMを直接再生
        }
        else
        {
            // シーン名に対応するBGMを再生（フェードアウトあり）
            foreach (var sceneBGM in sceneBGMList)
            {
                if (scene.name == sceneBGM.sceneName)
                {
                    Debug.Log("再生するBGM: " + sceneBGM.bgmClip.name); // 再生するBGMのログ
                    PlayBGM(sceneBGM.bgmClip);
                    break;
                }
            }
        }
    }

    // 指定されたシーンに対応するBGMを再生
    private void PlayBGMForScene(Scene scene)
    {
        foreach (var sceneBGM in sceneBGMList)
        {
            if (scene.name == sceneBGM.sceneName)
            {
                audioSource.clip = sceneBGM.bgmClip;
                audioSource.Play();
                audioSource.volume = 0.2f; // フェードインせずにすぐ音量を最大に設定
                Debug.Log("最初のシーンのBGM: " + sceneBGM.bgmClip.name);
                break;
            }
        }
    }

    // BGMを再生するメソッド
    public void PlayBGM(AudioClip clip, float fadeDuration = 0.02f)
    {
        Debug.Log("PlayBGM called with clip: " + clip.name);
        StartCoroutine(FadeOutAndChangeClip(clip, fadeDuration));
    }

    // フェードアウトして新しいBGMを再生する
    private IEnumerator FadeOutAndChangeClip(AudioClip newClip, float fadeDuration)
    {
        Debug.Log("FadeOutAndChangeClip started");

        // フェードアウト
        if (audioSource.isPlaying)
        {
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
                Debug.Log("Fading out, volume: " + audioSource.volume);
                yield return null;
            }
            audioSource.Stop();
        }

        // 新しいクリップを設定してフェードイン
        audioSource.clip = newClip;
        audioSource.Play();

        float targetVolume = 0.2f; // フェードイン後の音量を20%に設定
        audioSource.volume = 0;  // フェードイン開始時は音量を0に設定

        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += Time.deltaTime / fadeDuration;
            if (audioSource.volume > targetVolume)
            {
                audioSource.volume = targetVolume; // 音量が20%を超えないように制限
            }
            Debug.Log("Fading in, volume: " + audioSource.volume);
            yield return null;
        }
        Debug.Log("FadeIn completed");
    }

    // BGMManagerが破棄される時に、シーン遷移イベントを解除
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
