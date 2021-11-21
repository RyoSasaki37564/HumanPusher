using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;

    [SerializeField] Text m_jkCountText = default; //現在保有するJKの数の表示

    [SerializeField] TextAsset m_ExpCsv = default; //経験値テーブル
    StringReader m_stR;
    int[,] m_table = new int[30, 3]; //とりあえず30レベル最大。内容はレベル、保有可能経験値、経験値累積和。

    [SerializeField] Slider m_expSlider = default; //経験値バー
    [SerializeField] Text m_levelText = default; //レベル表記

    public int m_jkCount; //JKの数

    public int m_level = 1; //現在のレベル

    int m_exp = 0;

    private void Awake()
    {
        if (Instance)
        {
            //すでにゲームマネージャーがあれば破棄。
            Destroy(this.gameObject);
        }
        else
        {
            //ゲーム起動時にはゲームマネージャーを生成。
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            //レベルテーブルからレベリングデータを作成
            m_stR = new StringReader(m_ExpCsv.text);
            string iranaiBubun = m_stR.ReadLine(); //1行目はデータじゃないから読み捨てしますよん。
            if (m_stR != null)
            {
                for (var i = 0; i < 30; i++)
                {
                    var line = m_stR.ReadLine(); //2行目からデータを読み込む。
                    string[] m_Status = line.Split(',');

                    m_table[i, 0] = int.Parse(m_Status[0]); //そして見込んだデータは２次元配列化。
                    m_table[i, 1] = int.Parse(m_Status[1]);
                    m_table[i, 2] = int.Parse(m_Status[2]);
                }
            }

            m_expSlider.maxValue = m_table[0, 1];
            m_expSlider.value = 0;
            m_levelText.text = "Lv. " + m_level.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_jkCountText.text = "JK：" + m_jkCount.ToString("00000000");
        m_expSlider = FindObjectOfType<Slider>().GetComponent<Slider>();
    }

    void Update()
    {
        if (m_level != 30 && m_exp >= m_table[m_level, 2]) //レベルアップ処理。次のレベルの経験値累積和と所持経験値が等しくなったら
        {
            m_level++;
            m_expSlider.value = 0;
            m_expSlider.maxValue = m_table[m_level - 1, 1];
            m_levelText.text = "Lv. " + m_level.ToString();
        }
    }

    public void AddEXP()
    {
        m_exp++;
        m_expSlider.value++;
    }

    public void AddScore(int score)
    {
        m_jkCount += score;
        m_jkCountText.text = "JK：" + m_jkCount.ToString("00000000");
    }
}
