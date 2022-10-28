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

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        //rotEuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);
        //bulletPoint = transform.Find("BulletPoint").localPosition;
        //Bullet = GameObject.Find("Bullet");
    }

    // �Q�[�����s���̌J��Ԃ�����
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
            /*-- ���Ԋu�Ŏ��s���������� --*/
            shot();
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }
    }

    public void shot()
    {
        //�e���o��������ʒu���擾
        Vector3 placePosition = this.transform.position;
        //�o��������ʒu�����炷�l
        Vector3 offsetGun = new Vector3(0, 0, 8);

        //����̌����ɍ��킹�Ēe�̌���������
        Quaternion q1 = this.transform.rotation;
        //�e��90�x��]�����鏈��
        Quaternion q2 = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
        Quaternion q = q1 * q2;

        //�e���o��������ʒu�𒲐�
        placePosition = q1 * offsetGun + placePosition;
        //�e�����I
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
