using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadTutorial() //create function named LoadTutorial
    {
        SceneManager.LoadScene("Tutorial"); //Load level called "Tutorial"
    }

    public void LoadT1() //create function named LoadT1
    {
        SceneManager.LoadScene("T0.0"); //Load level called "T0.0"
    }

    public void LoadT2() //create function named LoadT2
    {
        SceneManager.LoadScene("T1.1"); //Load level called "T1.1"
    }

    public void LoadT3() //create function named LoadT3
    {
        SceneManager.LoadScene("T3"); //Load level called "T3"
    }

    public void LoadWires()//create function named LoadWires
    {
        SceneManager.LoadScene("Wires"); //Load level called "Wires"
    }

    public void LoadW1() //create function named LoadW1
    {
        SceneManager.LoadScene("W0.1"); //Load level called "W0.1"
    }

    public void LoadW2() //create function named LoadW2
    {
        SceneManager.LoadScene("W2"); //Load level called "W2"
    }

    public void LoadW3() //create function named LoadW3
    {
        SceneManager.LoadScene("W2.1"); //Load level called "W2.1"
    }

    public void LoadFactory() //create function named LoadFactory
    {
        SceneManager.LoadScene("Factory"); //Load level called "Factory"
    }

    public void LoadG1() //create function named LoadG1
    {
        SceneManager.LoadScene("G0.1"); //Load level called "G0.1"
    }

    public void LoadG2() //create function named LoadG2
    {
        SceneManager.LoadScene("G12"); //Load level called "G12"
    }

    public void LoadG3() //create function named LoadG3
    {
        SceneManager.LoadScene("G2.1"); //Load level called "F2.1"
    }

    public void LoadInfernal() //create function named LoadInfernal
    {
        SceneManager.LoadScene("Infernal"); //Load level called "Infernal"
    }

    public void LoadF1() //create function named LoadF1
    {
        SceneManager.LoadScene("F0.1"); //Load level called "F0.1"
    }

    public void LoadF2() //create function named LoadF2
    { 
        SceneManager.LoadScene("F1.1"); //Load level called "F1.1"
    }

    public void LoadF3() //create function named LoadF3
    {
        SceneManager.LoadScene("F3"); //Load level called "F3"
    }

    
}
