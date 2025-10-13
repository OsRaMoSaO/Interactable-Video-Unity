using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/Continue Button Pressed")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "Continue Button Pressed", message: "Continue Button Pressed", category: "Events", id: "6e0cb4d56c8b4792221b10dc4c933377")]
public sealed partial class ContinueButtonPressed : EventChannel { }

