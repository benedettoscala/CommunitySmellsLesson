﻿
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class CloudThoughts : UdonSharpBehaviour
{
    public RawImage cloud;
    public TextMeshProUGUI text;
    public RawImage angryFace;
    public RawImage happyFace;
    public RawImage sadFace;
    public RawImage thinkingFace;
    public RawImage dizzyFace;

    public RawImage thinkingCloud;

    public RawImage muteFace;

    public Image dontCareMeme;

    public Image questionMark;

    public Image jollyCooperation;

    public bool upAndDown = false;

    public float speed = 2.0f; // Velocità di movimento
    public float height = 1.0f; // Altezza massima del movimento

    private Vector3 startPos;


    void Start()
    {
        dontCareMeme.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        startPos = transform.position; // Salva la posizione iniziale
    }

    void Update()
    {
        //la cloud è sempre rivolta verso il player
        transform.LookAt(Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position);
        if (upAndDown) {
            //fai muovere la cloud su e giù
            float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
            transform.position = new Vector3(startPos.x, newY, startPos.z);
        }
        
    }

    //make a thought
    public void AngryThought()
    {
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(true);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);
        muteFace.gameObject.SetActive(false);
        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void HappyThought()
    {
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(true);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);
        muteFace.gameObject.SetActive(false);
        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void SadThought()
    {
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(true);
        thinkingFace.gameObject.SetActive(false);
        muteFace.gameObject.SetActive(false);
        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void ThinkingThought()
    {
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(true);
        muteFace.gameObject.SetActive(false);
        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void NoThought()
    {
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);
        muteFace.gameObject.SetActive(false);
        thinkingCloud.gameObject.SetActive(false);
        cloud.gameObject.SetActive(false);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void DizzyThought()
    {
        dizzyFace.gameObject.SetActive(true);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);
        muteFace.gameObject.SetActive(false);
        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void MuteThought()
    {
        muteFace.gameObject.SetActive(true);
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);

        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(false);
    }


    public void QuestionThought()
    {
        muteFace.gameObject.SetActive(false);
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);

        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(true);
        jollyCooperation.gameObject.SetActive(false);
    }

    public void JollyCooperationThought()
    {
        muteFace.gameObject.SetActive(false);
        dizzyFace.gameObject.SetActive(false);
        angryFace.gameObject.SetActive(false);
        happyFace.gameObject.SetActive(false);
        sadFace.gameObject.SetActive(false);
        thinkingFace.gameObject.SetActive(false);

        thinkingCloud.gameObject.SetActive(true);
        questionMark.gameObject.SetActive(false);
        jollyCooperation.gameObject.SetActive(true);
    }
    
    public void setDontCareMeme(bool active)
    {
        //deactivate everything besides the dont care meme
        dontCareMeme.gameObject.SetActive(active);
    }
    
    public void setText(string t)
    {
        
        text.gameObject.SetActive(true);
        text.text = t;
    }

    public void activateText()
    {
        text.gameObject.SetActive(true);
    }

    public void deactivateText()
    {
        text.gameObject.SetActive(false);
    }
}
