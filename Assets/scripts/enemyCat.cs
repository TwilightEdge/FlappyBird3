using System;
using UnityEngine;

public class enemyCat : MonoBehaviour
{
    public int HP;
    
    public GameObject cat;
    
    public cat classcat;

    public float timeSinceLastAttack;
    
    public float timeSinceLastDash;
    
    public float dashCD;
    
    public float attackCD;

    public int damage;
    
    private Rigidbody2D enemyRigidbody;

    public float enemySpeed;
    
    public float enemyFleeSpeed;

    public float enemyDashForce;

    public bool isDashing;

    public float endOfDash; // the speed for checking if dash ended

    public bool attacking;

    public float missingHP;

    public int maxHP;

    public float timeSinceFleeing;

    public float chanceOfAttackingAgain; // between 0 and 10
    
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        cat = GameObject.FindWithTag("Player");
        classcat = cat.GetComponent<cat>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        
        attacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        timePass();
        
        CheckDash();
        
        if(!isDashing) 
        {
            if (attacking)
            {
                FollowPlayer();
            }
            else
            {
                Flee();
                if (timeSinceFleeing >= 1)
                {
                    timeSinceFleeing = 0;

                    if (UnityEngine.Random.Range(0, 10f) < chanceOfAttackingAgain)
                    {
                        attacking = true;
                    }
                }
            }
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision) // enemy dealing damage
    {
        
        if (collision.gameObject.CompareTag("Player") && timeSinceLastAttack >= attackCD)
        {
            animator.SetTrigger("attack");
            timeSinceLastAttack = 0;
            classcat.takeDamage(damage);
        }
        
    }
    
    
    private void OnCollisionStay2D(Collision2D collision) // enemy dealing damage
    {
        
        if (collision.gameObject.CompareTag("Player") && timeSinceLastAttack >= attackCD)
        {
            animator.SetTrigger("attack");
            timeSinceLastAttack = 0;
            classcat.takeDamage(damage);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other) // enemy taking damage
    {
        
        if (other.CompareTag("playerAttack"))
        {
            HP -= classcat.damage;
            
            isDashing = true;
            Vector2 knockbackDirection = transform.position - other.transform.position;
            enemyRigidbody.AddForce(knockbackDirection.normalized * classcat.knockbackPower, ForceMode2D.Impulse);
            
            CheckHP();
            
        }
        
    }

    void CheckHP() // also has a chance to flee here
    {
        if (HP <= 0)
        {
            Destroy(gameObject); // or whatever on enemy death
        }
        else
        {
            missingHP = maxHP - HP;

            if (UnityEngine.Random.Range(0f, missingHP) > 2f)
            {
                attacking = false;

                timeSinceFleeing = 0;
            }
        }
    }
    
    void timePass()
    {
        timeSinceLastAttack += Time.deltaTime;
        
        timeSinceLastDash +=  Time.deltaTime;
        
        timeSinceFleeing += Time.deltaTime;
        
    }

    void FollowPlayer()
    {
        
        Vector2 directionToPlayer = cat.transform.position - transform.position;

        if (directionToPlayer.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        enemyRigidbody.linearVelocity = directionToPlayer.normalized * enemySpeed;

    }
    
    void Flee()
    {
        Vector2 randomOffset = new Vector2(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f));
        
        Vector2 directionToFlee = ((Vector2)transform.position + randomOffset - (Vector2)cat.transform.position  ) ;

        if (directionToFlee.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        enemyRigidbody.linearVelocity = directionToFlee.normalized * enemyFleeSpeed;

    }

    void Dash()
    {
        isDashing = true;
        
        Vector2 directionToPlayer = cat.transform.position - transform.position;
        
        enemyRigidbody.AddForce(directionToPlayer.normalized * enemyDashForce, ForceMode2D.Impulse);
        
        
        
    }

    void CheckDash() //can dash and end of dash
    {
        if (Mathf.Abs(enemyRigidbody.linearVelocity.x) <= endOfDash && Mathf.Abs(enemyRigidbody.linearVelocity.y) <= endOfDash)
        {
            isDashing = false;
        }
        
        if(timeSinceLastDash>=dashCD && attacking) // this way it doesnt dash when fleeing, it can be changed
        {
            timeSinceLastDash = 0;
            Dash();
        }
    }
    
}
