using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFixer : MonoBehaviour
{
    public void ChangeScene(string newScene)
    {
        MySceneManager.Instance.ChangeScene(newScene);
    }
}
