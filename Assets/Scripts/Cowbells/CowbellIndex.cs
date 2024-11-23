using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CowbellIndex : MonoBehaviour
{
    [SerializeField] private ActiveCowbell _activeCowbell;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _activeCowbell.ClipChanged += ChangeText;
    }

    private void OnDisable()
    {
        _activeCowbell.ClipChanged -= ChangeText;
    }

    private void ChangeText(int number)
    {
        _text.text = (number + 1).ToString();
    }
}
