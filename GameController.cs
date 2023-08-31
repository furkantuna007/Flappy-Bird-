using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Player player;
    public GameObject scoreAreaPrefab;
    public GameObject obstaclePrefab;
    public GameObject obstacleContainer;
    public float holeSize;
    public float randomholeOffset;

    private float spawnPointer = 0f;
    public float spawnDistance;
    public float spawnOffset;

    public Text titleText;
    public Text instructionText;
    public Text scoreText;
    public Text gameoverText;

    private int score = 0;
    private bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        spawnPointer = -spawnDistance * 2;
        titleText.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);


        player.OnScore += OnScore;
        player.OnKill += OnKill;
    }

    // Update is called once per frame
void Update()
{   
    if (player != null) {
            // hide the ui elements
            if (player.GetComponent<Rigidbody2D>().velocity.x > 0) {
                titleText.gameObject.SetActive(false);
                instructionText.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(true);

            }
        //spawn new obstacles
        if(spawnPointer - player.transform.position.x < spawnDistance) {
            spawnPointer += spawnDistance;

            SpawnObstacle(spawnPointer+spawnOffset);
        }

        //clear previous obstacles
        for(int i=0; i < obstacleContainer.transform.childCount; i++) {
            GameObject currentObstacle = obstacleContainer.transform.GetChild(i).gameObject;
            if (player.transform.position.x - currentObstacle.transform.position.x > spawnOffset) {
                Destroy(currentObstacle);
            }
        }
    }

    if(gameOver == true) {
        if (Input.GetAxis("Fire1") == 1f) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

    void SpawnObstacle (float x) {
        float holeOffset = Random.Range(-randomholeOffset, randomholeOffset);

        GameObject obstacleTop = Instantiate(obstaclePrefab);
        obstacleTop.transform.SetParent(obstacleContainer.transform);
        obstacleTop.transform.position = new Vector2(x,holeSize/2+holeOffset);

        GameObject obstacleBottom = Instantiate(obstaclePrefab);
        obstacleBottom.transform.SetParent(obstacleContainer.transform);
        obstacleBottom.transform.position = new Vector2(x,-holeSize/2+holeOffset);

        GameObject scoreArea = Instantiate(scoreAreaPrefab);
        scoreArea.transform.SetParent(obstacleContainer.transform);
        scoreArea.transform.position = new Vector2 (x+2,holeOffset-1);
    }

    void OnScore() {
        score++;
        scoreText.text = "Score : " + score;
    }

    void OnKill() {
        scoreText.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(true);
        gameoverText.text = string.Format(gameoverText.text, score);
        gameOver = true;
    }
}
