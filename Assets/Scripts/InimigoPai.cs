using Unity.VisualScripting;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Atributos que todos os inimigos devem ter
    [Header("Atributos")]
    [SerializeField]protected float speed;
    [SerializeField]protected int vida;
    [SerializeField]protected int pontos;
    [SerializeField]protected GameObject powerUp;
    [SerializeField] protected float itemRate;
    [Header("Assets")]
    [SerializeField]protected GameObject explosão;
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
                Instantiate(explosão, transform.position, transform.rotation);
                var gerador = FindFirstObjectByType<GeradorInimigos>();
                //gerador.DiminuiQuantidade();
                gerador.GanhaPontos(pontos);
                //Dropando powerup
                CriaItem();
                
            }
        }
    }

    private void OnDestroy()
    {
        var gerador = FindFirstObjectByType<GeradorInimigos>();
        gerador.DiminuiQuantidade();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletDestroyer"))
        {
            Destroy(gameObject);
            //var gerador = FindFirstObjectByType<GeradorInimigos>();
            //gerador.DiminuiQuantidade();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(explosão, transform.position, transform.rotation);

            //Tirando vida do player
            collision.gameObject.GetComponent<PlayerController>().PerdeVida(1);

            //Dando pontos
            var gerador = FindFirstObjectByType<GeradorInimigos>();
            //gerador.DiminuiQuantidade();
            gerador.GanhaPontos(pontos);

            CriaItem();
        }
    }

    private void CriaItem()
    {

        //Calculando chance de dropar o item
        float chance = Random.Range(0f, 1f);

        if (chance > itemRate)
        {
            //Criando o power up
            GameObject pUP = Instantiate(powerUp, transform.position, transform.rotation);

            //Mandando o powerUP ser destruído em três segundos
            Destroy(pUP, 3f);

            Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            pUP.GetComponent<Rigidbody2D>().linearVelocity = dir;
        }
    }
}
