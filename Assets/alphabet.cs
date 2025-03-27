using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class alphabet : MonoBehaviour
{
    [SerializeField] private int[] targetAlphabetsNumber;
    [SerializeField] private GameObject alphabetA;
    [SerializeField] private GameObject alphabetB;
    [SerializeField] private GameObject alphabetC;
    [SerializeField] private GameObject alphabetD;
    [SerializeField] private GameObject alphabetE;
    [SerializeField] private GameObject alphabetH;
    [SerializeField] private GameObject alphabetK;
    [SerializeField] private GameObject alphabetL;
    [SerializeField] private GameObject alphabetM;
    [SerializeField] private GameObject alphabetP;
    [SerializeField] private GameObject alphabetS;
    [SerializeField] private GameObject alphabetT;
    [SerializeField] private GameObject alphabetV;
    [SerializeField] private GameObject alphabetX;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private bool isOsaraiScene = false;

    private bool isSakuraScene = false;

    private Sakura sakura;

    void Start()
    {
        sakura = GetComponent<Sakura>();

        if (targetAlphabetsNumber.Length == 2)
        {
            Debug.Log("targetAlphabetsNumberの要素数は2です");
        }
        else if (targetAlphabetsNumber.Length == 0)
        {
            Debug.Log("targetAlphabetsNumberの要素数は0です");
            Debug.Log("桜シーンと認定します");
            //sakura.CreateSakura();
            isSakuraScene = true;

        }
        else
        {
            Debug.LogWarning("targetAlphabetsNumberの要素数が2ではありません");
            Debug.Log("おさらいシーンと認定します");
            isOsaraiScene = true;
        }

        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Aキーが押されたらアルファベットAを生成
        if (Input.GetKeyDown(KeyCode.A))
        {
            CreateAlphabet(9, 3);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateAlphabet(4, 3);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateAlphabet(3, 3);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CreateAlphabet(7, 3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateAlphabet(1, 3);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            CreateAlphabet(12, 3);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateAlphabet(13, 3);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            CreateAlphabet(10, 3);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            CreateAlphabet(5, 3);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            CreateAlphabet(6, 3);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CreateAlphabet(8, 3);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CreateAlphabet(11, 3);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            CreateAlphabet(2, 3);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateAlphabet(14, 3);
        }
    }

    private float GetRandomFloat(float min, float max)
    {
        float randomValue = Random.Range(min, max);
        return Mathf.Round(randomValue * 100f) / 100f; // 小数点2桁に丸める
    }

    public void CreateAlphabet(int alphabet, int count)
    {
        if (isOsaraiScene)
        {
            Debug.Log("おさらいシーンです");
            StartCoroutine(CreateAllAlphabetCoroutine(alphabet, count));
            return;
        }
        if (isSakuraScene)
        {
            Debug.Log("桜シーンです");
            sakura.CreateSakura(alphabet, count);
            return;
        }

        if (alphabet == targetAlphabetsNumber[0])
        {
            StartCoroutine(CreateAlphabetCoroutine(alphabet, count, 1));
        }
        else if (alphabet == targetAlphabetsNumber[1])
        {
            StartCoroutine(CreateAlphabetCoroutine(alphabet, count, 2));
        }
    }

    private IEnumerator CreateAllAlphabetCoroutine(int alphabet, int count)
    {
        float y = 5.0f;
        float z = -1.0f;
        for (int i = 0; i < count; i++)
        {
            GameObject obj = null;
            float rand = Random.value; // 0.0 ～ 1.0 の乱数を取得
            float randomX;
            if (rand > 0.5f)
            {
                randomX = GetRandomFloat(-14.5f, -1.5f);
            }
            else
            {
                randomX = GetRandomFloat(1.5f, 14.5f);
            }
            switch (alphabet)
            {
                case 9: obj = Instantiate(alphabetA, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 4: obj = Instantiate(alphabetB, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 3: obj = Instantiate(alphabetC, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 7: obj = Instantiate(alphabetD, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 1: obj = Instantiate(alphabetE, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 12: obj = Instantiate(alphabetH, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 13: obj = Instantiate(alphabetK, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 10: obj = Instantiate(alphabetL, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 5: obj = Instantiate(alphabetM, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 6: obj = Instantiate(alphabetP, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 8: obj = Instantiate(alphabetS, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 11: obj = Instantiate(alphabetT, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 2: obj = Instantiate(alphabetV, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 14: obj = Instantiate(alphabetX, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
            }
            //audioSource.Play();
            audioSource.PlayOneShot(audioClip);


            yield return new WaitForSeconds(GetRandomFloat(0.1f, 0.3f)); // 0.1〜0.5秒ランダムに待機
        }
    }

    private IEnumerator CreateAlphabetCoroutine(int alphabet, int count, int displayNumber)
    {
        float y = 5.0f;
        float z = -1.0f;
        for (int i = 0; i < count; i++)
        {
            GameObject obj = null;
            float randomX = GetRandomFloat(-14.5f, -1.5f);
            if (displayNumber == 1)
            {
                randomX = GetRandomFloat(-14.5f, -1.5f);
            }
            else if (displayNumber == 2)
            {
                randomX = GetRandomFloat(1.5f, 14.5f);
            }
            switch (alphabet)
            {
                case 9: obj = Instantiate(alphabetA, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 4: obj = Instantiate(alphabetB, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 3: obj = Instantiate(alphabetC, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 7: obj = Instantiate(alphabetD, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 1: obj = Instantiate(alphabetE, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 12: obj = Instantiate(alphabetH, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 13: obj = Instantiate(alphabetK, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 10: obj = Instantiate(alphabetL, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 5: obj = Instantiate(alphabetM, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 6: obj = Instantiate(alphabetP, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 8: obj = Instantiate(alphabetS, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 11: obj = Instantiate(alphabetT, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 2: obj = Instantiate(alphabetV, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
                case 14: obj = Instantiate(alphabetX, new Vector3(randomX, y, z), Quaternion.Euler(0, 180, 0)); break;
            }
            //audioSource.Play();
            audioSource.PlayOneShot(audioClip);


            yield return new WaitForSeconds(GetRandomFloat(0.1f, 0.3f)); // 0.1〜0.5秒ランダムに待機
        }
    }
}
