using UnityEngine;
using TMPro;

public class GerenciadorPontos : MonoBehaviour
{
    private int pontos = 0;
    public TextMeshProUGUI textoPontos;

    void Start()
    {
        AtualizarTexto();
    }

    public void GanharPontos(int valor)
    {
        pontos += valor;
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "PONTOS: " + pontos;
        }
    }
}