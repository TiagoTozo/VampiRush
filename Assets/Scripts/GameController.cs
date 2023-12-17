using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerRB jogador;
    public Vampiro vampiro;
    public Pista pista;
    public UIController uiController;
    public AudioController audioController;
    public static GameController gameController;
    bool jogoPausado;
    float pistaSpeed =5f;
    float tempoPraAcabar =4f;
    public float valorFileira = 4;
    public float DuracaoIma = 10f;
    public float DuracaoCapa = 8f;
    public float DuracaoAlho = 6f;
    public bool canVibrate = true;
    int contadorClicks = 0;
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
        if(canVibrate)
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
    public void InteragirPausar(){
        if(!jogoPausado){
            PararTempo();
            uiController.InteragirPausar();
            jogoPausado=true;
        }
        else{
            VoltarTempo();
            uiController.InteragirPausar();
            jogoPausado=false;
        }
    }
    public void Continuar(){
        if(Moeda.TotalMoedas>=100||contadorClicks>=10){
            Pista.speed=pistaSpeed;
            VoltarTempo();
            uiController.painelDerrota.SetActive(false);
            //SceneManager.LoadScene("Jogo");
            jogador.Reset();
            if(Moeda.TotalMoedas>=100)
                Moeda.TotalMoedas-=100;
            contadorClicks=0;
            uiController.AtualizarMoeda(Moeda.TotalMoedas);
        }
        else{
            contadorClicks++;
        }
    }
    
    
}
