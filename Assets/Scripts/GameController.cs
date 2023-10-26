using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerRB jogador;
    public Vampiro vampiro;
    public Pista pista;
    public UIController uiController;
    public static GameController gameController;
    float pistaSpeed =4f;
    float tempoPraAcabar =2f;
    public float valorFileira = 4;
    public float DuracaoIma = 10f;
    public float DuracaoCapa = 8f;
    public float DuracaoAlho = 6f;
    void Awake(){
        GameController.gameController=this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Perder(){
        Pista.speed = 0f;
        Invoke("PararTempo",tempoPraAcabar);
        Invoke("AbrirMenuDerrota",tempoPraAcabar);
        Vibration.Vibrate((long)tempoPraAcabar*1000);
    }
    public void PararTempo(){
        Time.timeScale=0;
    }
    public void VoltarTempo(){
        Time.timeScale=1;
    }
    public void AbrirMenuDerrota(){
        uiController.Perder();
    }
    public void Restart(){
        Pista.speed=pistaSpeed;
        VoltarTempo();
        Pista.nPistas=1;
        SceneManager.LoadScene("Jogo");
    }
    public void Pausar(){
        PararTempo();
        uiController.Pausar();
    }
    public void Despausar(){
        uiController.Despausar();
        VoltarTempo();
    }
}
