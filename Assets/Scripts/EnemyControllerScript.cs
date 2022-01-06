using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Transform target;
    // private Vector2 lookDirection = Vector2.zero;
    public int moveSpeed = 3;
    public float maxHealth = 5f;
    private float _currentHealth;
    public int maxInvinsibleTime = 2;
    private float _currentInvisibleTime;
    private bool isInvisible = false;
    public float timeBounceBack = 2;
    public float powerBounceBack = 10;
    private bool isAttacking = false;
    public int detectDistance = 5;
    public float minFollowDistance = 1.5f;
    private Vector2 directionToPlayer;

    HPBehaviour hpBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hpBehaviour = GetComponent<HPBehaviour>();
        // target = FindObjectOfType<CharacterControllerScript>().transform;
        _currentHealth = maxHealth;
        _currentInvisibleTime = maxInvinsibleTime;
        hpBehaviour.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // directionToPlayer = target.position - transform.position;

        // if (isInvisible)
        // {
        //     coutdownInvisibleMode();
        // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Debug.Log("Attack");
        //     Launch();
        // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CharacterHitBox")
        {
            // -1 temp
            getHit(-1, other.transform);
        }

    }
    void FixedUpdate()
    {
        if (directionToPlayer.magnitude <= detectDistance && directionToPlayer.magnitude >= minFollowDistance)
        {
            followPlayer();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void followPlayer()
    {
        // if (!Mathf.Approximately(directionToPlayer.x, 0.0f) || !Mathf.Approximately(directionToPlayer.y, 0.0f))
        // {
        //     lookDirection.Set(directionToPlayer.x, directionToPlayer.y);
        //     lookDirection.Normalize();
        // }
        directionToPlayer.Normalize();
        animator.SetFloat("Speed", directionToPlayer.magnitude);
        animator.SetFloat("Horizontal", directionToPlayer.x);

        // if (Mathf.Abs(directionToPlayer.x) >= Mathf.Abs(directionToPlayer.y))
        // {
        //     animator.SetFloat("Horizontal", 1);
        // }
        // else
        // {
        //     animator.SetFloat("Horizontal", 0);
        // }

        rb.MovePosition(new Vector2(transform.position.x + directionToPlayer.x * moveSpeed * Time.deltaTime, transform.position.y + directionToPlayer.y * moveSpeed * Time.deltaTime));
    }
    private void attack()
    {
        // GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        // ProjectileScript projectile = projectileObject.GetComponent<ProjectileScript>();
        // projectile.Launch(lookDirection, 300);
        // animator.SetTrigger("Attack");
        // isAttacking = true;
        // Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        // while (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Back") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Top") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Left_Side") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Right_Side"))
        // {
        //     Debug.Log("in attacking");
        // }
        // isAttacking = false;

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
    private void getHit(float damageValue, Transform hitByObject)
    {
        if (!isInvisible)
        {
            // enterInvisibleMode();
            changeHealth(damageValue);
            StartCoroutine(animationBounceBackGetHit(hitByObject));
        }
    }
    private IEnumerator animationBounceBackGetHit(Transform hitByObject)
    {
        animator.SetTrigger("GetHit");
        float timeCur = 0;
        while (timeBounceBack > timeCur)
        {
            timeCur += Time.deltaTime;
            Vector2 vector2 = hitByObject.position - transform.position;
            vector2 = vector2.normalized;
            rb.AddForce(-vector2 * powerBounceBack);
        }
        yield return 0;
    }
    private void enterInvisibleMode()
    {
        // isInvisible = true;
        // _currentInvisibleTime = maxInvinsibleTime;
        // changeOpacityCharacter(Contants.HALF_FLOAT);
    }

    private void coutdownInvisibleMode()
    {
        // if (_currentInvisibleTime > 0)
        // {
        //     _currentInvisibleTime -= Time.deltaTime;

        // }
        // else if (_currentInvisibleTime <= 0)
        // {
        //     isInvisible = false;
        //     // changeOpacityCharacter(Contants.FULL_FLOAT);
        // }
    }

    private void changeOpacityCharacter(float value)
    {
        // GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, value);
    }

}
