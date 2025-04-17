using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Atributos que todos os inimigos devem ter
    [Header("Atributos")]
    public float speed;
    public int vida;
    [Header("Assets")]
    public GameObject explosão;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerdeVida(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosão, transform.position, transform.rotation);
        }
    }
}
