using System;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //MOVEMENT
    public float speed = 4;
    
    //HEALTH
    public int Health = 5;
    public float noDamageTimer = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;

    //PROJECTILEs
    public int projectileCount = 0;
    public GameObject projectilePrefab;

    //AUDIO
    public AudioClip hitSound;
    public AudioClip shootingSound;
    
    //HEALTH
    public int health
    {
        get { return currentHealth; }
    }
    
    //MOVEMENT
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;
    
    //HEALTH
    int currentHealth;
    float invincibleTimer;
    bool isInvincible;
   
    // ANIMATION
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    
    //SOUNDS
    AudioSource audioSource;
    
    void Start()
    {
        //MOVEMENT
        rigidbody2d = GetComponent<Rigidbody2D>();
                
        //HEALTH
        invincibleTimer = -1.0f;
        currentHealth = Health;
        
        //ANIMATION
        animator = GetComponent<Animator>();
        
        //AUDIO
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //HEALTH
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        //MOVEMENT
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        currentInput = move;

        //ANIMATION
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        //PROJECTILE
        ProjectileCount.Projectile = projectileCount;
        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();
        
        //DIALOGUE
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }  
            }
        }
 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position = position + currentInput * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    //HEALTH
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        { 
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = noDamageTimer;
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hitSound);
            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, Health);
        if(currentHealth == 0)
            Respawn();
        HealthBar.Instance.SetValue(currentHealth / (float)Health);
    }
    void Respawn()
    {
        ChangeHealth(Health);
        transform.position = respawnPosition.position;
    }
    
    //PROJECTICLE
    void LaunchProjectile()
    {
        if (projectileCount > 0)
        {
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);
            animator.SetTrigger("Launch");
            audioSource.PlayOneShot(shootingSound);
            projectileCount--;
        }
    }
    
    //SOUND
    public void PlaySound(AudioClip clip)
    {
        if(PauseGame.gameIsPaused == false)
            audioSource.PlayOneShot(clip);
    }
}
