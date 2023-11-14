using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // 게임시작 버튼 누를 시 Stage1으로 가는 필드
    public string SceneToLoad;

    public void Loadgame() 
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
