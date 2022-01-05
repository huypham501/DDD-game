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
    public int maxHealth = 2;
    private int _currentHealth;
    public int maxInvinsibleTime = 2;
    private float _currentInvisibleTime;
    private bool isInvisible = false;
    public float timeKnockback = 2;
    public float powerKnockback = 50;
    private bool isAttacking = false;
    public int detectDistance = 5;
    public float minFollowDistance = 1.5f;
    private Vector2 directionToPlayer;
    public int currentHealth
    {
        get { return _currentHealth; }
    }
    public HPBehaviour HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // target = FindObjectOfType<CharacterControllerScript>().transform;
        _currentHealth = maxHealth;
        _currentInvisibleTime = maxInvinsibleTime;
        HealthBar.SetHP(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // directionToPlayer = target.position - transform.position;

        // _xMove = Input.GetAxis("Horizontal");
        // _yMove = Input.GetAxis("Vertical");

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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "CharacterHitBox")
        {
            Destroy(gameObject);
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
        if (Mathf.Abs(directionToPlayer.x) >= Mathf.Abs(directionToPlayer.y))
        {
            animator.SetFloat("Horizontal", 1);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
        }

        rb.MovePosition(new Vector2(transform.position.x + directionToPlayer.x * moveSpeed * Time.deltaTime, transform.position.y + directionToPlayer.y * moveSpeed * Time.deltaTime));
    }
    void FixedUpdate()
    {
        // Vector2 vector2 = new Vector2(_xMove, _yMove);
        // Debug.Log(directionToPlayer.magnitude);
        if (directionToPlayer.magnitude <= detectDistance && directionToPlayer.magnitude >= minFollowDistance)
        {
            followPlayer();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Launch()
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
    private void changeHealth(int value)
    {
        // _currentHealth = Mathf.Clamp(_currentHealth + value, 0, maxHealth);
    }

    public void eatenStrawberry()
    {
        // changeHealth(Contants.VALUE_STRAWBERRY);
    }
    public void stepOnDamageableZone(Transform damageableZone)
    {
        // if (!isInvisible)
        // {
        //     enterInvisibleMode();
        //     // changeHealth(Contants.VALUE_DAMAGEABLE_ZONE);
        //     StartCoroutine(animationGetHit(damageableZone));
        // }
    }
    public IEnumerator animationGetHit(Transform obj)
    {
        // animator.SetTrigger("GetHit");
        // float timeCur = 0;
        // while (timeKnockback > timeCur)
        // {
        //     timeCur += Time.deltaTime;
        //     Vector2 vector2 = obj.position - transform.position;
        //     vector2 = vector2.normalized;
        //     rb.AddForce(-vector2 * powerKnockback);
        // }
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
