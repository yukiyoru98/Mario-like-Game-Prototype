using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour
{
    public static LoadingScenes self;
    private void Awake()
    {
        self = this;
    }

    private string SceneName = "";
    private Animation anim;

    private void Start() {
        anim = this.GetComponent<Animation>();
    }

    public void ChangeScene(string scene, float delay)
    {
        SceneName = scene;
        anim.Play("FadeOut");
        Invoke("GoToScene", delay);
    }

    void GoToScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
