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

    private int maxHP;

    public float timeSinceFleeing;

    public float chanceOfAttackingAgain; // between 0 and 10
    
    private Animator animator;
    
    public GameObject clock;
    
    public clock classclock;

    bool isDay = false;
    
    bool isEve= false;
    
    bool isNight= false;

    private Collider2D colliderReference;
    
    public GameObject sleepPlace1;
    public GameObject sleepPlace2;
    
    public GameObject[] allSleepPlaces;

    public bool sleeping;

    private Vector2 directionToSleepPlace;
    
    public GameObject dash;
    
    private GameObject dashSpawn;

    private Vector2 directionToPlayer;
    
    private Vector2 dashRotation;
    
    public GameObject spawner;
    
    public spawner classspawner;


    void Awake()
    {
        
        allSleepPlaces = GameObject.FindGameObjectsWithTag("sleepPlace");

        if (allSleepPlaces.Length > 0)
        {
            sleepPlace1 = allSleepPlaces[0]; 
        }

        // This is the CRITICAL line for the second target
        if (allSleepPlaces.Length > 1) // Does the array have at least 2 elements?
        {
            sleepPlace2 = allSleepPlaces[1]; // Index 1 is the second element
        }
        
        spawner = GameObject.FindWithTag("spawner");
        
        classspawner = spawner.GetComponent<spawner>();
        
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        cat = GameObject.FindWithTag("Player");
        classcat = cat.GetComponent<cat>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        
        colliderReference = GetComponent<Collider2D>();
        
        clock = GameObject.FindWithTag("clock");
        
        classclock = clock.GetComponent<clock>();
        
        attacking = true;

        maxHP = HP;

        CheckForInitialTime();
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        timePass();

        CheckForTimeChange();
        
        TimeManager();

        


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
        
        if (other.CompareTag("sleepPlace") && classclock.isDay ) // reaching sleepPalace
        {

            sleeping = true;
            
            animator.SetTrigger("sleep");
            
        }
        
        
    }

    

    void CheckHP() // also has a chance to flee here
    {
        if (HP <= 0)
        {
            classspawner.UnregisterEnemy(this.gameObject);
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
        
        directionToPlayer = cat.transform.position - transform.position;

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
        
        directionToPlayer = cat.transform.position - transform.position;
        
        enemyRigidbody.AddForce(directionToPlayer.normalized * enemyDashForce, ForceMode2D.Impulse);
        
        if (directionToPlayer.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        
        dashSpawn = Instantiate(dash);
        
        dashSpawn.transform.position = new Vector2(transform.position.x, transform.position.y) - (directionToPlayer.normalized * 1.5f); // position of dash

        dashRotation = SnapToCardinalAxis(directionToPlayer); // this calculates dash rotation
        
        // this is for the rotation
        if (dashRotation == new Vector2(1, 0) && directionToPlayer.normalized == new Vector2(1, -1) && directionToPlayer.normalized == new Vector2(1, 1))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        if (dashRotation == new Vector2(-1, 0) && directionToPlayer.normalized == new Vector2(-1, -1) && directionToPlayer.normalized == new Vector2(-1, 1))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        if (dashRotation == new Vector2(0, 1))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else
        if (dashRotation == new Vector2(0, -1))
        {
            dashSpawn.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
        Destroy(dashSpawn, 0.2f);
        
    }

    
    public Vector2 SnapToCardinalAxis(Vector2 directionToPlayer)
    {
        // 1. Get the absolute values (magnitude) of the X and Y components
        float absX = Mathf.Abs(directionToPlayer.x);
        float absY = Mathf.Abs(directionToPlayer.y);

        // 2. Check for the dominant axis (Horizontal vs. Vertical)
        if (absX > absY)
        {
            // Direction is predominantly horizontal (Left or Right)
        
            // Use Mathf.Sign to get +1 for right or -1 for left. Y is zero.
            return new Vector2(Mathf.Sign(directionToPlayer.x), 0);
        }
        else
        {
            // Direction is predominantly vertical (Up or Down, or exactly diagonal/zero)

            // Use Mathf.Sign to get +1 for up or -1 for down. X is zero.
            return new Vector2(0, Mathf.Sign(directionToPlayer.y));
        }
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


    void CheckForInitialTime()
    {
        if (classclock.isDay)
        {
            BecomesDay();


        }
        else
        if(classclock.isNight)
        {
            BecomesNight();
            
            
        }
        else if (classclock.isEve)
        {
            BecomesEve();


        }
    }
    
    
    void CheckForTimeChange()
    {
        
        if (classclock.isDay)
        {
            if (isNight)
            {
                isNight = false;
                isDay = true;
                BecomesDay();
            }
            
            
        }
        else
        if(classclock.isEve)
        {
            
            if (isDay)
            {
                isDay = false;
                isEve = true;
                //BecomesEve();
            }
            
        }
        else if (classclock.isNight)
        {
            
            if (isEve)
            {
                isEve = false;
                isNight = true;
                BecomesNight();
            }
            
        }

    }


    void TimeManager() // DOOOOOOOOOOOOOOOOOOOOOOOOOOOO THE EACH FRAME THINGS HEREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
    {
        
        if (classclock.isEve)
        {
            // do the eve things
            
            
        }
        else
        if(classclock.isDay)
        {
            // do the day things

            if (!sleeping)
            {
                // go sleep
                
                if (directionToSleepPlace.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                enemyRigidbody.linearVelocity = directionToSleepPlace.normalized * enemySpeed;
                
            }
            else
            {
                 // you are sleeping
            }
            
        }
        else
        if(classclock.isNight)
        {
            // do the night things
            
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
        
    }
    
    
    void BecomesDay() // one time things after becoming day
    {
        isDay = true;
        colliderReference.isTrigger = true;
        
        if (UnityEngine.Random.Range(0, 10f) < 5f) // choose a sleepPlace
        {
            directionToSleepPlace = sleepPlace1.transform.position - transform.position; // get the direction
        }
        else
        {
            directionToSleepPlace = sleepPlace2.transform.position - transform.position; // get the direction
        }

        

    }
    
    void BecomesNight() // one time things after becoming night
    {
        
        isNight = true;
        sleeping = false;
        colliderReference.isTrigger = false;
        
        timeSinceLastDash = 0;
        
        animator.SetTrigger("wakeup");
        
    }
    
    void BecomesEve() // one time things after becoming eve
    {
        isEve = true;
        
        
    }
    
}
