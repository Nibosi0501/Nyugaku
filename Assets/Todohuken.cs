using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Todohuken : MonoBehaviour
{
    [SerializeField] private Material todohukenMaterial1;
    [SerializeField] private Material todohukenMaterial2;
    [SerializeField] private Material todohukenMaterial3;
    [SerializeField] private Material todohukenMaterial4;
    [SerializeField] private Material todohukenMaterial5;
    [SerializeField] private Material todohukenMaterial6;
    [SerializeField] private Material todohukenMaterial7;
    [SerializeField] private Material todohukenMaterial8;
    [SerializeField] private Material todohukenMaterial9;

    private MeshRenderer meshRenderer;

    [SerializeField] private ChangeScene changeScene;

    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial(int todohukenNumber)
    {
        switch (todohukenNumber)
        {
            case 0:
                meshRenderer.material = todohukenMaterial1;
                break;
            case 1:
                meshRenderer.material = todohukenMaterial2;
                break;
            case 2:
                meshRenderer.material = todohukenMaterial3;
                break;
            case 3:
                meshRenderer.material = todohukenMaterial4;
                break;
            case 4:
                meshRenderer.material = todohukenMaterial5;
                break;
            case 5:
                meshRenderer.material = todohukenMaterial6;
                break;
            case 6:
                meshRenderer.material = todohukenMaterial7;
                break;
            case 7:
                meshRenderer.material = todohukenMaterial8;
                break;
            case 8:
                meshRenderer.material = todohukenMaterial9;
                break;
            case 9:
                //changeScene.NextScene();
                //gameObject.SetActive(false);
                gameObject.transform.position = new Vector3(0, 0, 10);
                break;
            case 10:
                //changeScene.NextScene();
                // カメラ２つの現在のy座標をを引数で指定した値に徐々に変化させる関数を呼び出す
                StartCoroutine(MoveCameras(-600f, 3.0f));
                break;
            default:
                Debug.LogWarning("todohukenNumberが不正です");
                break;
        }
    }

    private IEnumerator MoveCameras(float targetY, float duration)
    {
        float elapsedTime = 0f;

        Vector3 startPos1 = camera1.transform.position;
        Vector3 startPos2 = camera2.transform.position;

        Vector3 targetPos1 = new Vector3(startPos1.x, targetY, startPos1.z);
        Vector3 targetPos2 = new Vector3(startPos2.x, targetY, startPos2.z);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            camera1.transform.position = Vector3.Lerp(startPos1, targetPos1, t);
            camera2.transform.position = Vector3.Lerp(startPos2, targetPos2, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最後にピッタリ目標値に合わせる
        camera1.transform.position = targetPos1;
        camera2.transform.position = targetPos2;
    }
}
