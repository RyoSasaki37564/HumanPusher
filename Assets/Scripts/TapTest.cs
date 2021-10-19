using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; // 追加
using UnityEngine;

public class TapTest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject m_genePos = default; //コイン生成位置

    [SerializeField] GameObject m_coin = default; //コイン

    private bool _isTouched = false; // タッチ検出有無

    private Vector3 _prevTouchPosi; // 前回検出時のタッチ座標（ワールド座標）

    private int _touchIndex = 0;  // タッチ情報のindex

    
    // Update is called once per frame
    void Update()
    {
        Touch touchinfo;
        Vector3 nowposi;
        Vector3 diff;

        if (_isTouched)
        {
            touchinfo = Input.GetTouch(_touchIndex);
            if (touchinfo.phase != TouchPhase.Ended && touchinfo.phase != TouchPhase.Canceled)
            {
                // タッチ終了、キャンセル以外はオブジェクトを動かす
                // 新しいタッチ位置の座標取得
                nowposi = Camera.main.ScreenToWorldPoint(touchinfo.position);

                // 前回保存の位置から差分を取得
                diff = nowposi - _prevTouchPosi;

                // 自身のオブジェクトに差分を追加して移動
                GetComponent<Transform>().position += diff;

                // 前回の位置を更新
                _prevTouchPosi = nowposi;
            }
            else
            {
                // タッチ終了、キャンセルはオブジェクトを離す
                _isTouched = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Touch taouchinfo;
        Ray ray;
        RaycastHit[] hits = new RaycastHit[10]; // Rayがヒットするオブジェクトを格納

        int hitNum;

        Debug.Log("Down" + GetComponent<Transform>().name);

        for (int i = 0; i < Input.touchCount; i++)
        {
            // タッチ数分、タッチ情報を確認する
            taouchinfo = Input.GetTouch(i);

            // タッチ情報の座標からRayを生成する
            ray = Camera.main.ScreenPointToRay(taouchinfo.position);

            // Rayがヒットしているオブジェクトを検索する
            hitNum = Physics.RaycastNonAlloc(ray, hits);

            for (int j = 0; j < hitNum; j++)
            {
                // hitを検索して自身のBoxColliderにヒットしていれば、このタッチで
                // ハンドラが実行されたと判断する
                if (hits[j].collider == GetComponent<BoxCollider>())
                {
                    // タッチ情報のindex保存
                    _touchIndex = i;
                    // タッチが発生した
                    _isTouched = true;
                    // 検出したタッチの座標をワールド座標に変換し保存
                    _prevTouchPosi = Camera.main.ScreenToWorldPoint(taouchinfo.position);
                    break;
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Vector3 m_pos = new Vector3(_prevTouchPosi.x, m_genePos.transform.position.y, m_genePos.transform.position.z);
        Debug.Log("Up" + GetComponent<Transform>().name);
        Instantiate(m_coin,m_pos, m_genePos.transform.rotation);
    }
}