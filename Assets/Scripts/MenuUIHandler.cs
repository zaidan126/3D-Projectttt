using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        mainmanager.data.gamecolor = color;
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        // ColorPicker.SelectColor(mainmanager.data.gamecolor);
        
    }
    public void startnew()
    {
        SceneManager.LoadScene(1);
    }
    public void exit()
    {
       // mainmanager.data.Save();
        //if (UNITY_EDITOR)
        {
            EditorApplication.ExitPlaymode();
        }
        //else
        {
            Application.Quit();
        }
        
        
    }
    public void savebutton()
    {
        mainmanager.data.Save();
    }
    public void loadbutton()
    {
        mainmanager.data.Load();
        ColorPicker.SelectColor(mainmanager.data.gamecolor);
    }
    
}
