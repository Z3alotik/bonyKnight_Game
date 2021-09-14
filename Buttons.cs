using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour{

    public void NewGame() {
        Application.LoadLevel(2);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Back() {
        Application.LoadLevel(0);
    }

    public void Options() {
        Application.LoadLevel(1);
    }

    public void Level1()
    {
        Application.LoadLevel(3);
    }

    public void Level2()
    {
        Application.LoadLevel(4);
    }

    public void Level3()
    {
        Application.LoadLevel(5);
    }

    public void Level4()
    {
        Application.LoadLevel(6);
    }

    public void Level5()
    {
        Application.LoadLevel(7);
    }
}
