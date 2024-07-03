using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    public Texture idleTexture;
    public Texture playTexture;

    public VideoPlayer idlePlayer;
    public VideoPlayer playPlayer;

    private RawImage panel;

    private void Start()
    {
        panel = GetComponent<RawImage>();
        panel.texture = idleTexture;

        if (playPlayer != null)
        {
            playPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("VideoPlayer n�o est� atribu�do.");
        }

        StartIdleVideo();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!playPlayer.isPlaying)
            {
                StartPlayVideo();
            }
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartIdleVideo();
    }

    void StartIdleVideo()
    {
        idlePlayer.gameObject.SetActive(true);
        idlePlayer.Stop();
        idlePlayer.Play();
        panel.texture = idleTexture;
        playPlayer.gameObject.SetActive(false);
    }

    void StartPlayVideo()
    {
        playPlayer.gameObject.SetActive(true);
        playPlayer.Stop();
        playPlayer.Play();
        panel.texture = playTexture;
        idlePlayer.gameObject.SetActive(false);
    }
}
