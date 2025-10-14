using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultichoiceButtonsController : MonoBehaviour
{
    private Button buttonA;
    private Button buttonB;
    private Button buttonC;
    private Button buttonD;
    
    private TextMeshProUGUI textA;
    private TextMeshProUGUI textB;
    private TextMeshProUGUI textC;
    private TextMeshProUGUI textD;

    private void Start()
    {
        buttonA = transform.GetChild(0).gameObject.GetComponent<Button>();
        textA = buttonA.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        buttonB = transform.GetChild(1).gameObject.GetComponent<Button>();
        textB = buttonB.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        buttonC = transform.GetChild(2).gameObject.GetComponent<Button>();
        textC = buttonC.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        buttonD = transform.GetChild(3).gameObject.GetComponent<Button>();
        textD = buttonD.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetTexts(string a, string b, string c, string d)
    {
        if (a == string.Empty) HideButton(buttonA);
        else ShowButton(buttonA);
        
        if (b == string.Empty) HideButton(buttonB);
        else ShowButton(buttonB);
        
        if (c == string.Empty) HideButton(buttonC);
        else ShowButton(buttonC);
        
        if (d == string.Empty) HideButton(buttonD);
        else ShowButton(buttonD);
        
        textA.text = a;
        textB.text = b;
        textC.text = c;
        textD.text = d;
    }

    void ShowTexts(TextMeshProUGUI textObj)
    {
        
    }

    void ShowButton(Button button)
    {
        button.GetComponent<Image>().enabled = true;
    }

    void HideButton(Button button)
    {
        button.GetComponent<Image>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
