using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    public float speed = 1;
    //public Bullet script;
    public GameObject bullet;
    [SerializeField] private float _timeInterval;
    private float _timeElapsed;

    Vector3 bulletPoint;

    // ゲームのスタート時の処理
    void Start()
    {
        //rotEuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
        //bulletPoint = transform.Find("BulletPoint").localPosition;
        //Bullet = GameObject.Find("Bullet");
    }

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            /*-- 一定間隔で実行したい処理 --*/
            shot();
            // 経過時間を元に戻す
            _timeElapsed = 0f;
        }
    }

    public void shot()
    {
        //弾を出現させる位置を取得
        Vector3 placePosition = this.transform.position;
        //出現させる位置をずらす値
        Vector3 offsetGun = new Vector3(0, 0, 8);

        //武器の向きに合わせて弾の向きも調整
        Quaternion q1 = this.transform.rotation;
        //弾を90度回転させる処理
        Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Quaternion q = q1 * q2;

        //弾を出現させる位置を調整
        placePosition = q1 * offsetGun + placePosition;
        //弾生成！
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
