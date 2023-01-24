using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] UnityEvent timeEnd;

    [SerializeField] Text nameText;
    [SerializeField] Text winsText;
    [SerializeField] Text LossText;
    [SerializeField] Text winstreakText;
    [SerializeField] RawImage profileImg;
    [SerializeField] Texture textureToApply;
    [SerializeField] GameObject foundMatch;

    float timer = float.MaxValue;

    public void DoActivate()
    {
        timer = 4;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            FoundMatch();
            //timer = float.MaxValue;
        }
        if(timer <= -1.5f)
        {
            foundMatch.SetActive(false);
        }

        if(timer <= -4)
        {
            timeEnd?.Invoke();
            timer = float.MaxValue;
        }
    }

    public void FoundMatch()
    {
        profileImg.texture = textureToApply;
        winsText.text = "98";
        LossText.text = "25";
        winstreakText.text = "18";
        nameText.text = "Peter";
        profileImg.color = Color.white;
        foundMatch.SetActive(true);
    }

    public void DoReset()
    {
        winsText.text = "";
        LossText.text = "";
        winstreakText.text = "";
        nameText.text = "Searching ↻";
        profileImg.texture = null;
        profileImg.color = Color.black;
        foundMatch.SetActive(false);
    }
}
