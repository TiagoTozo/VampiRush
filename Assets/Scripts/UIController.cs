using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //paineis
    public GameObject painelDerrota,painelPausa,painelConfirmarSair;
    //bool dos paineis
    bool painelPausaOpen,painelConfirmarSairOpen;
    void Start()
    {
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
}
