using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10.0f;
    public float gravityModifier = 2.0f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim; //variavel para puxar as animações
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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //caso aperte espaço ele pula
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //programa um impuslo para o objeto, não uma movimentação brusca com o translate
            isOnGround = false; //define que não está mais no chão
            playerAnim.SetTrigger("Jump_trig"); //coloca a condição para a animação ocorrer
            dirtParticle.Stop(); //para a particula de terra enquanto pula
            playerAudio.PlayOneShot(jumpSound, 1.0f); //toca o som uma vez one shot
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //caso o player colide com algo com a tag ground, entra no if
        {
            isOnGround = true; //define que o player está no chão quando ele colide com o chão
            dirtParticle.Play(); //inicia a particula de terra novamente
        }else if (collision.gameObject.CompareTag("Obstacle")) //caso o player colide com um obstaculo, entra no else if
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true); //pega a condição para realizar a animação
            playerAnim.SetInteger("DeathType_int", 1); //outra condição para realizar a animação
            explosionParticle.Play(); //inicia a particula de explosão
            dirtParticle.Stop(); //para a particula de terra
            playerAudio.PlayOneShot(crashSound, 1.0f); //toca o som uma vez one shot
        }
    }
}
