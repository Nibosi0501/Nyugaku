using System.Collections;
using UnityEngine;

public class DeleteEmoji : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2.0f;  // フェードアウトの時間
    [SerializeField] private float targetHeight = 150.0f;  // 上昇距離

    private Material objectMaterial;
    private Vector3 startPosition;

    void Start()
    {
        // マテリアルの取得
        objectMaterial = GetComponent<Renderer>().material;
        startPosition = transform.position;

        StartCoroutine(MoveAndFadeOut());
    }

    private IEnumerator MoveAndFadeOut()
    {
        float elapsedTime = 0f;
        Color originalColor = objectMaterial.color;

        while (elapsedTime < fadeDuration)
        {
            // 指定した高さまで線形補間で上昇
            float newY = Mathf.Lerp(startPosition.y, startPosition.y + targetHeight, elapsedTime / fadeDuration);

            // 位置更新
            transform.position = new Vector3(startPosition.x, newY, startPosition.z);

            // 透明化処理
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            objectMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最終的に完全に透明にする
        objectMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        Destroy(gameObject); // オブジェクト削除
    }
}
