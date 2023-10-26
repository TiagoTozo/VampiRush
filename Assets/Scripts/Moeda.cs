using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    GameObject player;
    PlayerRB pScript;
    bool irParaPlayer;
    float speed = 10f;
    static int TotalMoedas = 0;
    // Start is called before the first frame update
    void Start()
    {
        irParaPlayer = false;
        player = GameController.gameController.jogador.gameObject;
        pScript = GameController.gameController.jogador; 
    }

    // Update is called once per frame
    void Update()
    {   if(pScript.imaAtivo==true){
            Vector3 dir = player.transform.position - transform.position;
            if(dir.magnitude<15f&&irParaPlayer==false){
                irParaPlayer=true;
            }
        }
        if(irParaPlayer){
            Vector3 dir = player.transform.position - transform.position;
            transform.position+=(dir.normalized*speed*Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            Moeda.TotalMoedas++;
            GameController.gameController.uiController.AtualizarMoeda(TotalMoedas);
            Destroy(collider.gameObject);
        }
    }
}

