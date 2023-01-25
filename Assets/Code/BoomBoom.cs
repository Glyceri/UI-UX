using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoomBoom : MonoBehaviour
{

    [SerializeField] RawImage boom1;
    [SerializeField] RawImage boom2;

    [SerializeField] UnityEvent onEnd;
    [SerializeField] UnityEvent onEnd2;
    bool isActive = false;
    float timer = 0;

    public void DoReset()
    {
        isActive = false;
        timer = 0;
        boom1.gameObject.SetActive(false);
        boom2.gameObject.SetActive(false);
    }

    public void StartThing()
    {
        isActive = true;
        timer = 0;
    }


    private void Update()
    {
        if(isActive == true)
        {
            timer += Time.deltaTime;
            if (timer > 1) boom1.gameObject.SetActive(true);
            if (timer > 2) boom2.gameObject.SetActive(true);
            if (timer > 3.8f) onEnd?.Invoke();
            if (timer > 5.5f) onEnd2?.Invoke();
        }
    }



}
