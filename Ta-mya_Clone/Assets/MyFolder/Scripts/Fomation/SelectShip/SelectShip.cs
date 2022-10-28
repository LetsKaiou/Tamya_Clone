using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectShip : MonoBehaviour
{

    // static�ϐ��錾
    public static string[] SelectShipNum = new string[4];
    // �I�����ꂽ�@�̂̐��J�E���g�p
    public int Count;
    // �{�^���đI���J�E���g�p
    private int DisCount;
    // �{�^���i�[�p
    [SerializeField] private Button[] buttun;
    // image�i�[�p
    [SerializeField] private Image[] image;
    // image�ɓ����摜�i�[�p
    [SerializeField] private Sprite[] sprite;
    // Outline�i�[
    [SerializeField] private Animator[] animator;
    // �v���r���[�X�N���v�g�擾�p
    private GameObject Preview;
    private GameObject Button;
    // 4��I������Ă��邩�ǂ����m�F�p
    private bool Loop;

    void Start()
    {
        // ������
        string[] SelectShipNum = new string[] { "", "", "","" };
        //Animator[] animator = new Animator[3];
        Count = 0;
        Loop = false;

        animator[Count].SetBool("select", true);
        // �v���r���[�\���Ɏg�p
        Preview = GameObject.Find("ButtonCanvas");
        Button = GameObject.Find("Image");
        //Button.GetComponent<AnimationControl>().AnimStart();
    }

    private void Update()
    {
        //animator[Count].SetBool("select", true);
    }

    // �V���O���N���b�N���������̏���(�v���r���[�̕\��)
    public void Click(int ShipNumber)
    {
        // �v���r���[�\���p�X�N���v�g�ɏ��𑗂�
        Preview.GetComponent<FriendShipSelect>().Display(ShipNumber);
    }

    // �_�u���N���b�N���������̏���(�D��Ґ��ɒǉ�)
    public void DoubleClick(string ShipNum)
    {

        // 4�Ԗڂ̔z��܂œ��B�����烊�Z�b�g

        // �ēx�{�^����������悤�ɂ��鏈��
        if (Loop == true)
        {
            buttun[int.Parse(SelectShipNum[Count]) - 1].interactable = true;
        }
        // Count�Ԗڂ̔z��ɉ������{�^���̈������
        SelectShipNum[Count] = ShipNum;
        //Debug.Log(Count + "�Ԗڂ̔z���" + ShipNum + "���");
        // �{�^������
        buttun[int.Parse(ShipNum) - 1].interactable = false;    // �{�^���ɐG��Ȃ�����

        //sprite[] = Resources.Load<Sprite>();
        //image = GetComponent<Image>();
        image[Count].sprite = sprite[int.Parse(ShipNum)-1];

        Button.GetComponent<AnimationControl>().AnimStop();

        Debug.Log("++�O��"+animator[Count]);

        // �J�E���g��i�߂�
        Count++;
        if (Count >= 4)
        {
            Count = 0;
            Loop = true;
        }
    }

}
