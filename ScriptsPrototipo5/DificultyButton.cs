using UnityEngine.UI;
using UnityEngine;

public class DificultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int dificulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDificulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDificulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(dificulty);
    }
}
