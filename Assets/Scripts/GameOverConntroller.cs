using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverConntroller : MonoBehaviour
{
    public Button buttonRestart;

    // Start is called before the first frame update
    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        Debug.Log("Reloading Scene");
        SceneManager.LoadScene(0);
    }
}
