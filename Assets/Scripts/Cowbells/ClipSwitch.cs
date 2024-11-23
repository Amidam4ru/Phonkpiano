using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClipSwitch : MonoBehaviour
{
    [SerializeField] private ActiveCowbell _activeCowbell;
    [SerializeField] private int _numberOfSwitches;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchClip);
    }

    private void OnDisable()
    {
        _button?.onClick.RemoveAllListeners();
    }

    private void SwitchClip()
    {
        _activeCowbell.ChangeClip(_numberOfSwitches);
    }
}
