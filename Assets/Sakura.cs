using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sakura : MonoBehaviour
{
    [SerializeField] private GameObject todouhuken;
    private Todohuken todohukenScript;

    // 桜プレハブ
    [SerializeField] private GameObject sakuraPrefab;

    // 絵文字プレハブ
    [SerializeField] private GameObject[] emojiPrefab;

    // モードフラグ
    private int mode = 0;

    // 北海道
    [SerializeField] private GameObject Hokkaido;
    private Vector3[] HokkaidoArea;

    // 東北
    [SerializeField] private GameObject Tohoku1;
    [SerializeField] private GameObject Tohoku2;
    private Vector3[] Tohoku1Area;
    private Vector3[] Tohoku2Area;

    // 関東
    [SerializeField] private GameObject Kanto1;
    [SerializeField] private GameObject Kanto2;
    [SerializeField] private GameObject Kanto3;
    [SerializeField] private GameObject Kanto4;
    [SerializeField] private GameObject Kanto5;
    private Vector3[] Kanto1Area;
    private Vector3[] Kanto2Area;
    private Vector3[] Kanto3Area;
    private Vector3[] Kanto4Area;
    private Vector3[] Kanto5Area;

    // 北陸・甲信越
    [SerializeField] private GameObject HokuKou1;
    [SerializeField] private GameObject HokuKou2;
    [SerializeField] private GameObject HokuKou3;
    [SerializeField] private GameObject HokuKou4;
    [SerializeField] private GameObject HokuKou5;
    private Vector3[] HokuKou1Area;
    private Vector3[] HokuKou2Area;
    private Vector3[] HokuKou3Area;
    private Vector3[] HokuKou4Area;
    private Vector3[] HokuKou5Area;

    // 東海
    [SerializeField] private GameObject Toukai1;
    [SerializeField] private GameObject Toukai2;
    [SerializeField] private GameObject Toukai3;
    private Vector3[] Toukai1Area;
    private Vector3[] Toukai2Area;
    private Vector3[] Toukai3Area;

    // 関西
    [SerializeField] private GameObject Kansai1;
    [SerializeField] private GameObject Kansai2;
    [SerializeField] private GameObject Kansai3;
    private Vector3[] Kansai1Area;
    private Vector3[] Kansai2Area;
    private Vector3[] Kansai3Area;

    // 中国
    [SerializeField] private GameObject Chugoku1;
    private Vector3[] Chugoku1Area;

    // 四国
    [SerializeField] private GameObject Shikoku1;
    private Vector3[] Shikoku1Area;

    // 九州
    [SerializeField] private GameObject Kyushu1;
    [SerializeField] private GameObject Kyushu2;
    [SerializeField] private GameObject Kyushu3;
    private Vector3[] Kyushu1Area;
    private Vector3[] Kyushu2Area;
    private Vector3[] Kyushu3Area;

    // 絵文字エリア
    [SerializeField] private GameObject AllEmoji;
    private Vector3[] AllEmojiArea;

    // 桜が咲く音
    //private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;


    //List<Vector3[]> areas = new List<Vector3[]>();
    // ずんだもん
    [SerializeField] private AudioSource ZundaAudioSource;
    [SerializeField] private AudioClip[] zundaClips;

    private bool isCreateSakuraStart = false;

    void Start()
    {
        // 北海道
        HokkaidoArea = CalculatArea(Hokkaido);
        //Debug.Log("HokkaidoArea: " + HokkaidoArea[0] + ", " + HokkaidoArea[1] + ", " + HokkaidoArea[2] + ", " + HokkaidoArea[3]);


        // 東北
        Tohoku1Area = CalculatArea(Tohoku1);
        Tohoku2Area = CalculatArea(Tohoku2);

        // 関東
        Kanto1Area = CalculatArea(Kanto1);
        Kanto2Area = CalculatArea(Kanto2);
        Kanto3Area = CalculatArea(Kanto3);
        Kanto4Area = CalculatArea(Kanto4);
        Kanto5Area = CalculatArea(Kanto5);

        // 北陸・甲信越
        HokuKou1Area = CalculatArea(HokuKou1);
        HokuKou2Area = CalculatArea(HokuKou2);
        HokuKou3Area = CalculatArea(HokuKou3);
        HokuKou4Area = CalculatArea(HokuKou4);
        HokuKou5Area = CalculatArea(HokuKou5);

        // 東海
        Toukai1Area = CalculatArea(Toukai1);
        Toukai2Area = CalculatArea(Toukai2);
        Toukai3Area = CalculatArea(Toukai3);

        // 関西
        Kansai1Area = CalculatArea(Kansai1);
        Kansai2Area = CalculatArea(Kansai2);
        Kansai3Area = CalculatArea(Kansai3);

        // 中国
        Chugoku1Area = CalculatArea(Chugoku1);

        // 四国
        Shikoku1Area = CalculatArea(Shikoku1);

        // 九州
        Kyushu1Area = CalculatArea(Kyushu1);
        Kyushu2Area = CalculatArea(Kyushu2);
        Kyushu3Area = CalculatArea(Kyushu3);

        // 絵文字エリア
        AllEmojiArea = CalculatArea(AllEmoji);

        StartCoroutine(ChangeMode());
        todohukenScript = todouhuken.GetComponent<Todohuken>();

        //audioSource = GetComponent<AudioSource>();

    }

    public static Vector3[] GetBoxCollideVertices(BoxCollider Col)
    {
        Transform trs = Col.transform;
        Vector3 sc = trs.lossyScale;

        // BoxCollider の size を考慮したスケール
        sc.x *= Col.size.x;
        sc.y *= Col.size.y;
        sc.z *= Col.size.z;
        sc *= 0.5f;

        // BoxCollider の中心をワールド座標に変換
        Vector3 cp = trs.TransformPoint(Col.center);

        // ワールド座標系での軸方向ベクトル
        Vector3 vx = trs.right * sc.x;
        Vector3 vy = trs.up * sc.y;
        Vector3 vz = trs.forward * sc.z;

        // 8つの頂点の計算（修正後）
        Vector3[] vertices = new Vector3[8];

        // 上面
        vertices[0] = cp + vx + vy + vz; // 右上前
        vertices[1] = cp - vx + vy + vz; // 左上前
        vertices[2] = cp - vx + vy - vz; // 左上後
        vertices[3] = cp + vx + vy - vz; // 右上後

        // 下面
        vertices[4] = cp + vx - vy + vz; // 右下前
        vertices[5] = cp - vx - vy + vz; // 左下前
        vertices[6] = cp - vx - vy - vz; // 左下後
        vertices[7] = cp + vx - vy - vz; // 右下後

        return vertices;
    }


    private Vector3[] CalculatArea(GameObject area)
    {
        //Vector3 CenterPosition = area.transform.position;
        //Vector3 Size = area.transform.localScale;

        BoxCollider boxCollider = area.GetComponent<BoxCollider>();
        Vector3[] Area = GetBoxCollideVertices(boxCollider);

        /*

        // Plane のサイズ（UnityのPlaneはデフォルトで10x10）
        float halfWidth = 5 * scale.x;
        float halfHeight = 5 * scale.z;

        // ローカル座標系での四隅の座標（スケール考慮）
        Vector3[] localCorners = new Vector3[]
        {
            new Vector3(-halfWidth, 0, -halfHeight), // 左下
            new Vector3(-halfWidth, 0,  halfHeight), // 左上
            new Vector3( halfWidth, 0, -halfHeight), // 右下
            new Vector3( halfWidth, 0,  halfHeight)  // 右上
        };

        Vector3[] Area = new Vector3[4];
        // 四角形の4つの頂点の座標を計算(横がx軸、縦がy軸, z軸は-0.02fで固定)
        for (int i = 0; i < 4; i++)
        {
            Area[i] = areaTransform.TransformPoint(localCorners[i]);
        }
        */

        return Area;
    }

    private Vector3 GetRandomPosition(List<Vector3[]> areas)
    {
        // 0 ~ areas.Length の範囲で整数をランダムに取得
        int randomIndex = Random.Range(0, areas.Count);

        Vector3[] targetArea = areas[randomIndex];
        // 四角形の4つの頂点の座標配列の targetArea[0] ～ targetArea[3] の範囲でランダムなx, y座標を取得
        float randomX = Random.Range(targetArea[0].x, targetArea[1].x);
        float randomY = Random.Range(targetArea[0].y, targetArea[2].y);
        float Z = -0.02f;

        return new Vector3(randomX, randomY, Z);
    }

    public void CreateSakura(int alphabet, int count)
    {
        if (isCreateSakuraStart == false)
        {
            Debug.Log("最初の音声が終わるまでは待機します");
            return;
        }
        //Debug.Log("桜を生成します");

        List<Vector3[]> areas = new List<Vector3[]>();
        Vector3 randomPosition = new Vector3(0, 0, -0.02f);
        GameObject targetObject = sakuraPrefab;
        for (int i = 0; i < count; i++)
        {
            switch (mode)
            {
                case 0:
                    areas.Add(HokkaidoArea);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 1:
                    //areas.Add(Tohoku1Area);
                    //areas.Add(Tohoku2Area);
                    areas.Add(Kyushu1Area);
                    areas.Add(Kyushu2Area);
                    areas.Add(Kyushu3Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 2:
                    //areas.Add(Kanto1Area);
                    //areas.Add(Kanto2Area);
                    //areas.Add(Kanto3Area);
                    //areas.Add(Kanto4Area);
                    //areas.Add(Kanto5Area);
                    areas.Add(Tohoku1Area);
                    areas.Add(Tohoku2Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 3:
                    //areas.Add(HokuKou1Area);
                    //areas.Add(HokuKou2Area);
                    //areas.Add(HokuKou3Area);
                    //areas.Add(HokuKou4Area);
                    //areas.Add(HokuKou5Area);
                    areas.Add(Shikoku1Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 4:
                    areas.Add(Kanto1Area);
                    areas.Add(Kanto2Area);
                    areas.Add(Kanto3Area);
                    areas.Add(Kanto4Area);
                    areas.Add(Kanto5Area);
                    //areas.Add(Toukai1Area);
                    //areas.Add(Toukai2Area);
                    //areas.Add(Toukai3Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 5:
                    //areas.Add(Kansai1Area);
                    //areas.Add(Kansai2Area);
                    //areas.Add(Kansai3Area);
                    areas.Add(Chugoku1Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 6:
                    //areas.Add(Chugoku1Area);
                    areas.Add(HokuKou1Area);
                    areas.Add(HokuKou2Area);
                    areas.Add(HokuKou3Area);
                    areas.Add(HokuKou4Area);
                    areas.Add(HokuKou5Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 7:
                    //areas.Add(Shikoku1Area);
                    areas.Add(Kansai1Area);
                    areas.Add(Kansai2Area);
                    areas.Add(Kansai3Area);
                    randomPosition = GetRandomPosition(areas);

                    break;
                case 8:
                    //areas.Add(Kyushu1Area);
                    //areas.Add(Kyushu2Area);
                    //areas.Add(Kyushu3Area);
                    areas.Add(Toukai1Area);
                    areas.Add(Toukai2Area);
                    areas.Add(Toukai3Area);
                    randomPosition = GetRandomPosition(areas);
                    break;
                case 9:
                    areas.Add(AllEmojiArea);
                    randomPosition = GetRandomPosition(areas);
                    // alpahabet に応じた絵文字プレハブをtargetObjectに代入
                    switch (alphabet)
                    {
                        case 1:
                            targetObject = emojiPrefab[0];
                            break;
                        case 2:
                            targetObject = emojiPrefab[1];
                            break;
                        case 3:
                            targetObject = emojiPrefab[2];
                            break;
                        case 4:
                            targetObject = emojiPrefab[3];
                            break;
                        case 5:
                            targetObject = emojiPrefab[4];
                            break;
                        case 6:
                            targetObject = emojiPrefab[5];
                            break;
                    }
                    break;
            }
            Instantiate(targetObject, randomPosition, Quaternion.Euler(90, 90, -90));
            // audioSource.Play();
            audioSource.PlayOneShot(audioClip);
        }
    }

    void Update()
    {
        // 1キーが押されたらモードを変更
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = 0;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mode = 1;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mode = 2;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mode = 3;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mode = 4;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            mode = 5;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            mode = 6;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            mode = 7;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            mode = 8;
            todohukenScript.ChangeMaterial(mode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            mode = 9;
            todohukenScript.ChangeMaterial(mode);
        }
    }

    private IEnumerator ChangeMode()
    {
        ZundaAudioSource.PlayOneShot(zundaClips[mode]);
        while (ZundaAudioSource.isPlaying)
        {
            yield return null;
        }
        isCreateSakuraStart = true;
        yield return new WaitForSeconds(20.0f);
        mode++;
        Debug.Log("モードを変更します:" + mode);
        todohukenScript.ChangeMaterial(mode);
        if (mode >= 9)
        {
            ZundaAudioSource.PlayOneShot(zundaClips[10]);
            while (ZundaAudioSource.isPlaying)
            {
                yield return null;
            }
            AllEmozi();
            ZundaAudioSource.PlayOneShot(zundaClips[mode]);
            while (ZundaAudioSource.isPlaying)
            {
                yield return null;
            }
            yield return new WaitForSeconds(20.0f);
            mode++;
            todohukenScript.ChangeMaterial(mode);
            yield break;
        }
        StartCoroutine(ChangeMode());
    }

    private void AllEmozi()
    {
        Debug.Log("全エリアに絵文字を表示します。");
    }



    public int GetMode()
    {
        return mode;
    }
}
