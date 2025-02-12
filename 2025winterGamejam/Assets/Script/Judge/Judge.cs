using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public Enemy_Card enemy_card;
    public Player_Card player_card;
    public bool win_flag = false;
    public bool lose_flag = false;
    // Start is called before the first frame update
    void Start()
    {
        win_flag = false;
        lose_flag = false;
    }

    public void Judgement()
    {
        
    }
}
