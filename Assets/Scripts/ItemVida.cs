using UnityEngine;

public class ItemVida : MonoBehaviour
{
    public int cura = 30; 

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            VidaPlayer vida = col.GetComponent<VidaPlayer>();
            if (vida != null)
            {
                vida.CurarVida(cura);
                Destroy(gameObject); 
            }
        }
    }
}