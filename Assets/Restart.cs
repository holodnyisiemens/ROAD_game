using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public bool loss = false;//сбила машина
    public bool finish = false;//прошел на финиш
    [SerializeField] GameObject _losscanvas;
    [SerializeField] GameObject _losstext;
    [SerializeField] float textSpeed;
    [SerializeField] GameObject _wincanvas;
    public void Update()
    {
        if (loss) {
            _losscanvas.SetActive(true);
            finish = false; //чтобы игрок не убежал на финиш после поражения 
            if (_losstext.transform.localScale.x < 1.5)
            {
                _losstext.transform.localScale += Vector3.one * Time.deltaTime * textSpeed;
            }
            else if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                Application.Quit();
            }
            else
            {
                RestartLevel();
            }
        }
        if (finish) {
            NextLevel();
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next);
        }
        else
        {
            _wincanvas.SetActive(true);
        }
    }
}
