using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public GameObject _gameObject;
    public Text _text;
    public Vector3 motion;
    public float duration;
    public float lastShow;

    public void Show()
    {
        active = true;
        lastShow = Time.time;
        _gameObject.SetActive(active);
    }
    public void Hide()
    {
        active = false;
        _gameObject.SetActive(active);
    }
    public void UpdateFloatingText()
    {
        if (!active)
            return;
        if (Time.time - lastShow > duration)
            Hide();

        _gameObject.transform.position += motion * Time.deltaTime;

    }
}
