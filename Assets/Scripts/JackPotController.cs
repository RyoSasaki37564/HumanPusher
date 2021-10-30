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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Human")
        {
            DrumRoll();
        }
    }

    void DrumRoll()
    {
        //ドラムロール！
        for(var i = 0; i < m_drums.Count; i++)
        {
            m_drums[i] = Random.Range(0, 7);
        }
        m_drumText.text = $"[{m_drums[0]}] [{m_drums[1]}] [{m_drums[2]}]";
        if(m_drums[0] == m_drums[1] && m_drums[0] == m_drums[2])
        {
            Debug.Log("じゃっくぽっと");
        }
    }
}
