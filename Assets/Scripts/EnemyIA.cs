using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject prefabCaixaVida; 
    [Range(0f, 1f)] public float chanceDeDrop = 0.2f; 

    private Transform player; // Referência ao transform do jogador
    private NavMeshAgent agent; // Referência ao componente NavMeshAgent do inimigo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Acha o jogador pela Tag automaticamente
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position); // Persegue o jogador
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VidaPlayer vidaDoJogador = collision.gameObject.GetComponent<VidaPlayer>();
            
            if (vidaDoJogador != null)
            {
                vidaDoJogador.TomarDano(25); // O zumbi tira 25 pontos de vida por hit
            }
        }
        
        // Morte do Inimigo (Regra: se a bala encostar, inimigo some)
        if (collision.gameObject.CompareTag("Bala"))
        {
            // destrói a bala
            Destroy(collision.gameObject);
            // mata o inimigo
            Morrer();
        }
    }

    public void Morrer()
    {
        // Ganha pontos 10 ao eliminar um inimigo
        FindAnyObjectByType<GerenciadorPontos>().GanharPontos(10);

        // Chance de drop de caixa de vida
        if (Random.value <= chanceDeDrop && prefabCaixaVida != null)
        {
            Instantiate(prefabCaixaVida, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        
        Destroy(gameObject);
    }

}
