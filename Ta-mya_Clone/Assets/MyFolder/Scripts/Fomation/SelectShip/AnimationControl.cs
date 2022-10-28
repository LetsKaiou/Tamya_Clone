using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator[] animator;
    private GameObject Select;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < animator.Length; i++)
        {
            // animatorコンポーネントを取得
            //animator[i] = GetComponent<Animator>();
            Debug.Log(animator[i]);
        }
        Select = GameObject.Find("Scroll View");
        Debug.Log("++前の" + animator[Select.GetComponent<SelectShip>().Count]);
    }

    // Update is called once per frame
    public void Update()
    {
        
        animator[num].SetBool("select", true);
        //animator[Select.GetComponent<SelectShip>().Count].SetBool("select", true);
        Debug.Log(Select.GetComponent<SelectShip>().Count);
        Debug.Log("animation" + animator[Select.GetComponent<SelectShip>().Count]);
    }

    public void AnimStop()
    {
        animator[num].SetBool("select", false);

        num++;

        if (num >= 4)
        {
            num = 0;
        }
    }
}
