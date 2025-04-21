using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Atributos")]
    public float speed;
    public int vida;
    public Rigidbody2D rb;
    [Header("Tiro")]
    public GameObject bullet;
    public GameObject bulletPos;
    public GameObject explosao;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimenta��o();
        Atirando();
    }

    public void Movimenta��o()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector2 mySpeed = new Vector2(horizontal, vertical) * speed;
        //Normalizando a velocidade
        mySpeed.Normalize();
        //Dando velocidade pro RB
        rb.linearVelocity = mySpeed * speed;
    }

    public void Atirando()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject tiro = Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
            //Dar a dire��o para o rb do tiro
            tiro.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);

        }
        
    }

    public void PerdeVida(int dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
        }
        Debug.Log(vida);
    }
}
