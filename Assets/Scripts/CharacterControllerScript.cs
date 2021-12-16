using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private Vector2 lookDirection = new Vector2(0, 0);
    public int moveSpeed;
    private float _xMove = 0f;
    private float _yMove = 0f;
    public int maxHealth;
    private int _currentHealth;
    public int maxInvinsibleTime;
    private float _currentInvisibleTime;
    private bool isInvisible = false;
    public float timeKnockback;
    public float powerKnockback;
    private bool isAttacking = false;
    public int currentHealth
    {
        get { return _currentHealth; }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _currentHealth = maxHealth;
        _currentInvisibleTime = maxInvinsibleTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            _xMove = Input.GetAxis("Horizontal");
            _yMove = Input.GetAxis("Vertical");
        }
        else
        {
            _xMove = _yMove = 0;
        }
        if (isInvisible)
        {
            coutdownInvisibleMode();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Attack");
            Launch();
        }
    }


    void FixedUpdate()
    {
        Vector2 vector2 = new Vector2(_xMove, _yMove);
        if (!Mathf.Approximately(vector2.x, 0.0f) || !Mathf.Approximately(vector2.y, 0.0f))
        {
            lookDirection.Set(vector2.x, vector2.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Speed", vector2.magnitude);
        if (Mathf.Abs(lookDirection.x) >= Mathf.Abs(lookDirection.y))
        {
            animator.SetFloat("Horizontal", lookDirection.x);
            animator.SetFloat("Vertical", 0);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", lookDirection.y);
        }

        rb.MovePosition(new Vector2(transform.position.x + _xMove * moveSpeed * Time.deltaTime, transform.position.y + _yMove * moveSpeed * Time.deltaTime));
    }
    private void Launch()
    {
        // GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);

        // ProjectileScript projectile = projectileObject.GetComponent<ProjectileScript>();
        // projectile.Launch(lookDirection, 300);
        animator.SetTrigger("Attack");
        isAttacking = true;
        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Back") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Top") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Left_Side") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack.Right_Side")) {
            Debug.Log("in attacking");
        }
        isAttacking = false;

    }
    private void changeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, maxHealth);
    }

    public void eatenStrawberry()
    {
        // changeHealth(Contants.VALUE_STRAWBERRY);
    }
    public void stepOnDamageableZone(Transform damageableZone)
    {
        if (!isInvisible)
        {
            enterInvisibleMode();
            // changeHealth(Contants.VALUE_DAMAGEABLE_ZONE);
            StartCoroutine(animationGetHit(damageableZone));
        }
    }
    public IEnumerator animationGetHit(Transform obj)
    {
        animator.SetTrigger("GetHit");
        float timeCur = 0;
        while (timeKnockback > timeCur)
        {
            timeCur += Time.deltaTime;
            Vector2 vector2 = obj.position - transform.position;
            vector2 = vector2.normalized;
            rb.AddForce(-vector2 * powerKnockback);
        }
        yield return 0;
    }
    private void enterInvisibleMode()
    {
        isInvisible = true;
        _currentInvisibleTime = maxInvinsibleTime;
        // changeOpacityCharacter(Contants.HALF_FLOAT);
    }

    private void coutdownInvisibleMode()
    {
        if (_currentInvisibleTime > 0)
        {
            _currentInvisibleTime -= Time.deltaTime;

        }
        else if (_currentInvisibleTime <= 0)
        {
            isInvisible = false;
            // changeOpacityCharacter(Contants.FULL_FLOAT);
        }
    }

    private void changeOpacityCharacter(float value)
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, value);
    }
}
