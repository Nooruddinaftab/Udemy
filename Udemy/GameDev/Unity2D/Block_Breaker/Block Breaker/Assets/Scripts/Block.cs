using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticleEffect;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;
    GameSession gameSession;

    // state variables
    [SerializeField] int timesHit; // only for debugging


    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
        if (gameObject.tag == "Breakable")
            level.AddCountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Breakable")
        {
            HandleHit();
           
        }

        // Debug.Log(collision.gameObject.name);
    }
    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    private void DestroyBlock()
    {
        PlayDestroyAudio();
        TriggerParticleEffect();
        Destroy(gameObject);
        level.BlockDestroyed();
        gameSession.AddToScore();
    }

    private void PlayDestroyAudio()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }
    private void TriggerParticleEffect()
    {
        GameObject particleEffect = Instantiate(blockParticleEffect, transform.position, transform.rotation);
        Destroy(particleEffect, 3);

    }
}
