using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class EndMovie : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    private ChangeScene changeScene;

    void Start()
    {
        changeScene = GetComponent<ChangeScene>();

        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        changeScene.NextScene();
    }
}
