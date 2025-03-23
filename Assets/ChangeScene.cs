using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void NextScene()
    {

        Scene scene = SceneManager.GetActiveScene();

        int nextBuildIndex = scene.buildIndex + 1;

        if (nextBuildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextBuildIndex = 0;
        }

        SceneManager.LoadScene(nextBuildIndex);
    }

    // スペースキーが押されたら次のシーンに遷移する
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextScene();
        }
    }
}