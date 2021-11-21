using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;

    [SerializeField] Text m_jkCountText = default; //現在保有するJKの数の表示

    int m_jkCount; //JKの数

    private void Awake()
    {
        if(Instance)
        {
            //すでにゲームマネージャーがあれば破棄。
            Destroy(this.gameObject);
        }
        else
        {
            //ゲーム起動時にはゲームマネージャーを生成。
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        m_jkCount += score;
        m_jkCountText.text = m_jkCount.ToString("00000000");
    }
}
