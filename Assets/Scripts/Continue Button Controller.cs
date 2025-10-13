using System;
using TMPro;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ContinueButtonController : MonoBehaviour
{
    public BehaviorGraphAgent continueButtonAgent;

    private TextMeshProUGUI buttonText;
    private Image btn_Image;

    private void Start()
    {
        buttonText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        btn_Image = GetComponent<Image>();
    }

    public void PressContinueButton()
    {
        HideButton();
        continueButtonAgent.SetVariableValue("Continue", true);
    }

    public void SetText(string text)
    {
        buttonText.text = text;
    }

    public void HideButton()
    {
        buttonText.gameObject.SetActive(false);
        btn_Image.enabled = false;
    }

    public void ShowButton()
    {
        buttonText.gameObject.SetActive(true);
        btn_Image.enabled = true;
    }
}
