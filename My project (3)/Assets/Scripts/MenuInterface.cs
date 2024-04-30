using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInterface : MonoBehaviour
{
    public string VRGame;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Don't load the game scene immediately, wait for player input
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game has been started
        if (gameStarted)
        {
            // Load the game scene
            SceneManager.LoadScene(VRGame);
        }
    }

    public void StartGame()
    {
        // Set the flag to indicate that the game should start
        gameStarted = true;
    }

    public void OpenOptions()
    {
        // Implement option menu functionality here
    }

    public void CloseOptions()
    {
        // Implement close option menu functionality here
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
