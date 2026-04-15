using UnityEngine;

public class EsconderCabeca : MonoBehaviour
{
    [Header("Arraste o osso da cabeça (Neck ou Head) para cá")]
    public Transform ossoDaCabeca;

    // Usamos LateUpdate porque ele roda DEPOIS do Animator atualizar o corpo.
    // Assim, nós garantimos que a cabeça fique encolhida.
    void LateUpdate()
    {
        if (ossoDaCabeca != null)
        {
            // Reduz o tamanho da cabeça para zero (invisível)
            ossoDaCabeca.localScale = Vector3.zero;
        }
    }
}