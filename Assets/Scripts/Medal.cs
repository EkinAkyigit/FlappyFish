using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Sprite bronze, silver, gold;

    Image img;

    private void Update()
    {
        img = GetComponent<Image>();
        int gamescore = GameManager.gameScore; 

        if(gamescore >= 0 && gamescore <= 5)
            img.sprite = bronze;
        else if(gamescore >= 6 && gamescore <= 15)
            img.sprite = silver;
        else img.sprite = gold;
    }
}
