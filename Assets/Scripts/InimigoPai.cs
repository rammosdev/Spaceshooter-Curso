using Unity.VisualScripting;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Atributos que todos os inimigos devem ter
    [Header("Atributos")]
    [SerializeField]protected float speed;
    [SerializeField]protected int vida;
    [Header("Assets")]
    [SerializeField]protected GameObject explos�o;
    [Header("Tiro")]
    [SerializeField]protected GameObject bullet;
    [SerializeField]protected GameObject bulletPos;
    [SerializeField]protected float bulletSpeed;
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
        if (transform.position.y < 5f)
        {
            vida -= dano;

            if (vida <= 0)
            {
                Destroy(gameObject);
                Instantiate(explos�o, transform.position, transform.rotation);
                FindFirstObjectByType<GeradorInimigos>().GanhaPontos(10);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletDestroyer"))
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(explos�o, transform.position, transform.rotation);

            //Tirando vida do player
            collision.gameObject.GetComponent<PlayerController>().PerdeVida(1);
        }
    }
}
