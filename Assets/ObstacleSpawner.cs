using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float timeBetweenObstacles;
    public float spawnAtXPosition;
    public float minYPosition;
    public float maxYPosition;
    float timeSinceLastObstacle;
    int countDown = 2;
    

    private void Start()
    {
        //SpawnNewObstacle();
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = new Vector3(9 ,Random.Range(minYPosition,maxYPosition) , 0);
        
    }

    void Update()
    {
        timeSinceLastObstacle += Time.deltaTime; //same as: timeSinceLastObstacle = timeSinceLastObstacle + Time.deltaTime;
    
        if (timeSinceLastObstacle >= timeBetweenObstacles && countDown > 0)
        {
            SpawnNewObstacle();
            timeSinceLastObstacle = 0;
            countDown--;
        }
    }

    void SpawnNewObstacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = 
            new Vector3(
                spawnAtXPosition,                           //x
                Random.Range(minYPosition,maxYPosition),    //y
                0);                                         //z
    }
}
