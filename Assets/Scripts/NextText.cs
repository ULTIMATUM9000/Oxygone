using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextText : MonoBehaviour
{
    public Text TutorialText;
    int counter = 0;
    void Start()
    {

        TutorialText.text = "Hello There! This is the tutorial.";
        //You are trying\nto save the last remaining trees on Earth.\nThe 3 items below are the needs for the trees\nto survive in the horrid environment.";
    }

    public void NextT()
    {
        ++counter;

        if(counter == 1)
        {
            TutorialText.text = "You are trying to save the last remaining trees on Earth.";
        }

        if (counter == 2)
        {
            TutorialText.text = "The 3 items below are the ones you need to help the trees survive in the horrid environment.";
        }

        if (counter == 3)
        {
            TutorialText.text = "The Watering Can, The Pesticide, and The Fertilizer.";
        }

        if (counter == 4)
        {
            TutorialText.text = "You are to match what the tree is needing by moving towards the needed item using 'WASD' or the 'Arrow Keys' and press 'Spacebar'.";
        }

        if (counter == 5)
        {
            TutorialText.text = "Once you have the specified item, you can then move towards the tree and press the 'Spacebar' again.";
        }

        if (counter == 6)
        {
            TutorialText.text = "There! You repaired the tree.";
        }


        if (counter == 7)
        {
            TutorialText.text = "But Of course, because of the horrid environment, the tree eventually needs to be restored again.";
        }

        if (counter == 8)
        {
            TutorialText.text = "You are to repeat your task for the sake of the world.";
        }

        if (counter == 9)
        {
            TutorialText.text = "The 'Health Bar' that you see at the right corner is how healthy the environment is.";
        }
        if (counter == 10)
        {
            TutorialText.text = "Just Don't give the tree the wrong item or it will decrease the health of the environment";
        }

        if (counter == 11)
        {
            TutorialText.text = "If you are not doing your job, the health bar will decrease, if you are then it will increase.";
        }

        if (counter == 12)
        {
            TutorialText.text = "Good luck in the next stage! Pressing Next would continue to the main game :)";
        }

        if (counter == 13)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
