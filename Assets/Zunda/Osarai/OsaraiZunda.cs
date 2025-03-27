using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsaraiZunda : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private ChangeScene changeScene;
    void Start()
    {
        audioSource.PlayOneShot(clip);
        StartCoroutine(WaitForSoundToFinish());

        changeScene = GetComponent<ChangeScene>();
    }

    // 音声が終了するのを待つコルーチン
    IEnumerator WaitForSoundToFinish()
    {
        // 音声が再生されている間は待機
        while (audioSource.isPlaying)
        {
            yield return null; // 次のフレームまで待機
        }

        // 音声の再生が終了したら指定した関数を呼び出す
        OnSoundFinished();
    }

    IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(3.0f);
        changeScene.NextScene();
    }

    // 音声が終了したときに呼ばれる関数
    void OnSoundFinished()
    {
        Debug.Log("音声が終了しました！");
        // ここで任意の処理を行う
        StartCoroutine(WaitForNextScene());
    }
}
