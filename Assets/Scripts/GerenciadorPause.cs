using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorPause : MonoBehaviour
{
    public GameObject painelPause; 
    private bool jogoPausado = false;

    void Update()
    {
        // Se apertar Esc, alterna o pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado) Continuar();
            else Pausar();
        }
    }

    public void Pausar()
    {
        painelPause.SetActive(true); // Mostra a tela
        Time.timeScale = 0f;         // Congela o tempo do jogo
        jogoPausado = true;

        // Libera o mouse para clicar nos botões
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continuar()
    {
        painelPause.SetActive(false); // Esconde a tela
        Time.timeScale = 1f;          // Volta o tempo ao normal
        jogoPausado = false;

        // Prende o mouse de volta no centro para jogar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IrParaMenu()
    {
        Time.timeScale = 1f; // volta o tempo ao normal antes de sair!
        SceneManager.LoadScene("MenuPrincipal"); 
    }
}
