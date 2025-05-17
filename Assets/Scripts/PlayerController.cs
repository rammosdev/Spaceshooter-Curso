using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Atributos")]
    public float speed;
    public int vida;
    public Rigidbody2D rb;
    public GameObject shield;
    private GameObject shieldAtual;
    private bool haveShield = false;
    private float shieldTimer = 0f;
    public int qntShield = 3;
    [Header("Tiro")]
    public GameObject bulletPos;
    public GameObject explosao;
    public GameObject meuTiro1;
    public GameObject meuTiro2;
    [SerializeField] private int levelTiro;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float waitShoot;
    [SerializeField] private float delayShoot = 0.5f;

    [SerializeField] private float xLimite;
    [SerializeField] private float yLimite;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI vidaTexto;
    [SerializeField] private Image[] shields;

    void Start()
    {
        vidaTexto.text = vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentação();
        Atirando();
        Escudo();
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
        waitShoot -= Time.deltaTime;
        if (Input.GetButton("Fire1") && waitShoot <= 0f)
        {
            switch (levelTiro)
            {
               case 1:

                    CriaTiro(meuTiro1, bulletPos.transform.position);
                    waitShoot = delayShoot;
                   break;
                case 2:
                    Vector3 posicao = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                    CriaTiro(meuTiro2, posicao);
                    posicao = new Vector3(transform.position.x + 0.45f, transform.position.y + 0.1f, 0f);
                    CriaTiro(meuTiro2, posicao);
                    waitShoot = delayShoot;
                    break;
                case 3:
                    CriaTiro(meuTiro1, bulletPos.transform.position);
                    posicao = new Vector3(transform.position.x - 0.45f, transform.position.y + 0.1f, 0f);
                    CriaTiro(meuTiro2, posicao);
                    posicao = new Vector3(transform.position.x + 0.45f, transform.position.y + 0.1f, 0f);
                    CriaTiro(meuTiro2, posicao);
                    waitShoot = delayShoot;
                    break;
            }
    }
        
    }

    public void Escudo()
    {
        if (Input.GetButtonDown("Shield") && (!haveShield) && qntShield > 0)
        {
            shieldAtual = Instantiate(shield, transform.position, transform.rotation);
            haveShield = true;
            qntShield--;
            shields[qntShield].enabled = false;
            
        }
        if (shieldAtual)
        {
            shieldAtual.transform.position = transform.position;
            //Se eu tenho um escudo, começo a contar o tempo
            shieldTimer += Time.deltaTime;


            //Se já se passaram 6 segundos, então eu destruo o escudo
            if (shieldTimer >= 6.2f)
            {
                haveShield = false;
                Destroy(shieldAtual);
                shieldTimer = 0;
            }
            
        }
        
    }

    private void CriaTiro(GameObject tiroCriado, Vector3 posicao)
    {

           GameObject tiro = Instantiate(tiroCriado, posicao, bulletPos.transform.rotation);
           //Dar a direção para o rb do tiro
           tiro.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0f, bulletSpeed);
    }

    public void PerdeVida(int dano)
    {

        //Atualizando a vida na UI
        
        vida -= dano;
        vidaTexto.text = vida.ToString();
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
            //Carregando a cena inicial do jogo
            //Achando o game manager
            var gameManager = FindAnyObjectByType<GameManager>();
            //Rodando o método de iniciar o jogo
            if (gameManager)
            {
                gameManager.Inicio();
            }
        }
        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            if (levelTiro < 3)
            {
                levelTiro++;
                
            }

            Destroy(collision.gameObject);
        }
    }
}
