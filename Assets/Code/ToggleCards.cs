using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCards : MonoBehaviour
{
    [SerializeField] RawImage leftImg;
    [SerializeField] RawImage rightImg;


    [SerializeField] List<Texture> textures = new List<Texture>();

    int current = 0;

    public void DoThing(int dir)
    {
        current += dir;
        if (current >= textures.Count) current = 0;
        if (current < 0) current = textures.Count - 1;
        leftImg.texture = textures[current];
        int newCur = current + 1;
        if (newCur >= textures.Count) newCur = 0;
        rightImg.texture = textures[newCur];
    }
}
