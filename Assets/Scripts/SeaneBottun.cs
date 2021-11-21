using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaneBottun : MonoBehaviour
{
    bool flg = false;

    public void Swicher()
    {
        if(this.tag == "syuukaku")
        {
            SceneManager.LoadScene("CoinPusherProt");
        }
        else
        {
            SceneManager.LoadScene("Syuukaku");
        }
    }

}
