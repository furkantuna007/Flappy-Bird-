using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Player player;
    public GameObject obstaclePrefab;
    public GameObject obstacleContainer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obstacleInstance = Instantiate(obstaclePrefab);
        obstacleInstance.transform.SetParent(obstacleContainer.transform);
        obstacleInstance.transform.position = new Vector2(4,-2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
