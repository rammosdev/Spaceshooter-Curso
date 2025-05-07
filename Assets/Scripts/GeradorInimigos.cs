using Unity.VisualScripting;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private int qtdInimigo = 0;
    [SerializeField] private GameObject bossAnimation;
    private bool animationCheck;
    [Header("Pontuação")]
    [SerializeField]private int pontos;
    [SerializeField]private int level = 1;
    [SerializeField] private int baseLevel;
    [Header("Timer")]
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float spawnWait;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (level <10)
        {
            GeraInimigos();
        }else
        {
            GeraBoss();
        }
        
    }

    private void GeraBoss()
    {

        if (qtdInimigo <= 0 && spawnWait > 0)
        {
            spawnWait -= Time.deltaTime;
        }
        //Instanciando a animação do boss
        if (!animationCheck && spawnWait <= 0)
        {
            GameObject animBoss = Instantiate(bossAnimation, Vector3.zero, transform.rotation);
            //Destruindo a animação do boss em
            animationCheck = true;
            Destroy(animBoss,6f);
        }
        
    }

    public void DiminuiQuantidade()
    {
        qtdInimigo--;
    }
    
    private bool ChecaPosicao(Vector3 posicao, Vector3 size)
    {
        //Checando se na posição tem alguém
        //Estou vendo se na posição tem algum colisor 2D
        Collider2D hit = Physics2D.OverlapBox(posicao, size, 0f);

        if (hit != null)
        {
            return true;
            //Houve colisão
        }else
        {
            return false;
            //Não houve colisão
        }

    }
    private void GeraInimigos()
    {
            //Timer
            if (spawnWait > 0 && qtdInimigo  <= 0)
            {
                spawnWait -= Time.deltaTime;
            }   
            
            if (spawnWait <= 0f && qtdInimigo <= 0f)
            {
                int quantidade = level * 4;
            int tentativas = 0;
                while (qtdInimigo < quantidade)
                {

                //Fazendo ele sair do laço de repetição se repetir muitas vezes
                tentativas++;
                if (tentativas >= 200)
                {
                    break;
                }
                    GameObject inimigoCriado;

                    float chance = Random.Range(0f, level);

                    if (chance > 2f)
                    {
                        inimigoCriado = inimigos[1];
                    }
                    else
                    {
                        inimigoCriado = inimigos[0];
                    }

                    //Criando um inimigo
                    Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);
                    bool colisão = ChecaPosicao(posicao, inimigoCriado.transform.localScale);
                    //Se houve colisão, não instantiar
                    if (colisão)
                    {
                        continue;
                    }
                    Instantiate(inimigoCriado, posicao, transform.rotation);
                    qtdInimigo++;
                    spawnWait = timeToSpawn;


            }
        }
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos += pontos;
        //Ganhando level se os pontos forem maior que a baseLevel * level
        if (this.pontos > baseLevel * level)
        {
            level++;
        }
    }
}
