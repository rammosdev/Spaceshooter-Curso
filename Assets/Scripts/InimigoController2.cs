using UnityEngine;

public class InimigoController2 : InimigoPai
{
    Rigidbody2D rb;

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
    }

    private void Atirando()
    {
        bool visivel = GetComponent<SpriteRenderer>().isVisible;
        if (visivel)
        {
            waitShoot -= Time.deltaTime;
            if (waitShoot <= 0f)
            {
                GameObject tiro = Instantiate(bullet, bulletPos.transform.position, bulletPos.transform.rotation);
                waitShoot = Random.Range(1f, 3f);
                //Encontrando o player na cena
                var player = FindFirstObjectByType<PlayerController>();
                //Encontrando o valor da direção
                Vector2 direcao = player.transform.position - tiro.transform.position;
                direcao.Normalize();
                //Dando a direção do tiro
                tiro.GetComponent<Rigidbody2D>().linearVelocity = direcao * bulletSpeed;

            }
        }

        
    }
}
