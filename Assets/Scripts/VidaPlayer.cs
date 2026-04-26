using UnityEngine;
using TMPro;


public class VidaPlayer : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;


    public TextMeshProUGUI textoVida;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarTextoVida();
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual < 0) vidaAtual = 0; 

        AtualizarTextoVida();

        if (vidaAtual <= 0)
        {
            FindAnyObjectByType<GerenciadorGameOver>().GameOver();
        }
    }

    public void CurarVida(int cura)
    {
        vidaAtual += cura;
        if (vidaAtual > vidaMaxima) vidaAtual = vidaMaxima; // Não deixa passar de 100
        AtualizarTextoVida();
    }

    void AtualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = "VIDA: " + vidaAtual.ToString();
        }
    }
}
