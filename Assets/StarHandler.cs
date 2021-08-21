using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{

    [Header("Star Destroy FX")]
    [SerializeField] AudioClip starDestroyAudio;
    [SerializeField] GameObject starEffectPrefab;

    private ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = ScoreKeeper.GetScoreKeeper();
        if(!scoreKeeper || scoreKeeper == null){
            Debug.LogWarning("Star could not find ScoreKeeper");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        scoreKeeper.AddToScore(1);
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        GameObject starEffects = Instantiate(starEffectPrefab, transform.position, Quaternion.identity);
        ParticleSystem spawnedFX = starEffects.GetComponentInChildren<ParticleSystem>();
        spawnedFX.Play();
        AudioSource audioSource = starEffects.GetComponent<AudioSource>();
        audioSource.PlayOneShot(starDestroyAudio);
        Destroy(gameObject);
    }
}
