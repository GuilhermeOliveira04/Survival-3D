using UnityEngine;

public class AtaqueEspecial : MonoBehaviour
{
    public float raioDaExplosao = 10f;
    public int custoDeVida = 30;     
    public KeyCode teclaEspecial = KeyCode.Q;

    private VidaPlayer vidaJogador;

    public ParticleSystem efeitoOndaDeChoque;

    void Start()
    {
        vidaJogador = GetComponent<VidaPlayer>();
    }

    void Update()
    {
        // Se o jogo estiver pausado, não faz nada
        if (Time.timeScale == 0f) return;

        if (Input.GetKeyDown(teclaEspecial))
        {
            ExecutarEspecial();
        }
    }

    void ExecutarEspecial()
    {
        
        vidaJogador.TomarDano(custoDeVida);

        //Cria uma "esfera invisível" para detetar quem está por perto
        Collider[] objetosAtingidos = Physics.OverlapSphere(transform.position, raioDaExplosao);

        foreach (Collider col in objetosAtingidos)
        {
            
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().Morrer();
            }
        }

        if (efeitoOndaDeChoque != null)
        {
            efeitoOndaDeChoque.Stop(); 
            efeitoOndaDeChoque.Play();
        }

    }

   
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioDaExplosao);
    }
}
