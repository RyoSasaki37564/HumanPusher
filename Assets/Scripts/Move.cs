using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 25f;
    Rigidbody _rb = default;
    Animator _anim = default;
    Vector3 _dir = default;
    bool _isGrounded = true;
    [SerializeField] float _jumpSpeed = 3;

    [SerializeField] GameObject m_minusSetPos = default; //見えない壁を引く線の基準、マイナス側
    [SerializeField] GameObject m_plusSetPos = default; //見えない壁を引く線の基準、プラス側


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        // カメラのローカル座標系を基準に dir を変換する
        dir = Camera.main.transform.TransformDirection(dir);

        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        dir.y = 0;

        // 移動の入力がない時は回転させない。入力がある時はその方向にキャラクターを向ける。
        if (dir != Vector3.zero) this.transform.forward = dir;

        // 水平方向（XZ平面上）の速度を計算する
        dir = dir.normalized * _moveSpeed;

        // 垂直方向の速度を計算する
        float y = _rb.velocity.y;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            y = _jumpSpeed;
        }

        _rb.velocity = dir * _moveSpeed + Vector3.up * y;

        Mienaikabe();

    }

    void LateUpdate()
    {
        if (_dir != Vector3.zero)
        {
            this.transform.forward = _dir;
        }

        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (_anim)
        {
            _anim.SetFloat("Speed", forward.magnitude);
        }
    }

    void Mienaikabe()
    {
        //見えない壁
        if (this.gameObject.transform.position.x < m_minusSetPos.transform.position.x)
        {
            this.gameObject.transform.position = new Vector3(m_minusSetPos.transform.position.x, this.gameObject.transform.position.y,
                this.gameObject.transform.position.z);
        }
        else if (this.gameObject.transform.position.x > m_plusSetPos.transform.position.x)
        {
            this.gameObject.transform.position = new Vector3(m_plusSetPos.transform.position.x, this.gameObject.transform.position.y,
                this.gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.z < m_minusSetPos.transform.position.z)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                m_minusSetPos.transform.position.z);
        }
        else if (this.gameObject.transform.position.z > m_plusSetPos.transform.position.z)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,
                m_plusSetPos.transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Human")
        {
            Destroy(collision.gameObject);
        }
    }
}
