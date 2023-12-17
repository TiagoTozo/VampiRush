using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioSource coletaMoeda;
    public AudioSource gritoInicio;
    public AudioSource trocaFaixa;
    public AudioSource gritoMorte;
    public AudioSource musicaFundo;
    public AudioSource tomaDano;
    public AudioClip[] musicas;
    public Slider sliderMusic,sliderSFX,sliderMaster;//precisam ter valor de -30 até 0
    string sfx = "SFXVol", master = "MasterVol", music = "MusicVol";//nome da variavel exposed
    void Awake(){
        
    }
    void Start(){
       // GameController.gameController.audioController=this;
        AjustaSliders();
    }
    public void SetVolumeMaster(){
        if(sliderMaster.value<-29f)
            audioMixer.SetFloat(master,-80f);
        else
            audioMixer.SetFloat(master,sliderMaster.value);
    }
    public void SetVolumeMusic(){
        if(sliderMusic.value<-29f)
            audioMixer.SetFloat(music,-80f);
        else
            audioMixer.SetFloat(music,sliderMusic.value);
    }
    public void SetVolumeSFX(){
        if(sliderSFX.value<-29f)
            audioMixer.SetFloat(sfx,-80f);
        else
            audioMixer.SetFloat(sfx,sliderSFX.value);
    }
    public void AjustaSliders(){
        float vol;
        if(sliderMaster!=null){
            audioMixer.GetFloat(master,out vol);
            sliderMaster.value=vol;
        }
        if(sliderMusic!=null){
            audioMixer.GetFloat(music,out vol);
            sliderMusic.value=vol;
        }
        if(sliderSFX!=null){
            audioMixer.GetFloat(sfx,out vol);
            sliderSFX.value=vol;
        }
    }
}

