using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorGameOver : MonoBehaviour
{

    public GameObject painelGameOver;
    
    public void GameOver()
    {
        painelGameOver.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // Descongela o tempo antes de reiniciar
        
        // Essa linha pega o nome da cena atual e recarrega ela do zero!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}
