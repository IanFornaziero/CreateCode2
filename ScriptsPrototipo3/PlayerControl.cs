using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityModifier = 2.0f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim; //variavel para puxar as anima��es
    public ParticleSystem explosionParticle; //variavel para atrelar a particula
    public ParticleSystem dirtParticle;  //variavel para atrelar a particula
    public AudioSource playerAudio; //variavel para pegar o audio source do objeto
    public AudioClip jumpSound; //variavel para atrelar o som
    public AudioClip crashSound; //variavel para atrelar o som
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); //ele pega o componente do objeto atrelado
        playerAnim = GetComponent<Animator>(); //ele pega o componente do objeto atrelado
        playerAudio = GetComponent<AudioSource>(); //ele pega o componente do objeto atrelado
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //caso aperte espa�o ele pula
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //programa um impuslo para o objeto, n�o uma movimenta��o brusca com o translate
            isOnGround = false; //define que n�o est� mais no ch�o
            playerAnim.SetTrigger("Jump_trig"); //coloca a condi��o para a anima��o ocorrer
            dirtParticle.Stop(); //para a particula de terra enquanto pula
            playerAudio.PlayOneShot(jumpSound, 1.0f); //toca o som uma vez one shot
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //caso o player colide com algo com a tag ground, entra no if
        {
            isOnGround = true; //define que o player est� no ch�o quando ele colide com o ch�o
            dirtParticle.Play(); //inicia a particula de terra novamente
        }else if (collision.gameObject.CompareTag("Obstacle")) //caso o player colide com um obstaculo, entra no else if
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true); //pega a condi��o para realizar a anima��o
            playerAnim.SetInteger("DeathType_int", 1); //outra condi��o para realizar a anima��o
            explosionParticle.Play(); //inicia a particula de explos�o
            dirtParticle.Stop(); //para a particula de terra
            playerAudio.PlayOneShot(crashSound, 1.0f); //toca o som uma vez one shot
        }
    }
}
