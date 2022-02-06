using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFon : MonoBehaviour
{
    public bool musicControl;

    // Start is called before the first frame update
    void Start()
    {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Music");
    }
}
