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

    public void HideAllButtons()
    {
        HideButton(buttonA);
        HideButton(buttonB);
        HideButton(buttonC);
        HideButton(buttonD);
        
        textA.text = "";
        textB.text = "";
        textC.text = "";
        textD.text = "";
    }

    public void SetTexts(string a, string b, string c, string d)
    {
        int visibleCount = -1;
        if (a == string.Empty) HideButton(buttonA);
        else
        {
            visibleCount++;
            ShowButton(buttonA);
        }
        
        if (b == string.Empty) HideButton(buttonB);
        else
        {
            visibleCount++;
            ShowButton(buttonB);
        }
        
        if (c == string.Empty) HideButton(buttonC);
        else
        {
            visibleCount++;
            ShowButton(buttonC);
        }
        
        if (d == string.Empty) HideButton(buttonD);
        else
        {
            visibleCount++;
            ShowButton(buttonD);
        }
        
        //Center box
        var rect = gameObject.GetComponent<RectTransform>();
        transform.localPosition = new Vector3(transform.localPosition.x, visibleCount * 66.6666666667f, transform.localPosition.z);
        
        textA.text = a;
        textB.text = b;
        textC.text = c;
        textD.text = d;
    }

    void ShowButton(Button button)
    {
        button.GetComponent<Image>().enabled = true;
        button.interactable = true;
    }

    void HideButton(Button button)
    {
        button.GetComponent<Image>().enabled = false;
        button.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
