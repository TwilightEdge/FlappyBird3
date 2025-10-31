using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdBehavior : MonoBehaviour
{
    public bool isDead = false;
    
    Rigidbody rigidBodyReference;
    public float force = 10;
    //bool isDead;
    int score;

    void Start()
    {
        rigidBodyReference = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDead == false)
        {
            rigidBodyReference.linearVelocity = Vector3.zero;
            rigidBodyReference.AddForce(Vector3.up * force);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Application.LoadLevel(Application.loadedLevel);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        //Debug.Log("bird is dead!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead == false) 
        { 
            //score++;
            Debug.Log("Score: " + score);
        }
    }
}
