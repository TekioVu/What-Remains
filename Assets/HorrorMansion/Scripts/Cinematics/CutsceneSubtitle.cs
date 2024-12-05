using TMPro;
using UnityEngine;

public class SimpleSubtitle : MonoBehaviour
{
    public TMP_Text subtitleText;

    public void UpdateSubtitle(string newText)
    {
        subtitleText.text = newText;
    }
}
