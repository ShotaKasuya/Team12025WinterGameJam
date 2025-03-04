using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class OnlyBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGMManager.Instance.Play(BGMPath.TITLE_BGM, 0.1f, 0, 1, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
