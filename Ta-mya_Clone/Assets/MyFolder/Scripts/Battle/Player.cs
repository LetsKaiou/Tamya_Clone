using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �ړ����x���i�[����ϐ�
    public float speed = 1;
    // HP
    public int hp;
    // �e�̔��ˊԊu
    [SerializeField] private float _timeInterval;
    // �o�ߎ��Ԏ擾�p�ϐ�
    private float _timeElapsed;
    // �}�E�X�z�C�[���̉�]���擾�p�ϐ�
    private float MousWheel;
    // ����U���p�o�ߎ��Ԋi�[�ϐ�
    private float SkillTime;
    // ����U���̃N�[���^�C��
    [SerializeField] private float SkillInterval;
    // ����U���I��p�ϐ�
    private int BulletSelect;
    // ����U���̒e�̃v���t�@�u�i�[
    //[SerializeField] private List<GameObject> BulletList = new List<GameObject>();
    [SerializeField] private GameObject[] Bullet;
    // ����U���̒e���Ƃ̃N�[���^�C���m�F�i�[�p
    private List<bool> Reload = new List<bool>();
    Vector3 bulletPoint;


    void Start()
    {
        // List�ɏ���ǉ�(ture:���ˉ\�Afalse:�N�[���^�C����)
        Reload.Add(true);   // ����U��1
        Reload.Add(true);   // ����U��2
        Reload.Add(true);   // ����U��3
        Reload.Add(true);   // ����U��4
        Debug.Log(Reload.Count);
    }

    void Update()
    {
        // �ړ�����
        #region �ړ�
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
        #endregion

        // ����U���I������
        #region ����U��
        // �}�E�X�̉�]���擾(��]�����邽�т�1���������� �f�t�H���g��0)
            MousWheel += Input.GetAxis("Mouse ScrollWheel");
            MousWheel = Mathf.Floor(MousWheel);
            MousWheel = Mathf.Clamp(MousWheel, 0.0f, 4.0f);
        #endregion

        // �e����
        #region �e�̔���
        _timeElapsed += Time.deltaTime;

        if (_timeElapsed > _timeInterval)
        {
            shot();
            // �o�ߎ��Ԃ����ɖ߂�
            _timeElapsed = 0f;
        }
        #endregion
        // ����U���̒e�I�������Ɣ��ˏ����ւ̈ړ�(�}�E�X���N���b�N�Ŕ���)
        if(MousWheel > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(MousWheel);
                BulletSelect = (int)MousWheel;
                if (Reload[BulletSelect - 1] == true)
                {
                    SpecialAttack(BulletSelect);
                }
            }
        }
    }

    // �ʏ�e���ˏ����֐�
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
        //�e����
        Instantiate(Bullet[0], transform.position, transform.rotation);
    }

    // ����U�������֐�(�����͔��˂������U���̒e�̎��)
    public void SpecialAttack(int BulletSelection)
    {
        // ���ˌ�false�ɕύX
        Reload[BulletSelect - 1] = false;

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
        //�e����
        Instantiate(Bullet[BulletSelection], placePosition, Quaternion.identity);
        
        // �N�[���^�C���J�n
        StartCoroutine(CoolTime());
    }

    // �N�[���^�C�������R���[�`��
    private IEnumerator CoolTime()
    {
        // �N�[���^�C���J�n
        //Debug.Log("�N�[���^�C���J�n");

        // �ҋ@����
        yield return new WaitForSeconds(2);

        // false �� true�ɕύX
        Reload[BulletSelect - 1] = true;
        //Debug.Log("�N�[���^�C���I��");
    }
}

