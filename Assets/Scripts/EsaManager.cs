﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsaManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.AddScore(1);
            Destroy(this.gameObject);
        }
    }
}
