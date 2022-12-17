using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextBlink());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator TextBlink()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.75f);
            transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.75f);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
