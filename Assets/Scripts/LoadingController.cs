using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LoadingController : MonoBehaviour
{
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
        isLoading = true;
        txt.enabled = true;
        if (setBlackScreenOnLoading) transform.parent.GetComponent<Image>().enabled = true;
        txt.text = "Loading";
        StartCoroutine(LoadingTextLoop());
    }

    public void EndLoadingText()
    {
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
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
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
