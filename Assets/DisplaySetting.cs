using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySetting : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        if (Display.displays.Length > 1) // 2つ以上のディスプレイがあるかチェック
        {
            Debug.Log("Display 1 is enabled");
            Display.displays[1].Activate(); // 2番目のディスプレイを有効化
            // 2番目のディスプレイの解像度を変更
            Display.displays[1].SetRenderingResolution(1920, 1080);
        }
    }
}
