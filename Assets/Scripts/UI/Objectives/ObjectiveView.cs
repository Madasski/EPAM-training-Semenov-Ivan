using UnityEngine;
using UnityEngine.UI;

public class ObjectiveView : SimpleView
{
    [SerializeField] private Text _textField;

    public void SetCompleted()
    {
        _textField.color = Color.grey;
    }

    public void SetDescription(string text)
    {
        _textField.text = text;
    }
}