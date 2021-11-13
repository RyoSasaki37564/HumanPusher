using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsaGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_human = default; //降らせる人間
    [SerializeField] GameObject m_genePos = default; //降らせる位置

    [SerializeField] GameObject m_minusSetPos = default; //見えない壁を引く線の基準、マイナス側
    [SerializeField] GameObject m_plusSetPos = default; //見えない壁を引く線の基準、プラス側

    void Start()
    {
        for(var i = 0; i < 50; i++)
        {
            JKRain();
        }
        StartCoroutine(OyakataSorakaraJKga());
    }

    //親方！空から大量のJKが！
    IEnumerator OyakataSorakaraJKga()
    {
        yield return new WaitForSeconds(0.2f);
        JKRain();
        StartCoroutine(OyakataSorakaraJKga());
    }

    void JKRain()
    {
        float x = Random.Range(m_minusSetPos.transform.position.x, m_plusSetPos.transform.position.x);
        float z = Random.Range(m_minusSetPos.transform.position.z, m_plusSetPos.transform.position.z);
        Instantiate(m_human, new Vector3(x, m_genePos.transform.position.y, z), m_genePos.transform.rotation);
    }
}
