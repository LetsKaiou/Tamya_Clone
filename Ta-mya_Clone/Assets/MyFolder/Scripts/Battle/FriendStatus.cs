using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//[CreateAssetMenu(fileName = "Database", menuName = "�q�@�f�[�^/Database")]
public class FriendStatus : MonoBehaviour
{
    public struct FriendStatusData
    {
        public string name;
        //�X�e�[�^�X
        public float HP;
        public float DEF;
        public float SPD;
    }

    //�G�̍\���̂��i�[���郊�X�g
    public static List<FriendStatusData> status = new List<FriendStatusData>();


    void Start()
    {
        //�G���X�g�ɓǂݍ��񂾏��𔽉f
        status = STATUSDATA_read_csv();
    }


    //ENEMY�\���̂�csv�t�@�C����ǂݍ���
    public List<FriendStatusData> STATUSDATA_read_csv()
    {
        //�ꎞ���͗p�Ŗ��񏉊�������\���̂ƃ��X�g
        FriendStatusData data = new FriendStatusData();
        List<FriendStatusData> data_list = new List<FriendStatusData>();

        //Resources����CSV��ǂݍ��ނ̂ɕK�v
        TextAsset csvFile;

        //�ǂݍ���CSV�t�@�C�����i�[
        List<string[]> csvDatas = new List<string[]>();

        //CSV�t�@�C���̍s�����i�[
        int height = 0;

        //for���p�B��s�ڂ͓ǂݍ��܂Ȃ�
        int i = 1;

        /* Resouces/CSV����CSV�ǂݍ��� */
        csvFile = Resources.Load("CSV/status") as TextAsset;
        //�ǂݍ��񂾃e�L�X�g��String�^�ɂ��Ċi�[
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            // ,�ŋ�؂���CSV�Ɋi�[
            csvDatas.Add(line.Split(','));
            height++; // �s�����Z
        }
        for (i = 1; i < height; i++)
        {

            //csvDatas��String�^�Ȃ̂ł��̂܂܊i�[�ł���
            data.name = csvDatas[i][0];
            //String�^��float�^�ɂ��Ċi�[
            data.HP  = Convert.ToSingle(csvDatas[i][1]);
            data.DEF = Convert.ToSingle(csvDatas[i][2]);
            data.SPD = Convert.ToSingle(csvDatas[i][3]);

            Debug.Log("�G��ǂݍ��񂾁F" + data.name[1]);
            //Debug.Log("HP�F" + data.HP);
            //Debug.Log("DEF�F" + data.DEF);
            //Debug.Log("SPD�F" + data.SPD);

            //�߂�l�̃��X�g�ɉ�����
            data_list.Add(data);
        }
        return data_list;
    }
}
