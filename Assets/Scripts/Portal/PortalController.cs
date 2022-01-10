using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public float maxHealth = 500f;
    private float _currentHealth;
    Rigidbody2D rb;
    HPBehaviour hpBehaviour;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _currentHealth = maxHealth;
        hpBehaviour = GetComponent<HPBehaviour>();
        hpBehaviour.SetMaxHealth(_currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "CharacterHitBox")
        {
            changeHealth((-1) * CharacterController.instance.characterStats.strength);
        }
    }
    private void changeHealth(float value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, maxHealth);
        hpBehaviour.SetHealth(_currentHealth);
        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
