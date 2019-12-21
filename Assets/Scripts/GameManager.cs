using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI startText = null;
    [SerializeField] private AudioClip[] audioClips = null;

    private AudioSource _audioSource;


    private void Awake() 
    {
        _audioSource = GetComponent<AudioSource>();

        startText.gameObject.SetActive(true);
    }

    private void Update() 
    {
        if (Input.GetKeyUp(KeyCode.Space))
            DeactivateStartText();
    }

    public void DeactivateStartText()
    {
        startText.gameObject.SetActive(false);
    }

    public void ActivateStartText()
    {
        startText.gameObject.SetActive(true);
    }

    public void PlayHitSound()
    {
        _audioSource.clip = audioClips[0];
        _audioSource.Play();
    }

    public void PlayScoreSound()
    {
        _audioSource.clip = audioClips[1];
        _audioSource.Play();
    }

}
