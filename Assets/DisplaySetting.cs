using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySetting : MonoBehaviour
{
    void Awake()
    {
        if (!Application.isEditor && !PlayerPrefs.HasKey("AppLaunched"))
        {
            Debug.Log("ビルド版アプリが初回起動しました！");
            RunOnceOnFirstLaunch();

            // 初回起動済みフラグをセット
            PlayerPrefs.SetInt("AppLaunched", 1);
            PlayerPrefs.Save();
        }
        /*
        Debug.Log("displays connected: " + Display.displays.Length);
        if (Display.displays.Length > 1) // 2つ以上のディスプレイがあるかチェック
        {
            Debug.Log("Display 1 is enabled");
            Display.displays[1].Activate(); // 2番目のディスプレイを有効化
            // 2番目のディスプレイの解像度を変更
            Display.displays[1].SetRenderingResolution(1920, 1080);
        }
        */
    }

    void RunOnceOnFirstLaunch()
    {
        // 初回起動時に1回だけ実行する処理
        Debug.Log("ビルド版の初回処理を実行");
        Debug.Log("displays connected: " + Display.displays.Length);
        if (Display.displays.Length > 1) // 2つ以上のディスプレイがあるかチェック
        {
            Debug.Log("Display 1 is enabled");
            Display.displays[1].Activate(); // 2番目のディスプレイを有効化
            // 2番目のディスプレイの解像度を変更
            Display.displays[1].SetRenderingResolution(1920, 1080);
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log("アプリが終了しました。初回起動フラグをリセット。");
        PlayerPrefs.DeleteKey("AppLaunched");  // 初回起動フラグを削除
        PlayerPrefs.Save();
    }
}
