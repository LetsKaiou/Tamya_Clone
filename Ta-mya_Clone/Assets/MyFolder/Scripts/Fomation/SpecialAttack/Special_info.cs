using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class Special_info 
{
    static TextAsset csvFile;
    // �ꎞ�i�[��̃��X�g
    static List<string[]> SpecialInfo = new List<string[]>();
    // �i�[����f�[�^�̕ϐ�
    public string[] Name = new string[100];         // ���O
    public int[] Attack = new int[100];             // �U����
    public float[] CT = new float[100];             // �N�[���^�C��
    public int[] Range = new int[100];              // �˒�(�e��������܂ł̎���)
    public string[] Explanatory = new string[100];  // ����U���̐�����
    public bool Ones = false;
    // Start is called before the first frame update
    static void CsvReader()
    {
        //�w�肵���t�@�C����TextAsset�Ƃ��ēǂݍ���
        csvFile = Resources.Load("CSV/specialattack") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        //�Ō�܂œǂݍ��ނ�-1�ɂȂ�֐�
        while (reader.Peek() != -1)
        {
            //��s���ǂݍ���
            string line = reader.ReadLine();
            //,��؂�Ń��X�g�ɒǉ����Ă���
            SpecialInfo.Add(line.Split(','));
        }
    }

    // �f�[�^�̊i�[����
    public void Init()
    {
        if (Ones == false)
        {
            //�����ꎞ�i�[
            CsvReader();

            //�e�ϐ��փf�[�^���i�[�@CSV�t�@�C�����̍s�����ǂݍ��݁i�S�X�e�[�^�X�f�[�^�j
            for (int i = 1; i < SpecialInfo.Count; i++)
            {
                Name[i] = SpecialInfo[i][0];
                Attack[i] = int.Parse(SpecialInfo[i][1]);//string�^����int�^�֕ϊ�
                CT[i] = float.Parse(SpecialInfo[i][2]);
                Range[i] = int.Parse(SpecialInfo[i][3]);
                Explanatory[i] = SpecialInfo[i][4];
            }
            Ones = true;
        }
    }

    // �f�[�^�̏�����
    public void Delete()
    {
        Attack = new int[100];
        CT = new float[100];
        Range = new int[100];
    }
}
