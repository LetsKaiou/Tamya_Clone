using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendShipSelect : MonoBehaviour
{
    #region ����
    // csv�œǂݍ���ł����f�[�^���i�[����ϐ��̍쐬 �Z
    // �ǂ̋@�̂��I�����ꂽ�̂��𒲂ׂ�ϐ��쐬 �Z
    // �ǂ̋@�̂��I�����ꂽ�̂��𒲂ׂ�
    // �ǂݍ���ł����f�[�^��Start�֐����Ŋi�[ �Z
    // �I�����ꂽ�@�̂̃f�[�^���i�[
    // �v���r���[�ɃX�e�[�^�X�Ȃǂ̕\��(�e�L�X�g���g��)
    // �I�����ꂽ�@�̂𐶐�
    // �Q�l��:https://wisteria-sophy.com/663/unity_basis9/
    #endregion

    private FriendShipInfo statusInfo;
    // �ǂ̐�͂ɃX�e�[�^�X�������邩�I������ϐ�(0�`3�̂S�@)
    private int count = 0;
    // �ǂ̐�͂��I�΂ꂽ���i�[����ϐ� (�퓬�V�[���J�n���Ɏg��)
    private int[] SelectNum = new int[3];
    //�@�X�e�[�^�X�i�[�ϐ� (�I���V�[���A�퓬�V�[���J�n���Ɏg��)
    private int[] StatusIn = new int[3];
    // ��̖͂��O
    public string[] Name = new string[30];
    // ��͂�HP
    public int[] HP = new int[3];
    // ��̖͂h���
    public int[] DEF = new int[3];
    // ��͂̃X�s�[�h
    public int[] SPD = new int[3];
    // �ǂ̃{�^���������ꂽ�����肷��ϐ�
    private int number;
    // �����ꂽ�ԍ��𑗐M����p�ϐ�
    public static int ShipNumber;
    // �e�L�X�g�i�[
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI DEFText;
    [SerializeField] private TextMeshProUGUI SPDText;


    void Start()
    {
        count = 0;
        statusInfo = new FriendShipInfo();
        statusInfo.Init();
        //CreateShip();
    }

    // �퓬�V�[���J�n���ɖ����@�𐶐�����ۂɎg�p
    private void CreateShip()
    {
        // StatusIn�ɂ͑�����邾���ASelectNum��count�ԖڂɑI�����ꂽ�ԍ��̏���ǂݍ���
        Name[count] = statusInfo.Name[SelectNum[count]];
        HP[count] = statusInfo.HP[SelectNum[count]];
        DEF[count] = statusInfo.DEF[SelectNum[count]];
        SPD[count] = statusInfo.SPD[SelectNum[count]];
        count++;
        //}
    }

    
    // �v���r���[�ɕ\�����邽�߂̏���
    public void Display(int number)
    {
        NameText.text = statusInfo.Name[number];
        //NameText.SetText("{0}", statusInfo.Name[number]);
        HPText.SetText("HP:{0}", statusInfo.HP[number]);
        DEFText.SetText("DEF:{0}", statusInfo.DEF[number]);
        SPDText.SetText("SPD:{0}", statusInfo.SPD[number]);
    }

    // �l�̑������
    private void SetData(int SelectNum)
    {
        ShipNumber = SelectNum;
    }

}
