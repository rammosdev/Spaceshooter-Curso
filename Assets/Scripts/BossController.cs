using UnityEngine;
using UnityEngine.UI;

public class BossController : InimigoPai
{
    [SerializeField] private string estado = "estado1";
    private Rigidbody2D rb;
    private bool direita;
    [SerializeField] private float limiteH;
    [SerializeField] private int maxHealth;

    [Header("Tiros")]
    [SerializeField] private Transform posicaoTiro1;
    [SerializeField] private Transform posicaoTiro2;
    [SerializeField] private Transform posicaoTiro3;
    [SerializeField] private GameObject tiro1;
    [SerializeField] private GameObject tiro2;
    [SerializeField] private float delayTiro = 1f;
     private float waitShoot2;
    [SerializeField] private string[] estados;
    [SerializeField] private float esperaEstado = 10f;
    [Header("Interface")]
    [SerializeField] private Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        vida = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TrocaEstado();
        switch (estado)
        {
            case "estado1":
                Estado1();
                break;
            case "estado2":
                Estado2();
                break;
            case "estado3":
                Estado3();
                break;
        }
        //Garantir que a divisão vai retornar um float
        healthBar.fillAmount = ((float) vida / (float) maxHealth);
        AumentaDificuldade();
    }

    private void Estado1()
    {
        waitShoot -= Time.deltaTime;
        if (waitShoot < 0)
        {
            Tiro1();
            waitShoot = delayTiro;
        }
        //Indo para direita e esquerda
        if (direita)
        {
            rb.linearVelocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0f);
        }

        if (transform.position.x >= limiteH)
        {
            direita = false;
        }
        else if (transform.position.x <= -limiteH)
        {
            direita = true;
        }

    }

    private void Tiro1()
    {
        TocaTiro();
        GameObject tiroUm = Instantiate(tiro1, posicaoTiro1.position, transform.rotation);
        GameObject tiroDois = Instantiate(tiro1, posicaoTiro2.position, transform.rotation);

        tiroUm.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
        tiroDois.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
    }

    private void Estado2()
    {
        rb.linearVelocity = Vector3.zero;
        waitShoot -= Time.deltaTime;
        if (waitShoot <= 0)
        {
            Tiro2();
            waitShoot = delayTiro / 2;
        }
    }
    private void Tiro2()
    {
        //Encontrando o player na cena
        var player = FindFirstObjectByType<PlayerController>();
        if (player)
        {
            GameObject tiro = Instantiate(tiro2, posicaoTiro3.position, transform.rotation);
            //Encontrando o valor da direção
            Vector2 direcao = player.transform.position - tiro.transform.position;
            direcao.Normalize();
            //Dando a direção do tiro
            tiro.GetComponent<Rigidbody2D>().linearVelocity = direcao * -bulletSpeed;
            //Dando o ângulo certo do tiro
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            //Passando o angulo
            tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);
            waitShoot = 0.5f;
            TocaTiro2();
        }
    }

    private void Estado3()
    {
        rb.linearVelocity = Vector3.zero;
        //Tiro1
        waitShoot -= Time.deltaTime;
        if (waitShoot < 0)
        {
            Tiro1();
            waitShoot = delayTiro;
        }

        //Tiro2
        waitShoot2 -= Time.deltaTime;
        if (waitShoot2 <= 0)
        {
            Tiro2();
            waitShoot2 = delayTiro;
        }

    }

    private void AumentaDificuldade()
    {
        //Checando se minha vida é menor ou igual do que a metade da vida
        if (vida <= maxHealth/2)
        {
            delayTiro = 0.5f;
        }

    }

    private void TrocaEstado()
    {
        if (esperaEstado <= 0f)
        {
            //Escolhendo novo estado
            //Escolhendo um valor aleatório de estado
            int indiceEstado = Random.Range(0, estados.Length);
            estado = estados[indiceEstado];
            esperaEstado = 10f;
        }else
        {
            esperaEstado -= Time.deltaTime;
        }
    }
}
