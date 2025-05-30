using TMPro;
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
    [SerializeField]protected GameObject explos�o;
    [Header("Tiro")]
    [SerializeField]protected GameObject bullet;
    [SerializeField]protected GameObject bulletPos;
    [SerializeField]protected float bulletSpeed;
    protected float waitShoot = 1f;
    [SerializeField] protected AudioClip somTiro;
    [SerializeField] protected AudioClip somTiro2;

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

                if (powerUp)
                {
                    //Dropando powerup
                    CriaItem();
                }
                
                var gerador = FindFirstObjectByType<GeradorInimigos>();
                if (gerador)
                {
                    gerador.GanhaPontos(pontos);
                }
                
                
                
            }
        }
    }

    public void TocaTiro()
    {
        AudioSource.PlayClipAtPoint(somTiro, Vector3.zero);
    }
    public void TocaTiro2()
    {
        AudioSource.PlayClipAtPoint(somTiro2, Vector3.zero);
    }

    private void OnDestroy()
    {
        var gerador = FindFirstObjectByType<GeradorInimigos>();
        //S� executa o c�digo se o gerador existe
        if (gerador)
        {
            gerador.DiminuiQuantidade();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            Destroy(gameObject);
            Instantiate(explos�o, transform.position, transform.rotation);
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

            //Dando pontos
            var gerador = FindFirstObjectByType<GeradorInimigos>();
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

            //Mandando o powerUP ser destru�do em tr�s segundos
            Destroy(pUP, 5.3f);

            Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            pUP.GetComponent<Rigidbody2D>().linearVelocity = dir;
        }
    }
}
