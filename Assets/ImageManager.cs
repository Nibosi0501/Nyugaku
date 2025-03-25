using System;
using System.Collections;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
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

    private void Start()
    {
        Gakka.transform.position = GakkaStartPosition;
        Senko1.transform.position = SenkoLeftStartPosition;
        Senko2.transform.position = SenkoRightStartPosition;

        StartSlideIn(Gakka, GakkaStartPosition, GakkaEndPosition, slideDuration, EaseInOutQuad);
        StartSlideIn(Senko1, SenkoLeftStartPosition, SenkoLeftEndPosition, slideDuration, EaseInOutQuad);
        StartSlideIn(Senko2, SenkoRightStartPosition, SenkoRightEndPosition, slideDuration, EaseInOutQuad);
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
    // 加速して減速するイージング
    private float EaseInOutQuad(float t) => t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
}
