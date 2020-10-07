using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lobbyController : MonoBehaviour
{ public Button button;
    // Start is called before the first frame update
    private void Awake()
    {
        button.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
