using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Play video", story: "Play video [videoClipHolder] or from url [url] from [startTime] until [endTime] on controller: [videoPlayerController]", category: "Action", id: "4f98dde84098da3ed51c4c944818f816")]
public partial class PlayVideoAction : Action
{
    [SerializeReference] public BlackboardVariable<VideoClipHolder> VideoClipHolder;
    [SerializeReference] public BlackboardVariable<string> Url;
    [SerializeReference] public BlackboardVariable<double> StartTime;
    [SerializeReference] public BlackboardVariable<double> EndTime;
    [SerializeReference] public BlackboardVariable<VideoPlayerController> VideoPlayerController;
    protected override Status OnStart()
    {
        if (VideoClipHolder.Value == null)
        {
            VideoPlayerController.Value.RunExecutionCorutine(StartTime.Value, EndTime.Value, Url.Value);
            return Status.Success;
        }
        
        VideoPlayerController.Value.RunExecutionCorutine(StartTime.Value, EndTime.Value, VideoClipHolder.Value.VideoClip);
        
        
        return Status.Success;
    }

}

