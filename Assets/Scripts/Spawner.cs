using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject inimigoPrefab; // Prefab do inimigo a ser instanciado
    public Transform[] pontosDeSpawn; // Array de pontos de spawn para os inimigos

    public float tempodeSpawn = 5f; // Tempo entre cada spawn de inimigo
    private float tempoAtual; // Tempo atual desde o último spawn
    private float multiplicadorDificuldade = 0.95f; // Multiplicador para aumentar a dificuldade ao longo do tempo


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoAtual = tempodeSpawn; // Inicia o tempo atual para o tempo de spawn inicial
        Invoke("GerarInimigo", tempoAtual); // Chama a função de gerar inimigo após o tempo inicial
    }
    
    void GerarInimigo()
    {
        // Escolhe um ponto aleatório
        int index = Random.Range(0, pontosDeSpawn.Length);
        Instantiate(inimigoPrefab, pontosDeSpawn[index].position, Quaternion.identity);


        // Aumenta a dificuldade diminuindo o tempo para o próximo nascer
        if (tempoAtual > 0.15f) // 
        {
            tempoAtual *= multiplicadorDificuldade; 
        }

        Invoke("GerarInimigo", tempoAtual); // se chama recursivamente para continuar gerando inimigos
    }

}
