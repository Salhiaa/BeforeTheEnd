using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource BruitDePas;
    public AudioSource ChemineeAllumee;
    public AudioSource Cle;
    public AudioSource Crow1;
    public AudioSource Crow2;
    public AudioSource FeuTorche;
    public AudioSource Grincements;
    public AudioSource Jump;
    public AudioSource OuverturePorte;
    public AudioSource PlantGrow;
    public AudioSource UseTorche;
    public AudioSource Vision;
    public AudioSource Water;
    public AudioSource Dialogue;

    public void PlayBruitDePas()
    {
        BruitDePas.Play();
    }
    public void PlayChemineeAllumee()
    {
        ChemineeAllumee.Play();
    }
    public void PlayCle()
    {
        Cle.Play();
    }
    public void PlayCrow1()
    {
        Crow1.Play();
    }
    public void PlayCrow2()
    {
        Crow2.Play();
    }
    public void PlayFeuTorche()
    {
        FeuTorche.Play();
    }
    public void PlayGrincements()
    {
        Grincements.Play();
    }
    public void PlayJump()
    {
        Jump.Play();
    }
    public void PlayOuverturePorte()
    {
        OuverturePorte.Play();
    }
    public void PlayPlantGrow()
    {
        PlantGrow.Play();
    }
    public void PlayUseTorche()
    {
        UseTorche.Play();
    }
    public void PlayVision()
    {
        Vision.Play();
    }
    public void PlayWater()
    {
        Water.Play();
    }
    public void PlayDialogue()
    {
        Dialogue.Play();
    }


}
