using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
[RequireComponent(typeof(Image))]
public class ToggleColorChanger : MonoBehaviour
{
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _disableColor;
    [SerializeField] private Image _background;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        _toggle.onValueChanged.AddListener(OnToggleChanged);
        UpdateColor(_toggle.isOn);
    }

    private void OnToggleChanged(bool isOn)
    {
        UpdateColor(isOn);
    }

    private void UpdateColor(bool isOn)
    {
        if (isOn)
        {
            _background.color = _activeColor;
        }
        else
        {
            _background.color = _disableColor;
        }
    }
}
