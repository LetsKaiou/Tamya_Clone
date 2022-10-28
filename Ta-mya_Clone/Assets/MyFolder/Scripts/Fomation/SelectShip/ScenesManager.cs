using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // �V�[���J�ڏ���(�^�C�g�����)
    
    // �V�[���J�ڏ���(�X)

    // �V�[���J�ڏ���(�Ґ����)
    public void OnClickSelectShipButton()
    {
        SceneManager.LoadScene("Formation");
    }

    public void OnClickDevelopmentButton()
    {
        SceneManager.LoadScene("Development");
    }

    public void OnClickSelectSpecialAttackButton()
    {
        SceneManager.LoadScene("SpecialAttack");
    }

    public void OnclickBaseButton()
    {
        SceneManager.LoadScene("BaseCityScene");
    }
    public void OnClickBattle()
    {
        SceneManager.LoadScene("demo");
    }

    public void OnClickBackButton(int Num)
    {
        switch (Num)
        {
            case 0:
                SceneManager.LoadScene("BaseCityScene");
                break;
            case 1:
                SceneManager.LoadScene("SelectScenes");
                break;
            case 2:
                SceneManager.LoadScene("Formation");
                break;
            case 3:
                SceneManager.LoadScene("SpecialAttack");
                break;
            case 4:
                SceneManager.LoadScene("Development");
                break;
            default:
                break;
        }
        ;       
    }

    // �V�[���J�ڏ���(�o�g��)
}
