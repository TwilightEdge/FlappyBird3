
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int randomNumber;
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;
    public GameObject obstaclePrefab3;
    public GameObject obstaclePrefab4;
    public GameObject obstaclePrefab5;
    public GameObject obstaclePrefab6;

    private GameObject newObstacle1;
    private GameObject newObstacle2;
    private GameObject newObstacle3;
    private GameObject newObstacle4;
    private GameObject newObstacle5;
    private GameObject newObstacle6;
    
    
    public float timeBetweenObstacles;
    public float spawnAtXPosition;
    public float minYPosition;
    public float maxYPosition;
    float timeSinceLastObstacle;
    //int countDown = 2;
    
    public BirdBehavior classbird2;
    
    public GameObject birdObject2;
    

    private void Start()
    {
        
        //GameObject newObstacle = Instantiate(obstaclePrefab1);
        //newObstacle.transform.position = new Vector3(9 ,Random.Range(minYPosition,maxYPosition) , 0);
        
        newObstacle1 = Instantiate(obstaclePrefab1);
        newObstacle2 = Instantiate(obstaclePrefab2);
        newObstacle3 = Instantiate(obstaclePrefab3);
        newObstacle4 = Instantiate(obstaclePrefab4);
        newObstacle5 = Instantiate(obstaclePrefab5);
        newObstacle6 = Instantiate(obstaclePrefab6);
        
        newObstacle1.transform.position = new Vector3(-18, Random.Range(minYPosition,maxYPosition), 0);
        newObstacle2.transform.position = new Vector3(-18, Random.Range(minYPosition,maxYPosition), 0);
        newObstacle3.transform.position = new Vector3(-18, Random.Range(minYPosition,maxYPosition), 0);
        newObstacle4.transform.position = new Vector3(-18, Random.Range(minYPosition,maxYPosition), 0);
        newObstacle5.transform.position = new Vector3(-18, Random.Range(minYPosition,maxYPosition), 0);
        newObstacle6.transform.position = new Vector3(-18, Random.Range(minYPosition,maxYPosition), 0);
        
        SpawnNewObstacle();
        
        
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
    
        if (timeSinceLastObstacle >= timeBetweenObstacles && !classbird2.isDead )
        {
            SpawnNewObstacle();
            timeSinceLastObstacle = 0;
            //countDown--;
        }
    }

    void SpawnNewObstacle()
    {
        randomNumber = Random.Range(1, 6);
        //Debug.Log(randomNumber);
        if(randomNumber == 1 && newObstacle1.transform.position.x<-11)  newObstacle1.transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0);
        else if(randomNumber == 2 && newObstacle2.transform.position.x<-11)  newObstacle2.transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0);
        else if(randomNumber == 3 && newObstacle3.transform.position.x<-11)  newObstacle3.transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0);
        else if(randomNumber == 4 && newObstacle4.transform.position.x<-11)  newObstacle4.transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0);
        else if(randomNumber == 5 && newObstacle5.transform.position.x<-11)  newObstacle5.transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition,maxYPosition), 0);
        else if(randomNumber == 6 && newObstacle6.transform.position.x<-11) newObstacle6.transform.position = new Vector3(spawnAtXPosition, Random.Range(minYPosition, maxYPosition), 0);
        else SpawnNewObstacle();
        
    }
}
