using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    GameObject player;
    PlayerRB pScript;
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameController.gameController.jogador.gameObject;
        pScript = GameController.gameController.jogador; 
    }

    // Update is called once per frame
    void Update()
    {   if(pScript.imaAtivo==true){
            Vector3 dir = player.transform.position - transform.position;
            if(dir.magnitude<15f){
                transform.position+=(dir.normalized*speed*Time.deltaTime);
            }
        }
    }
}
