using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleBehavior : MonoBehaviour
{
    public BirdBehavior classbird;

    public GameObject birdObject;
    
    public float speed;
    public float outOfScreenPositon;
    

    void start()
    {
        birdObject = GameObject.FindWithTag("Bird");

        if (birdObject != null)
        {
            classbird = birdObject.GetComponent<BirdBehavior>();
            Debug.Log("✅ Found the BirdBehavior on: " + birdObject.name);
        }
        else
        {
            Debug.LogError("❌ No GameObject with tag 'Bird' found in the scene!");
        }
    }
    
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += speed; 
        transform.position = currentPosition;

        if (transform.position.x <= outOfScreenPositon)
        {
            //Destroy(gameObject);
            
            //transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0); 
            
            
            transform.position = new Vector3(11 ,Random.Range(-2 ,4) , 0);
            
        }
        //classbird != null && 
        if (classbird != null && classbird.isDead == true)
        {
            Debug.Log("lmao");
            speed += 0.0005f;
        }
    }
}
