using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Atributos que todos os inimigos devem ter
    [Header("Atributos")]
    [SerializeField]protected float speed;
    [SerializeField]protected int vida;
    [Header("Assets")]
    [SerializeField]protected GameObject explosão;
    [Header("Tiro")]
    [SerializeField]protected GameObject bullet;
    [SerializeField] protected GameObject bulletPos;
    protected float waitShoot = 1f;
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
