using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraSizer : MonoBehaviour
{
    [SerializeField] GameObject[] m_camera = new GameObject[2];

    int i = 1;

    public void CameraChange()
    {
        i++;
        if(i % 2 == 0)
        {
            m_camera[1].SetActive(true);
            m_camera[0].SetActive(false);
        }
        else
        {
            m_camera[0].SetActive(true);
            m_camera[1].SetActive(false);
        }
    }
}