using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleBehavior : MonoBehaviour
{ 
    float speed = -0.005f;

    public GameObject birdObject;
    
    
    public float outOfScreenPositon;
    
    public BirdBehavior classbird;

    public float slowDown=0.00002f;
    

    void Start()
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

        //if (transform.position.x <= outOfScreenPositon)
        //{
            //Destroy(gameObject);
            
            //transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0); 
            
            
            //transform.position = new Vector3(11 ,Random.Range(-2 ,4) , 0);
            
        //}
        
        if (classbird != null && classbird.isDead)
        {
            //Debug.Log("lmao");
            if (speed < 0)
            {
                speed += slowDown;    
            }
            
        }
    }
}
