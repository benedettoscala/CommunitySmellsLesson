﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RadioSilence : UdonSharpBehaviour
{
    public CloudThoughts[] teamCloudThoughts;
    public CloudThoughts managerCloudThoughts;
    public CloudThoughts secondManagerCloudThoughts;

    public Animator managerAnimator;
    public Animator secondManagerAnimator;

    public Animator[] teamMembersAnimators;
    
    public CloudThoughts giuliaCloudThoughts;
    public Animator giuliaAnimator;

    public Walking walkingGiuliaScript;
    public Walking walkingSecondManagerScript;

    void Start()
    {
        // Assegna questo script come eventReceiver per gli script Walking
        if (walkingGiuliaScript != null)
        {
            walkingGiuliaScript.eventReceiver = this;
        }
        if (walkingSecondManagerScript != null)
        {
            walkingSecondManagerScript.eventReceiver = this;
        }
    }

    private int _synchronizedVariable = 0;

    private int synchronizedVariable
    {
        get => _synchronizedVariable;
        set
        {
            _synchronizedVariable = value;
            HandleStateChange(value);
        }
    }

    private void HandleStateChange(int state)
    {
        switch (state)
        {
            case 1:
                HandleStartState();
                break;
            case 2:
                PointToGiuliaState();
                break;
        }
    }

    private void SetAllTeamAnimations(int value)
    {
        foreach (var animator in teamMembersAnimators)
        {
            animator.SetInteger("animVal", value);
        }
    }

    private void HandleStartState()
    {
        managerCloudThoughts.JollyCooperationThought();
        secondManagerCloudThoughts.JollyCooperationThought();

        managerAnimator.SetInteger("animVal", 0);
        secondManagerAnimator.SetInteger("animVal", 0);
        SetAllTeamAnimations(0);
        giuliaAnimator.SetInteger("animVal", 0);

        giuliaCloudThoughts.NoThought();
    }

    private void PointToGiuliaState()
    {
        giuliaAnimator.SetInteger("animVal", 1);
        walkingGiuliaScript.StartWalking(1);

        walkingSecondManagerScript.StartWalking(1);
        secondManagerAnimator.SetInteger("animVal", 1);
    }

    public void metodo1()
    {
        synchronizedVariable = 1;
    }

    public void metodo2()
    {
        synchronizedVariable = 2;
    }

    // Metodi per gestire gli eventi dello script Walking per Giulia
    public void OnStartWalking()
    {
        Debug.Log("Un personaggio ha iniziato a camminare");
        // Determinare quale personaggio ha iniziato a camminare
        if (walkingGiuliaScript.isWalking)
        {
            OnGiuliaWalking();
        }
        else if (walkingSecondManagerScript.isWalking)
        {
            OnSecondManagerWalking();
        }
    }

    public void OnStopWalking()
    {
            Debug.Log("Un personaggio si è fermato");
            if (!walkingGiuliaScript.isWalking)
            {
                OnGiuliaWaiting();
            }
            else if (!walkingSecondManagerScript.isWalking)
            {
                OnSecondManagerWaiting();
            }
            // La logica per determinare quale personaggio si è fermato potrebbe essere più complessa
            // e potrebbe richiedere variabili aggiuntive per tracciare lo stato di ciascun personaggio
    }

    public void OnWaiting()
    {
        Debug.Log("Un personaggio sta aspettando a un punto di camminata");
        // Determinare quale personaggio sta aspettando
        if (!walkingGiuliaScript.isWalking)
        {
            OnGiuliaWaiting();
        }
        else if (!walkingSecondManagerScript.isWalking)
        {
            OnSecondManagerWaiting();
        }
    }

    public void OnWalkingComplete()
    {
        Debug.Log("Un personaggio ha completato il percorso");
        Debug.Log(!walkingSecondManagerScript.isWalking);
        // Determinare quale personaggio ha completato il percorso
        if (!walkingGiuliaScript.isWalking)
        {
            OnGiuliaWalkingComplete();
        }
        // questa cosa se ci fosse più gente non funzionerebbe
        OnSecondManagerWalkingComplete();
    }

    // Metodi specifici per Giulia
    private void OnGiuliaWalkingComplete()
    {
        //giuliaAnimator.SetInteger("animVal", 0);
    }

    private void OnGiuliaWaiting()
    {
        giuliaAnimator.SetInteger("animVal", 0);
    }

    private void OnGiuliaWalking()
    {
        giuliaAnimator.SetInteger("animVal", 1);
    }

    // Metodi specifici per SecondManager
    private void OnSecondManagerWalkingComplete()
    {
        Debug.Log("SecondManager ha completato il percorso");
        secondManagerAnimator.SetInteger("animVal", 0);
    }

    private void OnSecondManagerWaiting()
    {
        secondManagerAnimator.SetInteger("animVal", 0);
    }

    private void OnSecondManagerWalking()
    {
        secondManagerAnimator.SetInteger("animVal", 1);
    }
}