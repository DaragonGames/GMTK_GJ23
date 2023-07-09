using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    void Start()
    {
        EventManager.GameOverAction += ActivateUI;
    }

    void OnDestroy()
    {
        EventManager.GameOverAction -= ActivateUI;
    }

    public void ActivateUI(bool victory)
    {
        if (victory)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
