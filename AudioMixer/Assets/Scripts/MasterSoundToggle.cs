using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class MasterSoundToggle : MonoBehaviour
{
    private const float MutedVolume = 0f;
    private const float NormalVolume = 1f;

    [SerializeField] private TMP_Text _buttonText;

    private Button _button;
    private bool _isMuted;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleSound);
    }

    private void Start()
    {
        ApplySoundState();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleSound);
    }

    private void ToggleSound()
    {
        _isMuted = !_isMuted;

        ApplySoundState();
    }

    private void ApplySoundState()
    {
        if (_isMuted)
        {
            AudioListener.volume = MutedVolume;
            _buttonText.text = "Включить звук";
        }
        else
        {
            AudioListener.volume = NormalVolume;
            _buttonText.text = "Выключить звук";
        }
    }
}