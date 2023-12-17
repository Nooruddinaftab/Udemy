using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    public void Hit(Player player)
    {
        if (player.GetHealth() <= 0)
            player.DestroyPlayer();
    }
    public void Hit(Enemy enemy)
    {
        if (enemy.GetHealth() <= 0)
            enemy.DestroyEnemy();
    }
}
