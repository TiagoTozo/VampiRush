using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    float tempoIma;
    public string tipo;
    // Start is called before the first frame update
    void Start()
    {
        tempoIma=GameController.gameController.DuracaoIma;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision colisao){
        if(colisao.collider.CompareTag("Jogador")){
            switch(tipo){
                case "Ima":{
                    AtivaIma(colisao.collider); 
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

    
}
