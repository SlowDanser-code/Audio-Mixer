using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class MasterSoundToggle : MonoBehaviour
{
    private const string MasterVolumeParameter = "MasterVolume";
    private const float NormalVolume = 0f;
    private const float MutedVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;
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
            _audioMixer.SetFloat(MasterVolumeParameter, MutedVolume);
            _buttonText.text = "Включить звук";
        }
        else
        {
            _audioMixer.SetFloat(MasterVolumeParameter, NormalVolume);
            _buttonText.text = "Выключить звук";
        }
    }
}