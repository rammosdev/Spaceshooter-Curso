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
    }

    public void Atirando()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
        }
        
    }

    public void PerdeVida(int dano)
    {
        vida -= dano;
        Debug.Log(vida);
    }
}
