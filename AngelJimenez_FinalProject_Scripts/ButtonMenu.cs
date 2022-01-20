using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public GameObject pauseMenu; // create Gameobject "pauseMenu"
    public GameObject controlsMenu; //create Gameobject "controlsMenu"



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //if key "P" is clicked
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy); //game opject "pauseMenu" is set to active if not active and vise versa
        }
    }

    public void Play() //creates function called "Play"
    {
        SceneManager.LoadScene("WorldPick"); //Load next scene
    }

    public void ExitGame() //creates function called "ExitGame"
    {
        Application.Quit(); //Quits the game
    }

    public void MainMenu() //creates function called "MainMenu"
    {
        //pauseMenu.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("GameManager")); //Destroys the GameObject with tag "GameManager" So that when you click on menu it doesn's have two GameManager objects
        SceneManager.LoadScene(0); //Load first scene in the game, "StartScreen"
    }

    public void Controls() //creates function called "Contorls"
    {
        controlsMenu.SetActive(true); //gameobject 'controlMenu' is set to active
    }

    public void ExitControls() //creates function called "ExitControls"
    {
        controlsMenu.SetActive(false); //gameobject 'controlsMenu' is set to not active
    }

    public void GoToLevelPicker() //creates function called "GoToLevelPicker"
    {
        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByName("T1")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("T2")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("T3"))) //if current scene is T1, T2, or T3
        {
            SceneManager.LoadScene("Tutorial"); //Load Scene called "Tutorial"
        }

        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByName("W1")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("W2")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("W3"))) //if current scene is W1, W2, or W3
        {
            SceneManager.LoadScene("Wires"); //Load Scene called "Wires"
        }

        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByName("G1")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("G2")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("G3"))) //if current scene is G1, G2, or G3
        {
            SceneManager.LoadScene("Factory"); //Load Scene called "Factory"
        }

        if ((SceneManager.GetActiveScene() == SceneManager.GetSceneByName("F1")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("F2")) || (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("F3"))) //if current scene is F1, F2, or F3
        {
            SceneManager.LoadScene("Infernal"); //Load Scene called "Infernal"
        }

        pauseMenu.SetActive(false); //make the pause menu invisible
    }

}
