using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random=UnityEngine.Random;


public class Pista : MonoBehaviour
{
    [SerializeField] public static float speed = 4f;//quando isso estiver definido mudar pra pegar esse valor do GC
    public static int nPistas;
    static Pista ultimaPista;
    public int tipo; //1 tem 2 fileiras de obstaculos e 2 tem 3 fileiras
    public GameObject OutraPista;
    
    public GameObject [] obstaculos;
    public GameObject[] spawnPoints;
    public GameObject[] spawnPowerUps;
    public GameObject inicioProxPista;
    public GameObject moeda;
    public GameObject[] spawnMoedas;
    public GameObject[] powerUps;
    float valorFileira;
    // Start is called before the first frame update
    void Start()
    {
        valorFileira=GameController.gameController.valorFileira;
        ultimaPista = this;
        for(int i=0;i<spawnPoints.Length;i++){
            Instantiate(obstaculos[Random.Range(0,obstaculos.Length)],spawnPoints[i].transform);
        }
        for(int i=0;i<spawnMoedas.Length;i++){
            if(Random.Range(0,2)==0){
                Instantiate(moeda,spawnMoedas[i].transform);
            }
        }
        SpawnPowerUp();
        SpawnaPista();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back*speed*Time.deltaTime);
    }
    public void SpawnaPista(){
        if(nPistas<5){
            GameObject novaPista = Instantiate(OutraPista,inicioProxPista.transform);
            novaPista.transform.SetParent(null);
            nPistas++;
        }
    }
    void OnTriggerEnter(Collider collider){
        Debug.Log("Colidi");
        if(collider.CompareTag("Barreira")){
            Destroy(gameObject);
            nPistas--;
            ultimaPista.SpawnaPista();
        }
    }
    void SpawnPowerUp(){
        if(Random.Range(0,20)<5){
            int lugar = Random.Range(0,spawnPowerUps.Length);
            int powerUp = Random.Range(0,powerUps.Length);
            Instantiate(powerUps[powerUp],spawnPowerUps[lugar].transform);
        }
    }
}
