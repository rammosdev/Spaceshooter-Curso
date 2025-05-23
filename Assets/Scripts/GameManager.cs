using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        //Garantindo que só existe 1 gameManager por vez
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //Não destruir quando ele mudar de cena
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //Criando o método para ir para o jogo
    public void CarregaJogo()
    {
        //Carregar a cena do jogo
        SceneManager.LoadScene(1);
    }

    //Criando um método que roda depois de um certo tempo
    IEnumerator firstScene()
    {
        yield return new WaitForSeconds(2f);
        //Tódo código abaixo daqui vai esperar 2s para poder rodar
        SceneManager.LoadScene(0);
    }

    public void Inicio()
    {
        //Iniciando a minha corotina
        StartCoroutine(firstScene());
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Fechei");
    }


}
