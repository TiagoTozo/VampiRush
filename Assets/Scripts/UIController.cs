using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //paineis
    public GameObject painelDerrota,painelPausa;
    //bool dos paineis
    bool painelPausaOpen;
    void Start()
    {
        painelPausaOpen=false;
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

}
