using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Video Finished")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Video Finished", message: "Wait until video is finished", category: "Events", id: "435fe605ceba429ce7cb768abc8e91d1")]
public sealed partial class VideoFinished : EventChannel { }

