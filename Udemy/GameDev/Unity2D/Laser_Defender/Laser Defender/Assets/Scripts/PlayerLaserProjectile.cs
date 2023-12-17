using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserProjectile : MonoBehaviour
{
    [SerializeField] Sprite projectileHitSprite;

    public void SetProjectileSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = projectileHitSprite;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
