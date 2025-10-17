using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LoadingController : MonoBehaviour
{
    public bool showLoadingText = true;
    public bool setBlackScreenOnLoading = false;
    
    private TextMeshProUGUI txt;

    private bool isLoading = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txt = transform.GetComponent<TextMeshProUGUI>();
    }

    public void StartLoadingText()
    {
        if (!showLoadingText) return;

        isLoading = true;
        txt.enabled = true;
        if (setBlackScreenOnLoading) transform.parent.GetComponent<Image>().enabled = true;
        txt.text = "Loading";
        StartCoroutine(LoadingTextLoop());
    }

    public void EndLoadingText()
    {
        if (!showLoadingText) return;
        
        isLoading = false;
        txt.enabled = false;
        transform.parent.GetComponent<Image>().enabled = false;
    }

    private IEnumerator LoadingTextLoop()
    {
        int looper = 0;
        string dots = string.Empty;
        
        while (isLoading)
        {
            yield return new WaitForSeconds(0.5f);
            looper++;
            if (looper >= 4)
            {
                dots = string.Empty;
                looper = 0;
            }
            dots += ".";

            txt.text = $"Loading{dots}";
        }
        
    }

}
