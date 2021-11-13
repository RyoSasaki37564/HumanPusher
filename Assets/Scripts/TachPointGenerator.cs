using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TachPointGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_human = default; //降らせる人間
    [SerializeField] GameObject m_genePos = default; //降らせる位置

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(m_human, new Vector3(hit.point.x,m_genePos.transform.position.y,m_genePos.transform.position.z),m_genePos.transform.rotation);
            }
        }
    }
}
