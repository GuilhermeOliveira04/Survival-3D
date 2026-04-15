using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

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
            // Reinicia a cena atual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        // Morte do Inimigo (Regra: se a bala encostar, inimigo some)
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject); // Destrói a bala
            Destroy(gameObject); // Destrói o inimigo
        }
    }

}
