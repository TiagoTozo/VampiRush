using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    float tempoIma,tempoAlho,tempoCapa;
    public string tipo;
    // Start is called before the first frame update
    void Start()
    {
        tempoIma=GameController.gameController.DuracaoIma;
        tempoCapa=GameController.gameController.DuracaoCapa;
        tempoAlho=GameController.gameController.DuracaoAlho;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision colisao){
        if(colisao.collider.CompareTag("Player")){
            switch(tipo){
                case "Ima":{
                    AtivaIma(colisao.collider); 
                }break;
                case "Capa":{
                    AtivaCapa(colisao.collider);
                }break;
                case "Alho":{
                    AtivaAlho(colisao.collider);
                }break;
                case null :break;

            }
            Destroy(gameObject);
        }
    }
    public void AtivaIma(Collider collider){
        PlayerRB meujogador = collider.GetComponent<PlayerRB>();
        if(meujogador!=null){
            if(meujogador.imaAtivo==false){
                meujogador.AtivarIma();
                GameController.gameController.uiController.AtivaIma();
            }
            else{
                meujogador.timerIma=tempoIma;
                GameController.gameController.uiController.timerIma=tempoIma;
            }
        }
    }
    public void AtivaAlho(Collider collider){
        PlayerRB meujogador = collider.GetComponent<PlayerRB>();
        if(meujogador!=null){
            if(meujogador.alhoAtivo==false){
                meujogador.AtivarAlho();
                GameController.gameController.uiController.AtivaAlho();
            }
            else{
                meujogador.timerAlho=tempoAlho;
                GameController.gameController.uiController.timerAlho=tempoAlho;
            }
        }
    }
    public void AtivaCapa(Collider collider){
        PlayerRB meujogador = collider.GetComponent<PlayerRB>();
        if(meujogador!=null){
            if(meujogador.capaAtiva==false){
                meujogador.AtivarCapa();
                GameController.gameController.uiController.AtivaCapa();
            }
            else{
                meujogador.timerCapa=tempoCapa;
                GameController.gameController.uiController.timerCapa=tempoCapa;
            }
        }
    }

    
}
