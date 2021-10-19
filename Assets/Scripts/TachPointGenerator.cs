using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TachPointGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_human = default; //降らせる人間

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(m_human, hit.point, Quaternion.identity);
            }
        }
    }
}
