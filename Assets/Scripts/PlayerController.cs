using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimentação")]
    public float velocidade = 5f;
    public float forcaPulo = 5f;
    private Rigidbody rb;
    private bool noChao = true;

    [Header("Câmera (Primeira Pessoa)")]
    public Transform cameraJogador; 
    public float sensibilidadeMouse = 2f;
    private float rotacaoX = 0f;

    [Header("Animação do Personagem")]
    public Animator animator; 
    public Animator animatorSombra;

    [Header("Tiro")]  
    public GameObject prefabBala;
    public float velocidadeBala = 20f;
    public Transform pontoDeTiro; // Ponto de onde a bala será instanciada

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Trava o cursor do mouse no centro da tela e o deixa invisível
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Controle de camera com o mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        // Olhar para cima e para baixo (Gira a Câmera)
        rotacaoX -= mouseY; // subtrai o mouseY para inverter o movimento (para cima é negativo, para baixo é positivo)
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f); // Limita em 90 graus para não "quebrar o pescoço" para trás
        cameraJogador.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);

        // Olhar para os lados (Gira o Corpo do Jogador inteiro)
        transform.Rotate(Vector3.up * mouseX);

        // comandos de movimento
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        
        // Move o jogador sempre na direção para onde ele está olhando
        Vector3 movimento = transform.right * movX + transform.forward * movZ;
        transform.Translate(movimento * velocidade * Time.deltaTime, Space.World);

        // ATIVA A ANIMAÇÃO DE ANDAR
        bool isMoving = (movX != 0 || movZ != 0);
        if(animator != null) animator.SetBool("Andando", isMoving);
        if(animatorSombra != null) animatorSombra.SetBool("Andando", isMoving);

        // comando de pulo (spaço) - só pode pular se estiver no chão
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
            if(animator != null) animator.SetTrigger("Pulando");
            if(animatorSombra != null) animatorSombra.SetTrigger("Pulando");
        }



        // executa o tiro quando o botão esquerdo do mouse for pressionado
        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        if(pontoDeTiro != null)
        {
            GameObject novaBala = Instantiate(prefabBala, pontoDeTiro.position, cameraJogador.rotation);
            novaBala.GetComponent<Rigidbody>().linearVelocity = cameraJogador.forward * velocidadeBala;
            Destroy(novaBala, 2f);
        }
    }

    // Detecta se voltou para o chão
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            noChao = true;
        }
    }
}