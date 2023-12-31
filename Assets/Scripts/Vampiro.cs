using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Vampiro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jogador;
    public bool aproximaPlayer,alcancaPlayer,afastaPlayer;
    Vector3 posForaTela, posAtrasJogador, posJogador,alvo;
    float speed = 5f;
    float distForaTela=10f;
    Animator animator;
    bool pulando;
    void Awake(){
        //GameController.gameController.vampiro=this;
    }
    void Start()
    {
        animator=GetComponent<Animator>();
        GameController.gameController.vampiro=this;
        aproximaPlayer=false;
        alcancaPlayer=false;
        afastaPlayer=true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(aproximaPlayer){
            alvo = jogador.transform.position-new Vector3(0,0,3);
        }
        else{
            if(alcancaPlayer){
                alvo = jogador.transform.position;
            }
            else{
                if(afastaPlayer){
                    alvo = jogador.transform.position-new Vector3(0,0,distForaTela);
                    alvo.y=0;
                }
            }
        }
        if(transform.position.y>0.5f&&!pulando){
            animator.SetTrigger("Jumped");
            pulando=true;
        }
        if(transform.position.y<0.5f&&pulando){
            animator.ResetTrigger("Jumped");
            pulando=false;
        }
        Vector3 dir = alvo-transform.position;
        //if(afastaPlayer){
        //    transform.position=new Vector3(transform.position.x,1,transform.position.z);
        //}
        if(dir.magnitude>0.5f)
            transform.Translate(dir.normalized*speed*Time.deltaTime);
        
    }
    public void AproximarPlayer(){
        afastaPlayer=false;
        alcancaPlayer=false;
        aproximaPlayer=true;
    }
    public void AlcancarPlayer(){
        aproximaPlayer=false;
        afastaPlayer=false;
        alcancaPlayer=true;
    }
    public void AfastarPlayer(){
        aproximaPlayer=false;
        alcancaPlayer=false;
        afastaPlayer=true;
    }
    
}
