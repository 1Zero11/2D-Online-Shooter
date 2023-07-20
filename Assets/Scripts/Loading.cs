using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public float time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadScene()
    {
        var timeElapsed = 0f;
        while (timeElapsed < time)
        {
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadSceneAsync("Game");

    }
}
