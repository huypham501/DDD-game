using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeingHit : MonoBehaviour
{
    public int maxHealth = 5;
    public int Health;
    public HPBehaviour HealthBar;
    void Start()
    {
        Health = maxHealth;
        HealthBar.SetHP(Health, maxHealth);
    }
    public void TakeHit(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            Destroy(gameObject);
    }
}
