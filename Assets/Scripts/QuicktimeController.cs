using System;
using System.Collections;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.UI;

public class QuicktimeController : MonoBehaviour
{
    private bool clicked;
    
    private Image loadingBar;
    private Image clickIcon;
    private Image bg;

    [SerializeField]
    private BehaviorGraphAgent mainAgent;

    private void Start()
    {
        bg = GetComponent<Image>();
        clickIcon = transform.GetChild(0).gameObject.GetComponent<Image>();
        loadingBar = transform.GetChild(1).gameObject.GetComponent<Image>();
    }

    public void PressedButton()
    {
        clicked = true;
    }

    public void RunQuicktimeEvent(float time)
    {        
        mainAgent.SetVariableValue("MultiChoiceValue", 0);
        clicked = false;

        loadingBar.enabled = true;
        clickIcon.enabled = true;
        bg.enabled = true;
        
        loadingBar.fillAmount = 1;

        StartCoroutine(QuickTimeNumerator(time));
    }

    void EndQuickTimeEvent(int status)
    {
        loadingBar.enabled = false;
        clickIcon.enabled = false;
        bg.enabled = false;
        
        mainAgent.SetVariableValue("MultiChoiceValue", status);
    }

    IEnumerator QuickTimeNumerator(float time)
    {
        float steps = 0.05f;
        float currentTime = 0;
        float loadingIncrement = steps / time;
        
        while (time > currentTime && !clicked)
        {
            yield return new WaitForSeconds(steps);
            currentTime += steps;
            loadingBar.fillAmount -= loadingIncrement;
        }

        if (clicked)
        {
            EndQuickTimeEvent(1);
            yield break;
        }
        
        EndQuickTimeEvent(2);
    }

}
