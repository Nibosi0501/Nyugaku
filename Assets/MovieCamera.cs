using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCamera : MonoBehaviour
{
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;
    [SerializeField] private Canvas canvas;

    private float movieWidth = 1920f;
    private float cameraDistance = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        // 

    }

    Vector2 GetCameraViewXBounds(Camera cam, float dist)
    {
        float fov = cam.fieldOfView; // 縦方向の視野角
        float aspect = cam.aspect; // アスペクト比（幅 / 高さ）

        // 縦方向の半分の高さ
        float height = 2f * dist * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);

        // 横幅の半分
        float width = height * aspect;

        return new Vector2(-width / 2f, width / 2f);
    }

    Vector2 GetCameraViewYBounds(Camera cam, float dist)
    {
        float fov = cam.fieldOfView; // 縦方向の視野角

        // 縦方向の半分の高さ
        float height = 2f * dist * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);

        return new Vector2(-height / 2f, height / 2f);
    }
}
