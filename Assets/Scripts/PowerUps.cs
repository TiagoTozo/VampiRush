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
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            switch(tipo){
                case "Ima":{
                    AtivaIma(collider); 
                }break;
                case "Capa":{
                    AtivaCapa(collider);
                }break;
                case "Alho":{
                    AtivaAlho(collider);
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
