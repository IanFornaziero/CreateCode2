using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerControl playerControlScript;
    private float outBounds = -18.0f;
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerControl>(); //faz o código conversar com o outro script
    }

    void Update()
    {
        if(playerControlScript.gameOver == false) //faz tudo parar quando da gameover
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < outBounds //caso passe pela posição 
    && gameObject.CompareTag("Obstacle")) //caso tenha a tag de obstacle
        {
            Destroy(gameObject); //destroi o objeto
        }
    }
}
