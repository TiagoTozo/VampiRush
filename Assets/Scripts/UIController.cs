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
    //Textos
    public Text textInvulneravel,textMoedas;
    //Coisas dos PowerUps
    //Imã
    public Slider cooldownIma;
    public float timerIma,tempoIma;
    bool isImaVisivel;
    //
    void Start()
    {
        if(GameController.gameController!=null){
            timerIma=tempoIma=GameController.gameController.DuracaoIma;
        }
        if(cooldownIma!=null){
            cooldownIma.maxValue=tempoIma;
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
    public void AtualizarMoeda(int nMoedas){
        textMoedas.text=nMoedas.ToString("Moedas: 0");
    }
}
