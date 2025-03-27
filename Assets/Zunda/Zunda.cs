using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zunda : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;

    private int isZundaNumber = 1;

    private ChangeScene changeScene;

    [SerializeField] private GameObject ImageManager;
    private ImageManager imageManager;

    void Start()
    {
        audioSource.PlayOneShot(clip1);
        StartCoroutine(WaitForSoundToFinish());

        changeScene = GetComponent<ChangeScene>();

        imageManager = ImageManager.GetComponent<ImageManager>();
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
        /*
        Debug.Log("音声が終了しました！");
        // ここで任意の処理を行う
        audioSource.PlayOneShot(clip2);
        if (isZundaNumber == 2)
        {
            StartCoroutine(WaitForNextScene());
            return;
        }
        imageManager.ChangeSenkoAlphabet();
        isZundaNumber = 2;
        StartCoroutine(WaitForSoundToFinish());
        */
        if (isZundaNumber == 2)
        {
            StartCoroutine(WaitForNextScene());
        }
        else
        {
            isZundaNumber = 2;
            imageManager.ChangeSenkoAlphabet();
            audioSource.PlayOneShot(clip2);
            StartCoroutine(WaitForSoundToFinish());
        }
    }
}
