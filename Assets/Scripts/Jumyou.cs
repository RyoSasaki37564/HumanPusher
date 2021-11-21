using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumyou : MonoBehaviour
{
    [SerializeField] float m_jumyou = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeadTimer());
    }

    IEnumerator DeadTimer()
    {
        yield return new WaitForSeconds(m_jumyou);
        Destroy(this.gameObject);
    }
}
