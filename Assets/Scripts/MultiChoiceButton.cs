using System;
using TMPro;
using Unity.Behavior;
using UnityEngine;

public class MultiChoiceButton : MonoBehaviour
{
    [SerializeField]
    private BehaviorGraphAgent blackboard;

    private MultichoiceButtonsController mcc;

    [SerializeField]
    private int index;

    private void Start()
    {
        mcc = transform.parent.GetComponent<MultichoiceButtonsController>();
    }

    public void ButtonPressed()
    {
        if (index == 0) throw new Exception("Set index to something other than 0 in choice button");
        blackboard.SetVariableValue("MultiChoiceValue", index);
        mcc.HideAllButtons();
    }
}
