using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private const float MinVolumeDb = -80f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _volumeParameter;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void Start()
    {
        SetVolume(_slider.value);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float level)
    {
        float volumeDb;

        if (level > 0f)
        {
            volumeDb = Mathf.Log10(level) * 20f;
        }
        else
        {
            volumeDb = MinVolumeDb;
        }

        _audioMixer.SetFloat(_volumeParameter, volumeDb);
    }
}