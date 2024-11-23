using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CowbellButton : MonoBehaviour
{
    [SerializeField] private AudioSource _cowbellSource;
    [SerializeField] private int _numberOfSemitonesUp;
    [SerializeField] private KeyCode _activeKey;

    private Button _button;
    private float _startPitch;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _startPitch = _cowbellSource.pitch;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayOneShot);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        var colors = _button.colors;

        if (Input.GetKeyDown(_activeKey))
        {
            PlayOneShot();
            PressButton(); // Визуально нажимаем кнопку
            Invoke("ReleaseButton", 0.1f);
        }
    }

    private void PlayOneShot()
    {
        _cowbellSource.pitch = _startPitch;
        _cowbellSource.pitch *= Mathf.Pow(2f, _numberOfSemitonesUp / 12f);

        _cowbellSource.Play();
    }

    private void PressButton()
    {
        var colors = _button.colors;
        _button.targetGraphic.color = colors.pressedColor;
    }

    private void ReleaseButton()
    {
        var colors = _button.colors;
        _button.targetGraphic.color = colors.normalColor;
    }
}
