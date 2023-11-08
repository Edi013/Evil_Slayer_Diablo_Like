using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform EndScreen;
    public Transform Player;

    private bool IsOn = true;

    public void EndGame()
    {
        IsOn = false;    
        if(!IsOn)
        {
            DisplayEndScreen();
        }
    }

    private void DisplayEndScreen()
    {
        EndScreen.transform.position = Player.transform.position;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuRedirect()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
