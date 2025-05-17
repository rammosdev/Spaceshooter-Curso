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

    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Fechei");
    }
}
