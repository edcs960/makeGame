using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ButtonClick(string type)
    {
        switch (type)
        {
            case "START" :
                SceneManager.LoadScene("Main");
                break;
            case "SETTING" :
                // 팝업창으로 설정창 만들기
                break;
        }
    }
}
