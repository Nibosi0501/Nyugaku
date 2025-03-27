using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Emoji : MonoBehaviour
{
    // 絵文字のプレハブ(最大14種類)
    [SerializeField] private GameObject emoji1;
    [SerializeField] private GameObject emoji2;
    [SerializeField] private GameObject emoji3;
    [SerializeField] private GameObject emoji4;
    [SerializeField] private GameObject emoji5;
    [SerializeField] private GameObject emoji6;


    private Vector3[] Area = new Vector3[4];
    [SerializeField] private BoxCollider doubleArea;

    void Start()
    {
        Area[0] = new Vector3(-800, 225, -0.02f);
        Area[1] = new Vector3(800, 225, -0.02f);
        Area[2] = new Vector3(-800, -225, -0.02f);
        Area[3] = new Vector3(800, -225, -0.02f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CreateEmoji(1, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CreateEmoji(2, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CreateEmoji(3, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CreateEmoji(4, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CreateEmoji(5, 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CreateEmoji(6, 3);
        }
        // 最大で14種類まで作成できる
    }

    public void CreateEmoji(int Emoji, int count)
    {
        Debug.Log("CreateEmoji");
        StartCoroutine(CreateEmojiCoroutine(Emoji, count));
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(Area[0].x, Area[1].x);
        float y = Random.Range(Area[2].y, Area[0].y);
        float z = -0.02f;
        return new Vector3(x, y, z);
    }

    private IEnumerator CreateEmojiCoroutine(int Emoji, int count)
    {
        Vector3 randomPosition = new Vector3(0, 0, -0.02f);

        GameObject emoji = null;
        for (int i = 0; i < count; i++)
        {
            randomPosition = GetRandomPosition();

            switch (Emoji)
            {
                case 1:
                    emoji = emoji1;
                    break;
                case 2:
                    emoji = emoji2;
                    break;
                case 3:
                    emoji = emoji3;
                    break;
                case 4:
                    emoji = emoji4;
                    break;
                case 5:
                    emoji = emoji5;
                    break;
                case 6:
                    emoji = emoji6;
                    break;
            }
            Instantiate(emoji, randomPosition, Quaternion.Euler(90, 0, -180));

            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        }
    }
}
