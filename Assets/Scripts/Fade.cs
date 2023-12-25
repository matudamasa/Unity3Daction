using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public string SceneName;

    public FadeScene FadeScene;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            // SceneManager.LoadScene(Name);
            FadeScene.LoadScene(SceneName);

        });
    }
}
