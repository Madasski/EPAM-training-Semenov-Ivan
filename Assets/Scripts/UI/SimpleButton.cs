using Composition;
using Core.Sound;
using UnityEngine;
using UnityEngine.UI;

public class SimpleButton : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    
    private Button _button;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = CompositionRoot.GetAudioManager();
        
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        _audioManager.PlaySound(_clickSound);
    }
}