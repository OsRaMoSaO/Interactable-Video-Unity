using System;
using TMPro;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Title Text", story: "Set text box [txt_obj] to [txt] with color [color]", category: "Action", id: "feebc3e670e688a564f1d757c4cc8b1e")]
public partial class SetTitleTextAction : Action
{
    [SerializeReference] public BlackboardVariable<TextMeshProUGUI> Txt_obj;
    [SerializeReference] public BlackboardVariable<string> Txt;
    [SerializeReference] public BlackboardVariable<Color> Color;
    protected override Status OnStart()
    {
        Txt_obj.Value.text = Txt.Value;
        Txt_obj.Value.color = new Color(Color.Value.r, Color.Value.g, Color.Value.b, 255);
        return Status.Success;
    }

}

