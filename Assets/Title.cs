using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // ���ӽ��� ��ư ���� �� Stage1���� ���� �ʵ�
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
