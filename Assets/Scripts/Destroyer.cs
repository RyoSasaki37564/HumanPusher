using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //触れたものを例外なく破壊してしまう悲しきモンスター。お前にこの苦しみが分かんのか？
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
