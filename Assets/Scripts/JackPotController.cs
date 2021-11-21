using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JackPotController : MonoBehaviour
{
    [SerializeField] Text m_drumText = default;//ドラムロールの表示テキスト

    [SerializeField]List<int> m_drums = new List<int>();

    bool m_nowRolling = false; //現在ロール中か否か

    [SerializeField] GameObject m_jk = default; //盛大にお祝いしなくちゃなぁ!?
    [SerializeField] GameObject m_genePoint = default;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Human")
        {
            GameManager.Instance.AddEXP();
            GameManager.Instance.AddScore(1);
            DrumRoll();
        }
    }

    void DrumRoll()
    {
        //ドラムロール！
        for(var i = 0; i < m_drums.Count; i++)
        {
            m_drums[i] = Random.Range(1, 5);
        }
        m_drumText.text = $"[{m_drums[0]}] [{m_drums[1]}] [{m_drums[2]}]";
        if(m_drums[0] == m_drums[1] && m_drums[0] == m_drums[2])
        {
            Debug.Log("じゃっくぽっと");
            Instantiate(m_jk, m_genePoint.transform.position, m_genePoint.transform.rotation);
        }
    }
}
