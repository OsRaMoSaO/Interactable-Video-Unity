using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set quicktime", story: "Set quicktime duration to [time] seconds on QuicktimeController [qc]", category: "Action", id: "6c72ed1b80451eb7aaae330a5f475ebc")]
public partial class SetQuicktimeAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Time;
    [SerializeReference] public BlackboardVariable<QuicktimeController> Qc;
    protected override Status OnStart()
    {
        Qc.Value.RunQuicktimeEvent(Time);
        return Status.Success;
    }
}

