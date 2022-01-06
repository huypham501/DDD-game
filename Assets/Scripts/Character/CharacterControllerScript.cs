using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    private Vector2 lookDirectionVector = new Vector2(0, -1);
    private Vector2 moveVector = Vector2.zero;
    private InputActions inputActions;
    public int moveSpeed = 70;
    public int maxHealth = 5;
    private int _currentHealth;
    public int maxInvinsibleTime = 2;
    private float _currentInvisibleTime;
    private bool isInvisible = false;
    public float timeKnockback = 2;
    public float powerKnockback = 50;
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

        inputActions = new InputActions();
        inputActions.Character.Enable();
        inputActions.Character.Direction.started += move;
        inputActions.Character.Direction.performed += move;
        inputActions.Character.Direction.canceled += stopMove;
        inputActions.Character.Attack.performed += attack;

        _currentHealth = maxHealth;
        _currentInvisibleTime = maxInvinsibleTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvisible)
        {
            coutdownInvisibleMode();
        }
    }
    void FixedUpdate()
    {
        animator.SetFloat("Speed", moveVector.magnitude);
        if (Mathf.Approximately(Mathf.Abs(lookDirectionVector.x), Mathf.Abs(lookDirectionVector.y)))
        {
            animator.SetFloat("Horizontal", Mathf.Sign(lookDirectionVector.x));
            animator.SetFloat("Vertical", Mathf.Sign(lookDirectionVector.y));
        }
        else
        {
            animator.SetFloat("Horizontal", lookDirectionVector.x);
            animator.SetFloat("Vertical", lookDirectionVector.y);
        }
        // if (Mathf.Abs(lookDirectionVector.x) >= Mathf.Abs(lookDirectionVector.y))
        // {
        //     animator.SetFloat("Horizontal", lookDirectionVector.x);
        //     animator.SetFloat("Vertical", 0);
        // }
        // else
        // {
        //     animator.SetFloat("Horizontal", 0);
        //     animator.SetFloat("Vertical", lookDirectionVector.y);
        // }

        // rb.MovePosition(new Vector2(transform.position.x + moveVector.x * moveSpeed * Time.deltaTime, transform.position.y + moveVector.y * moveSpeed * Time.deltaTime));
        rb.velocity = new Vector2(moveVector.x, moveVector.y).normalized * moveSpeed * Time.deltaTime;
    }
    private void move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        if (!Mathf.Approximately(moveVector.x, 0.0f) || !Mathf.Approximately(moveVector.y, 0.0f))
        {
            lookDirectionVector.Set(moveVector.x, moveVector.y);
            lookDirectionVector.Normalize();
        }
    }
    private void stopMove(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
    }
    private void attack(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack");
    }
    private void changeHealth(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, maxHealth);
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
