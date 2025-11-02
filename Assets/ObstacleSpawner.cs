using UnityEditor.Scripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int randomNumber;
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;

    private GameObject newObstacle;
    
    public float timeBetweenObstacles;
    public float spawnAtXPosition;
    public float minYPosition;
    public float maxYPosition;
    float timeSinceLastObstacle;
    int countDown = 2;
    
    public BirdBehavior classbird2;
    
    public GameObject birdObject2;
    

    private void Start()
    {
        SpawnNewObstacle();
        //GameObject newObstacle = Instantiate(obstaclePrefab1);
        //newObstacle.transform.position = new Vector3(9 ,Random.Range(minYPosition,maxYPosition) , 0);
        
        birdObject2 = GameObject.FindWithTag("Bird");

        if (birdObject2 != null)
        {
            classbird2 = birdObject2.GetComponent<BirdBehavior>();
            Debug.Log("✅ Found the BirdBehavior on: " + birdObject2.name);
        }
        else
        {
            Debug.LogError("❌ No GameObject with tag 'Bird' found in the scene!");
        }
        
    }

    void Update()
    {
        timeSinceLastObstacle += Time.deltaTime; //same as: timeSinceLastObstacle = timeSinceLastObstacle + Time.deltaTime;
    
        if (timeSinceLastObstacle >= timeBetweenObstacles && countDown > 0 && !classbird2.isDead )
        {
            SpawnNewObstacle();
            timeSinceLastObstacle = 0;
            countDown--;
        }
    }

    void SpawnNewObstacle()
    {
        randomNumber = Random.Range(1, 3);
        Debug.Log(randomNumber);
        if(randomNumber == 1)  newObstacle = Instantiate(obstaclePrefab1);
        else if(randomNumber == 2) newObstacle = Instantiate(obstaclePrefab2);
        else if(randomNumber == 3)  newObstacle = Instantiate(obstaclePrefab3);
        
        newObstacle.transform.position = 
            new Vector3(
                spawnAtXPosition,                           //x
                Random.Range(minYPosition,maxYPosition),    //y
                0);                                         //z
    }
}
