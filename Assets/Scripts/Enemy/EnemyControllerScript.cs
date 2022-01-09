using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyControllerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Transform target;
    Seeker seeker;
    private Path _curPath;
    private float nextWaypointDistance = 3f;
    private int _curWayPoint = 0;
    private bool isReachEndOfPath = false;
    // private Vector2 lookDirection = Vector2.zero;
    public float moveSpeed = 300;
    public float maxHealth = 50f;
    private float _currentHealth;
    public float timeBounceBack = 2;
    public float powerBounceBack = 100f;
    public int detectDistance = 5;
    public float minFollowDistance = 1f;
    private Vector2 lookDirection;
    HPBehaviour hpBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hpBehaviour = GetComponent<HPBehaviour>();
        target = CharacterController.instance.transform;

        seeker = GetComponent<Seeker>();
        InvokeRepeating("updatePath", 0f, 0.5f);

        _currentHealth = maxHealth;
        hpBehaviour.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (_curPath != null && isInDistanceFollow())
        {
            if (_curWayPoint >= _curPath.vectorPath.Count)
            {
                isReachEndOfPath = true;
                return;
            }
            else
            {
                isReachEndOfPath = false;
            }

            lookDirection = ((Vector2)_curPath.vectorPath[_curWayPoint] - rb.position).normalized;
            animator.SetFloat("Speed", lookDirection.magnitude);
            if (lookDirection.x > 0)
            {
                animator.SetFloat("Horizontal", 1);
            }
            else
            {
                animator.SetFloat("Horizontal", 0);
            }

            rb.AddForce(new Vector2(lookDirection.x * moveSpeed * Time.deltaTime, lookDirection.y * moveSpeed * Time.deltaTime));

            if (Vector2.Distance(rb.position, _curPath.vectorPath[_curWayPoint]) < nextWaypointDistance)
            {
                _curWayPoint++;
            }
        }
    }
    void FixedUpdate()
    {

    }
    private bool isInDistanceFollow()
    {
        float distanceTemp = Vector2.Distance(target.position, rb.position);
        return distanceTemp <= detectDistance;
    }
    private void updatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnUpdatePathComplete);
        }
    }
    private void OnUpdatePathComplete(Path foundPath)
    {
        if (!foundPath.error)
        {
            _curPath = foundPath;
            _curWayPoint = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "CharacterHitBox")
        {
            changeHealth((-1) * CharacterController.instance.characterStats.strength);
            getHit(other.otherCollider.gameObject.transform);
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
    private void getHit(Transform hitByObject)
    {
        StartCoroutine(animationBounceBackGetHit(hitByObject));
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
}
