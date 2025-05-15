using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerControl playerControlScript;

    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>(); //acha o player e conversa com o playercontrol
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        if(playerControlScript.gameOver == false) //para de spawnar objetos quando da gameover
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
