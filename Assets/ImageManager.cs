using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    // 学科紹介写真から専攻記号（アルファベット）に切り替える
    [SerializeField] private GameObject SenkoAlphabetLeft;
    [SerializeField] private GameObject SenkoAlphabetRight;
    private bool isSenkoAlphabet = false;
    // 専攻紹介写真を表示する
    [SerializeField] private GameObject SenkoPhotoLeft;
    [SerializeField] private GameObject SenkoPhotoRight;
    private Vector3 SenkoPhotoStartScale = new Vector3(0.0f, 1.0f, 0.0f);
    [SerializeField] private Vector3 SenkoPhotoEndScale = new Vector3(0.6f, 1.0f, 0.6f);


    // 学科・専攻の画像をスライドインさせる
    [SerializeField] private Vector3 GakkaStartPosition;
    [SerializeField] private Vector3 GakkaEndPosition;
    [SerializeField] private Vector3 SenkoLeftStartPosition;
    [SerializeField] private Vector3 SenkoLeftEndPosition;
    [SerializeField] private Vector3 SenkoRightStartPosition;
    [SerializeField] private Vector3 SenkoRightEndPosition;
    [SerializeField] private GameObject Gakka;
    [SerializeField] private GameObject Senko1;
    [SerializeField] private GameObject Senko2;

    [SerializeField] private float slideDuration = 1.0f;

    void Start()
    {
        SenkoPhotoLeft.transform.localScale = SenkoPhotoStartScale;
        SenkoPhotoRight.transform.localScale = SenkoPhotoStartScale;

        Gakka.transform.position = GakkaStartPosition;
        Senko1.transform.position = SenkoLeftStartPosition;
        Senko2.transform.position = SenkoRightStartPosition;

        StartZoomIn(SenkoPhotoLeft, SenkoPhotoStartScale, SenkoPhotoEndScale, 1.0f, EaseInOutQuad);
        StartZoomIn(SenkoPhotoRight, SenkoPhotoStartScale, SenkoPhotoEndScale, 1.0f, EaseInOutQuad);

        StartSlideIn(Gakka, GakkaStartPosition, GakkaEndPosition, slideDuration, EaseInOutQuad);
        StartSlideIn(Senko1, SenkoLeftStartPosition, SenkoLeftEndPosition, slideDuration, EaseInOutQuad);
        StartSlideIn(Senko2, SenkoRightStartPosition, SenkoRightEndPosition, slideDuration, EaseInOutQuad);
    }

    void Update()
    {
        // 専攻記号キーが押されたら専攻紹介写真から専攻記号に切り替える
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.V) ||
            Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.B) ||
            Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.P) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.L) ||
            Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.H) ||
            Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.K))
        {
            //isSenkoAlphabet = ChangeSenkoAlphabet();
        }
    }

    public bool ChangeSenkoAlphabet()
    {
        if (!isSenkoAlphabet)
        {
            SenkoPhotoLeft.SetActive(false);
            SenkoPhotoRight.SetActive(false);
            SenkoAlphabetLeft.SetActive(true);
            SenkoAlphabetRight.SetActive(true);
        }
        return isSenkoAlphabet;
    }

    private void StartZoomIn(GameObject obj, Vector3 startScale, Vector3 endScale, float duration, Func<float, float> easingFunction)
    {
        StartCoroutine(ZoomIn(obj, startScale, endScale, duration, easingFunction));
    }

    private IEnumerator ZoomIn(GameObject obj, Vector3 startScale, Vector3 endScale, float duration, Func<float, float> easingFunction)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            obj.transform.localScale = Vector3.Lerp(startScale, endScale, easingFunction(t));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.localScale = endScale;
    }

    public void StartSlideIn(GameObject obj, Vector3 startPos, Vector3 endPos, float duration, Func<float, float> easingFunction)
    {
        StartCoroutine(SlideIn(obj, startPos, endPos, duration, easingFunction));
    }

    private IEnumerator SlideIn(GameObject obj, Vector3 startPos, Vector3 endPos, float duration, Func<float, float> easingFunction)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            obj.transform.position = Vector3.Lerp(startPos, endPos, easingFunction(t));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = endPos;
    }

    // === イージング関数 ===
    // 線形補間 (デフォルト)
    private float EaseLinear(float t) => t;

    // 加速して減速するイージング
    private float EaseInOutQuad(float t) => t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
}
