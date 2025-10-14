using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.InputSystem.UI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Multichoice", story: "Set textA to [textA_text] | textB to [textB_text] | textC to [textC_text] | textD to [textD_text] in multichoice controller [mcc]", category: "Action", id: "b78734cc93d20b52ca20159a537c5a4c")]
public partial class SetMultichoiceAction : Action
{
    [SerializeReference] public BlackboardVariable<string> TextA_text;
    [SerializeReference] public BlackboardVariable<string> TextB_text;
    [SerializeReference] public BlackboardVariable<string> TextC_text;
    [SerializeReference] public BlackboardVariable<string> TextD_text;
    [SerializeReference] public BlackboardVariable<MultichoiceButtonsController> Mcc;
    protected override Status OnStart()
    {
        Mcc.Value.SetTexts(TextA_text, TextB_text, TextC_text, TextD_text);
        return Status.Success;
    }

}

