using System;
using System.Collections;
using System.IO;
using System.Resources;
using TMPro;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(RawImage))]
public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private RawImage rawImage;

    [SerializeField]
    private bool displayTimestamp;

    [SerializeField] 
    private BehaviorGraphAgent videoPlayerAgent;
    
    [SerializeField] 
    private LoadingController loadingText;

    private bool frameReady = false;

    private bool gotInterrupted = false;

    private string previousVideoClip = string.Empty;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        rawImage = GetComponent<RawImage>();
        
        videoPlayer.sendFrameReadyEvents = true;
        videoPlayer.frameReady += FrameReady;
    }

    void FrameReady(VideoPlayer source, long frameIdx)
    {
        frameReady = true;
        videoPlayer.sendFrameReadyEvents = false;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus && videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            gotInterrupted = true;
        }
        else if (gotInterrupted)
        {
            videoPlayer.Play();
            gotInterrupted = false;
        }
    }

    void SetVideoVisibility(bool visibliity)
    {
        rawImage.enabled = visibliity;
        loadingText.EndLoadingText();
    }

    public void RunExecutionCorutine(double startTime, double endTime, string videoClip)
    {
        StartCoroutine(ExecuteVideo(startTime, endTime, videoClip));
    }
    private IEnumerator ExecuteVideo(double startTime, double endTime, string videoClip)
    {
        videoPlayer.url = Path.Combine(Application.streamingAssetsPath, videoClip);
        loadingText.StartLoadingText();
        
        if (startTime < 0)
            throw new Exception($"Start tida kan ikkje vere mindre enn null, angåande {videoClip}");
        if (Math.Abs(startTime - endTime) < 0.1f)
            throw new Exception($"Start og slutt tiden kan ikkje vere like, angåande {videoClip}, om du vil at heile videoen spelar sett endtime til -1");
        
        videoPlayer.sendFrameReadyEvents = true;
        
        videoPlayer.time = startTime;
        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        yield return new WaitUntil(() => videoPlayer.canSetTime);

        if (startTime > videoPlayer.length)
            throw new Exception($"Start tiden på video {videoClip} er utanfor speletida til videoen");
        if (endTime > videoPlayer.length)
            throw new Exception($"Ende tiden på video {videoClip} er utanfor speletida til videoen, om du vil at heile videoen spelar sett endTime til -1");
        
        
        if (endTime >= 0) StartCoroutine(WaitForVideoEnd(startTime, endTime));
        else
        {
            endTime = videoPlayer.length;
            StartCoroutine(WaitForVideoEnd(startTime, endTime));
        }
    }

    private IEnumerator PlayVideo()
    {
        videoPlayer.Play();
        yield return new WaitUntil(() => frameReady);
        yield return new WaitUntil(() => videoPlayer.isPlaying);
        
        SetVideoVisibility(true);
    }
    IEnumerator WaitForVideoEnd(double startTime,double endTime)
    {
        StartCoroutine(PlayVideo());
        while (videoPlayer.time < endTime)
        {
            if (displayTimestamp) Debug.Log($"Video er på tid {videoPlayer.time}s");
            yield return new WaitForEndOfFrame();
        }
        
        videoPlayer.Stop();
        videoPlayerAgent.SetVariableValue("FinishedPlaying", true);
    }

}
