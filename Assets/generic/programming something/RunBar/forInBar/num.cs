using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class num : MonoBehaviour
{

    private int maxNum;
    private int counter = 0;

    public void setMaxNum(int maxNum)
    {
        this.maxNum = maxNum;
    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(delegate { TaskOnClick(); });
        this.GetComponentInChildren<Text>().text = counter.ToString();
    }
    void TaskOnClick()
    {
        if(counter < 3)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        this.GetComponentInChildren<Text>().text = counter.ToString();
    }

}
