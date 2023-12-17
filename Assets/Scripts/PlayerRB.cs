using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRB : MonoBehaviour
{
    //Tirar essas porras de UI daqui depois
    public Text textoTimer;
    int fileira;
    Rigidbody rb;
    [SerializeField] float pulo;
    float valorFileira;
    bool isPulando;
    bool podeMorrer;
    bool isInvulnevel;
    float tempoMorte = 10f;
    float timer =0;
    float timerTroca=0, timerVelocidade=0;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    public bool canInput;
    public float timerIma,tempoIma;
    public bool imaAtivo;
    public float timerCapa,tempoCapa;
    public bool capaAtiva;
    public float timerAlho,tempoAlho;
    public bool alhoAtivo;
    public AudioController audioController;
    int contadorClicks;

    public GameObject carmilleChild;
    Animator animator;
       
    void Start()
    {
        timerIma=tempoIma=GameController.gameController.DuracaoIma;
        timerCapa=tempoCapa=GameController.gameController.DuracaoCapa;
        timerAlho=tempoAlho=GameController.gameController.DuracaoAlho;
        GameController.gameController.jogador=this;
        imaAtivo=false;
        alhoAtivo=false;
        capaAtiva=false;
        valorFileira=GameController.gameController.valorFileira;
        canInput=true;
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
        podeMorrer=false;
        isPulando=false;
        fileira=0;
        rb=GetComponent<Rigidbody>();
        if(rb==null){
            Debug.LogError("Personagem sem rigidbody");
        }
        animator=carmilleChild.GetComponent<Animator>();
        if(animator==null){
            Debug.LogError("Personagem sem animator");
        }
        audioController.gritoInicio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer-timerTroca>=30){
            timerTroca=timer;
            Pista.TrocaTipoPista();
        }
        if(timer-timerVelocidade>=10){
            timerVelocidade=timer;
            Pista.Acelerar();
        }
        textoTimer.text= (timer/200f).ToString("F3")+" Km";
        
        
        //timer Ima
        if(imaAtivo){
            if(timerIma>0){
                timerIma-=Time.deltaTime;
            }
            else{
                imaAtivo=false;
                timerIma=tempoIma;
            }
        }
        //timer Alho
        if(alhoAtivo){
            if(timerAlho>0){
                timerAlho-=Time.deltaTime;
            }
            else{
                alhoAtivo=false;
                timerAlho=tempoAlho;
            }
        }
        //timer Capa
        if(capaAtiva){
            if(timerCapa>0){
                timerCapa-=Time.deltaTime;
            }
            else{
                capaAtiva=false;
                timerCapa=tempoCapa;
            }
        }
        
        
        #if UNITY_EDITOR
        if(canInput){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(!isPulando){
                    rb.AddForce(Vector3.up*pulo,ForceMode.Impulse);
                    isPulando=true;
                    animator.SetTrigger("Jumped");
                }
            }
            if(Input.GetKeyDown(KeyCode.A)){
                if(fileira==-1){
                    ;
                }
                else{
                    if(fileira==0){
                        fileira=-1;
                        rb.Move(new Vector3(-valorFileira,transform.position.y,0),Quaternion.identity);
                        audioController.trocaFaixa.Play();
                    }
                    else{
                        fileira=0;
                        rb.Move(new Vector3(0,transform.position.y,0),Quaternion.identity);
                        audioController.trocaFaixa.Play();
                    }
                }
            }
            if(Input.GetKeyDown(KeyCode.D)){
                if(fileira==1){
                    ;
                }
                else{
                    if(fileira==0){
                        fileira=1;
                        rb.Move(new Vector3(valorFileira,transform.position.y,0),Quaternion.identity);
                        audioController.trocaFaixa.Play();
                    }
                    else{
                        fileira=0;
                        rb.Move(new Vector3(0,transform.position.y,0),Quaternion.identity);
                        audioController.trocaFaixa.Play();
                    }
                }
            }
        }
        #endif
        #if UNITY_ANDROID
        if(canInput){
            if (Input.touchCount == 1) // user is touching the screen with a single touch
            {
                Touch touch = Input.GetTouch(0); // get the touch
                if (touch.phase == TouchPhase.Began) //check for the first touch
                {
                    fp = touch.position;
                    lp = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
                {
                    lp = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
                {
                    lp = touch.position;  //last touch position. Ommitted if you use list
    
                    //Check if drag distance is greater than 20% of the screen height
                    if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                    {//It's a drag
                     //check if the drag is vertical or horizontal
                        if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                        {   //If the horizontal movement is greater than the vertical movement...
                            if ((lp.x > fp.x))  //If the movement was to the right)
                            {   
                                if(fileira==1){
                                    ;
                                }
                                else{
                                    if(fileira==0){
                                        fileira=1;
                                        rb.Move(new Vector3(valorFileira,transform.position.y,0),Quaternion.identity);
                                        audioController.trocaFaixa.Play();
                                    }
                                    else{
                                        fileira=0;
                                        rb.Move(new Vector3(0,transform.position.y,0),Quaternion.identity);
                                        audioController.trocaFaixa.Play();
                                    }
                                }
                            }
                            else
                            {   
                                if(fileira==-1){
                                    ;
                                }
                                else{
                                    if(fileira==0){
                                        fileira=-1;
                                        rb.Move(new Vector3(-valorFileira,transform.position.y,0),Quaternion.identity);
                                        audioController.trocaFaixa.Play();
                                    }
                                    else{
                                        fileira=0;
                                        rb.Move(new Vector3(0,transform.position.y,0),Quaternion.identity);
                                        audioController.trocaFaixa.Play();
                                    }
                                }
                            }
                        }
                        else
                        {   //the vertical movement is greater than the horizontal movement
                            if (lp.y > fp.y)  //If the movement was up
                            {   //Up swipe
                                if(!isPulando){
                                    rb.AddForce(Vector3.up*pulo,ForceMode.Impulse);
                                    isPulando=true;
                                }
                            }
                            else
                            {   //Down swipe
                                Debug.Log("Down Swipe");
                            }
                        }
                    }
                    else
                    {   //It's a tap as the drag distance is less than 20% of the screen height
                        Debug.Log("Tap");
                    }
                }
            }
            if(Input.touchCount==5){
                Touch touch = Input.GetTouch(4);
                if(touch.phase == TouchPhase.Began){
                    if(!isInvulnevel){
                        isInvulnevel=true;
                        GameController.gameController.uiController.FicaInvulneravel(true);
                    }
                    else{
                        isInvulnevel=false;
                        GameController.gameController.uiController.FicaInvulneravel(false);
                    }
                }
            }
            if(Input.touchCount==4){
                Touch touch = Input.GetTouch(3);
                if(touch.phase == TouchPhase.Began){
                    isInvulnevel=true;
                    TrocaPistaDebug();
                }
            }
        }
        #endif
    }
    void OnCollisionEnter(Collision colisao){
        if(colisao.collider.CompareTag("Chao")){
            isPulando=false;
            animator.ResetTrigger("Jumped");
        }
    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Obstaculo")){
            //Debug.Log("bati num obstaculo");
            if(!podeMorrer){
                if(GameController.gameController.canVibrate)
                    Handheld.Vibrate();
                TomarHit();
                animator.SetTrigger("tookDamage");
            }
            else{
                if(!alhoAtivo){
                    Perder();
                    animator.SetTrigger("Died");
                }
            }
        }
    }
    
    void TomarHit(){
        if(!isInvulnevel){
            podeMorrer=true;
            audioController.tomaDano.Play();
        }
        Invoke("RestauraVida",tempoMorte);
        //rb.constraints=RigidbodyConstraints.FreezePositionY;
        //rb.detectCollisions=false;
        //Invoke("VoltaAColidir",2f);
        GameController.gameController.vampiro.AproximarPlayer();
    }
    void RestauraVida(){
        podeMorrer=false;
        animator.ResetTrigger("tookDamage");
        GameController.gameController.vampiro.AfastarPlayer();
    }
    void VoltaAColidir(){
        //rb.constraints=RigidbodyConstraints.None;
        rb.constraints=RigidbodyConstraints.FreezeRotation;
        rb.detectCollisions=true;
    }
    void Perder(){
        canInput=false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        animator.applyRootMotion=true;
        audioController.tomaDano.Play();
        audioController.gritoMorte.Play(44100);
        GameController.gameController.vampiro.AlcancarPlayer();
        GameController.gameController.Perder();
    }
    public void AtivarIma(){
        imaAtivo=true;
    }
    public void AtivarCapa(){
        capaAtiva=true;
    }
    public void AtivarAlho(){
        alhoAtivo=true;
    }
    public void TrocaPistaDebug(){
        timerTroca=timer;
        Pista.TrocaTipoPista();
    }
    public void Reset(){
        canInput=true;
        animator.applyRootMotion=false;
        animator.SetTrigger("Reset");
        RestauraVida();
        VoltaAColidir();
        AtivarAlho();
        transform.position=new Vector3(0,0.181f,0);
        transform.rotation= Quaternion.identity;
        transform.localScale=new Vector3(1.2f,1.2f,1.2f);
        carmilleChild.transform.position=new Vector3(0,0,0);
        carmilleChild.transform.rotation= Quaternion.identity;
    }
}
