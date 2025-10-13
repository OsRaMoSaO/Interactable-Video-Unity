using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.UI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Continue Button", story: "Set continue button text to [continueText] or [isHidden] hide", category: "Action", id: "80c4894b12c90dddc07b25878af19fd3")]
public partial class SetContinueButtonAction : Action
{
    [SerializeReference] public BlackboardVariable<ContinueButtonController> continueButton;
    
    [SerializeReference] public BlackboardVariable<string> ContinueText;
    [SerializeReference] public BlackboardVariable<bool> IsHidden;

    protected override Status OnStart()
    {
        if (continueButton.Value == null)
        {
            throw new Exception(
                "HUSK Å SETTE CONTINUE BUTTON TIL MAIN CONTINUE BUTTON I BEHAVIOR GRAPHEN VIA INSPECTOREN, spørr om hjelp");
        }
        
        if (IsHidden) 
        {
            continueButton.Value.HideButton();
            return Status.Success;
        }
        
        continueButton.Value.ShowButton();
        continueButton.Value.SetText(ContinueText);
        
        return Status.Success;
    }
}

