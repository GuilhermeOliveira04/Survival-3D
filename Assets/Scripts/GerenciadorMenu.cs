using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorMenu : MonoBehaviour
{

    public void IniciarJogo()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("SampleScene");
    }


    public void SairDoJogo()
    {
        // Encerra o jogo
        Debug.Log("O jogador saiu do jogo!");
        Application.Quit();
    }
}
