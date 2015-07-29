using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour
{

    public string textKey = "Area.TextKey";

    public void Start()
    {
        Text label = GetComponentInChildren<Text>();
        if (label != null)
        {
            label.text = Localizer.Instance.GetText(textKey);
        }
    }
}
