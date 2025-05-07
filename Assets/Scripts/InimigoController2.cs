using UnityEngine;

public class InimigoController2 : InimigoPai
{
    Rigidbody2D rb;
    [SerializeField] private float yMax = 2.5f;
    private bool isMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Atirando();
        Movimentação();
    }

    private void Atirando()
    {
        bool visivel = GetComponent<SpriteRenderer>().isVisible;
        if (visivel)
        {
            //Encontrando o player na cena
            var player = FindFirstObjectByType<PlayerController>();
            if (player)
            {
                waitShoot -= Time.deltaTime;
                if (waitShoot <= 0f)
                {
                    GameObject tiro = Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
                    waitShoot = Random.Range(1f, 3f);

                    //Encontrando o valor da direção
                    Vector2 direcao = player.transform.position - tiro.transform.position;
                    direcao.Normalize();
                    //Dando a direção do tiro
                    tiro.GetComponent<Rigidbody2D>().linearVelocity = direcao * bulletSpeed;
                    //Dando o ângulo certo do tiro
                    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
                    //Passando o angulo
                    tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                }
            }
        }

        
    }

    private void Movimentação()
    {
        if (transform.position.y <= yMax)
        {
            //Checando de que lado estou
            if (transform.position.x >= 0 && isMove)
            {
                
                rb.linearVelocity = new Vector2(-speed, -speed);
                isMove = false;
               
            }
            else if (isMove)
            {
                
                rb.linearVelocity = new Vector2(speed, -speed);
                isMove = false;

            }
        }
    }
}
