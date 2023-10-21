using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //paineis
    public GameObject painelDerrota,painelPausa,painelConfirmarSair;
    //bool dos paineis
    bool painelPausaOpen,painelConfirmarSairOpen;
    //
    public Text textInvulneravel;
    //Coisas dos PowerUps
    //Imã
    public Slider cooldownIma;
    public float timerIma,tempoIma;
    bool isImaVisivel;
    //
    void Start()
    {
        timerIma=tempoIma=GameController.gameController.DuracaoIma;
        if(cooldownIma!=null){
            isImaVisivel=false;
            cooldownIma.gameObject.SetActive(false);
        }
        if(painelPausa!=null){
            painelPausaOpen=false;
            painelPausa.SetActive(false);
        }
        if(painelConfirmarSair!=null){
            painelConfirmarSairOpen = false;
            painelConfirmarSair.SetActive(false);
        }
        if(painelDerrota!=null){
            painelDerrota.SetActive(false);
        }
        if(GameController.gameController!=null)
            GameController.gameController.uiController=this;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownIma!=null){
            if(isImaVisivel){
                if(timerIma>0){
                    timerIma-=Time.deltaTime;
                    cooldownIma.value=timerIma;
                }
                else{
                    isImaVisivel=false;
                    cooldownIma.gameObject.SetActive(false);
                    timerIma=tempoIma;
                }
            }
        }
    }
    public void Perder(){
        painelDerrota.SetActive(true);
    }
    public void Pausar(){
        painelPausa.SetActive(true);
        painelPausaOpen=true;
    }
    public void Despausar(){
        painelPausa.SetActive(false);
        painelPausaOpen=false;
    }
    public void IrProJogo(){
        SceneManager.LoadScene("Jogo");
    }
    public void Sair(){
        painelConfirmarSair.SetActive(true);
        painelConfirmarSairOpen=true;
    }
    public void SairFioSerio(){
        Application.Quit();
    }
    public void FechaConfirmacaoSaida(){
        painelConfirmarSair.SetActive(false);
        painelConfirmarSairOpen=false;
    }
    public void FicaInvulneravel(bool caso){
        textInvulneravel.gameObject.SetActive(caso);
    }
    public void AtivaIma(){
        cooldownIma.gameObject.SetActive(true);
        isImaVisivel=true;
    }
}
