using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContllore : MonoBehaviour
{
    Rigidbody m_rb = default;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.AddForce(this.gameObject.transform.forward*10, ForceMode.Impulse);
    }
}
