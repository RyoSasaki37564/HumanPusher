using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    /// <summary>
    /// ゲームを管理するコンポーネント。シングルトン パターンで作られている。
    /// 呼ぶ時は、SingletonSystem.Instance.（メソッド/プロパティ） のようにして呼ぶこと。
    /// </summary>
    /// <summary>インスタンスを取得するためのパブリック変数</summary>
    public static StatusManager Instance = default;

    [SerializeField] Text m_countJK = default;

    /// <summary></summary>
    int _score = 0;

    void Awake()
    {
        if (Instance)
        {
            // インスタンスが既にある場合は、破棄する
            Debug.LogWarning($"SingletonSystem のインスタンスは既に存在するので、{gameObject.name} は破棄します。");
            Destroy(this.gameObject);
        }
        else
        {
            // このクラスのインスタンスが無かった場合は、自分を DontDestroyOnload に置く
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// シーンがロードされた時に呼ぶ。
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

    }

    /// <summary>
    /// 得点を追加し、得点表示を更新する。
    /// </summary>
    /// <param name="score">追加する点数</param>
    public void AddScore(int score)
    {
        _score += score;
        m_countJK.text = _score.ToString("00000000");
    }
}
