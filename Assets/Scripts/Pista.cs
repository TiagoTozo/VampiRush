using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random=UnityEngine.Random;


public class Pista : MonoBehaviour
{
    [SerializeField] public static float speed = 5f;//quando isso estiver definido mudar pra pegar esse valor do GC
    public static int nPistas;
    public static Pista ultimaPista;
    public static bool trocaPista;
    public GameObject [] OutrasPistas;
    
    public GameObject [] obstaculos;
    public GameObject[] spawnPoints;
    public GameObject[] spawnPowerUps;
    public GameObject inicioProxPista;
    public GameObject moeda;
    public GameObject[] spawnMoedas;
    public GameObject[] powerUps;
    public int max_pistas;
    float valorFileira;
    
    // Start is called before the first frame update
    void Start()
    {
        valorFileira=GameController.gameController.valorFileira;
        ultimaPista = this;
        if(max_pistas==0)
            max_pistas=2;
        
        SpawnObstaculos();
        SpawnMoedas();
        SpawnPowerUp();
        SpawnaPista();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back*speed*Time.deltaTime);
        if(transform.position.z<=-15){
            Destroy(gameObject);
            nPistas--;
            ultimaPista.SpawnaPista();
        }
    }
    public void SpawnaPista(){
        if(trocaPista){
            GameObject novaPista = Instantiate(OutrasPistas[OutrasPistas.Length-1],inicioProxPista.transform);
            novaPista.transform.SetParent(null);
            nPistas++;
            trocaPista=false;
        }
        else{
            if(nPistas<max_pistas){
                GameObject novaPista = Instantiate(OutrasPistas[Random.Range(0,OutrasPistas.Length-1)],inicioProxPista.transform);
                novaPista.transform.SetParent(null);
                nPistas++;
            }
        }
    }
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Barreira")){
            Destroy(gameObject);
            nPistas--;
            ultimaPista.SpawnaPista();
        }
    }
    void SpawnPowerUp(){
        if(spawnPowerUps==null||powerUps==null)
            return;
        if(Random.Range(0,20)<5){
            int lugar = Random.Range(0,spawnPowerUps.Length);
            int powerUp = Random.Range(0,powerUps.Length);
            Instantiate(powerUps[powerUp],spawnPowerUps[lugar].transform);// adicionar rand no x
        }
    }
    void SpawnObstaculos(){
        if(spawnPoints==null)
            return;
        for(int i=0;i<spawnPoints.Length;i++){
            Instantiate(obstaculos[Random.Range(0,obstaculos.Length)],spawnPoints[i].transform);
        }
    }
    void SpawnMoedas(){
        if(spawnMoedas==null)
            return;
        for(int i=0;i<spawnMoedas.Length;i++){
            if(Random.Range(0,2)==0){
                Instantiate(moeda,spawnMoedas[i].transform);
            }
        }
    }
    public static void TrocaTipoPista(){
        trocaPista=true;
    }
    public static void Acelerar(){
        speed+=0.1f;
    }
}
