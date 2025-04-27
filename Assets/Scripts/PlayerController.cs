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
    [SerializeField] private int levelTiro;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private float xLimite;
    [SerializeField] private float yLimite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentação();
        Atirando();
    }

    public void Movimentação()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector2 mySpeed = new Vector2(horizontal, vertical) * speed;
        //Normalizando a velocidade
        mySpeed.Normalize();
        //Dando velocidade pro RB
        rb.linearVelocity = mySpeed * speed;

        //Limitando a posição dele na tela
        //Clamp
        float meuX = Mathf.Clamp(transform.position.x, -xLimite, xLimite);
        float meuΥ = Mathf.Clamp(transform.position.y, -yLimite, yLimite);

        //Aplicando o meuX e meuΥ na minha posição
        transform.position = new Vector3(meuX, meuΥ, transform.position.z);
    }

    public void Atirando()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject tiro = Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
            //Dar a direção para o rb do tiro
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
