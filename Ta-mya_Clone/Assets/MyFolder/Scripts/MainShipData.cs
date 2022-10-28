using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MainShipData
{
    // �ۑ��������
    // ���@�̃X�e�[�^�X(HP,CT,����U���̍U����)�A�����̃f�[�^(�e�J���|�C���g�̗ݐϒl)�A�����Ă������U���E�����̐퓬�@

        // ���@�̃X�e�[�^�X
    public int HP = 12;
    public float CT = 3;
    public int ATK = 5;

    // �����̃f�[�^
    public int TotalIndustry;
    public int TotalCommercial;
    public int TotalAgriculture;

    // ����U���A�퓬�@
    List<string> Special = new List<string>();
    List<string> Ship = new List<string>();
}
