using UnityEngine;
using System.Collections;

public class SenkoZunda : MonoBehaviour
{
    [SerializeField] private AudioSource a; // AudioSource型の変数aを宣言
    [SerializeField] private AudioClip b; // AudioClip型の変数bを宣言

    private ChangeScene changeScene;

    void Start()
    {
        // 音声を再生する
        a.PlayOneShot(b);

        // コルーチンを開始して、音声が終了するのを待つ
        StartCoroutine(WaitForSoundToFinish());

        changeScene = GetComponent<ChangeScene>();
    }

    // 音声が終了するのを待つコルーチン
    IEnumerator WaitForSoundToFinish()
    {
        // 音声が再生されている間は待機
        while (a.isPlaying)
        {
            yield return null; // 次のフレームまで待機
        }

        // 音声の再生が終了したら指定した関数を呼び出す
        OnSoundFinished();
    }

    // 音声が終了したときに呼ばれる関数
    void OnSoundFinished()
    {
        Debug.Log("音声が終了しました！");
        // ここで任意の処理を行う
        changeScene.NextScene();
    }
}
