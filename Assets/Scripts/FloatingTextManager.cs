using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText _txt in floatingTexts)
            _txt.UpdateFloatingText();
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText._text.text = msg;
        floatingText._text.fontSize = fontSize;
        floatingText._text.color = color;
        
        //tranfer world space to screen space so we can use it in the UI
        floatingText._gameObject.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }
    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt._gameObject = Instantiate(textPrefab);
            txt._gameObject.transform.SetParent(textContainer.transform);
            txt._text = txt._gameObject.GetComponent<Text>();
        }
        return txt;
    }
}
