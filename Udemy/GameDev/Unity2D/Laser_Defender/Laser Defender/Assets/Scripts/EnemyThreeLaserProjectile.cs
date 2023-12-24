using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeLaserProjectile : MonoBehaviour
{
    [SerializeField] Sprite projectileHitSprite;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
