using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CriaBoss()
    {
        Instantiate(boss, transform.position, transform.rotation);

        var meuPai = transform.parent.gameObject;
        Destroy(meuPai);
    }

    //Criando o m�todo de ir para a tela inicial
    public void EndGame()
    {
        var gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager)
        {
            gameManager.Inicio();
        }
        
    }
}
