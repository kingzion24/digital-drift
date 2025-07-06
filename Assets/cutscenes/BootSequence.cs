using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BootSequence : MonoBehaviour
{
    [Header("Assign your TMP Text UI object here")]
    public TextMeshProUGUI terminalText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;
    public float lineSpacing = 0.4f; // Time to wait between lines

    public GameObject startButton; // Reference to the start button
    public GameObject menuButton; // Reference to the start button
    public SoundController soundController; // Reference to the SoundController
    public int scene = 0; // Level index for text
    public mode_controller mode; // Reference to the mode controller

    // The boot lines that will appear on screen
    private string[][] bootLines = new string[][] {
    new string[]{
        "BOOTING SYSTEM...\n",
        "SYSTEM ERROR: BIOS CHIP MISSING\n",
        "MEMORY STATUS: CORRUPTED\n",
        "DISPLAY MODULE: GLITCHING\n",
        "THREAT LEVEL: CRITICAL\n",
        "\n> Initializing Recovery Agent...\n",
        "> Welcome, Avatar. Your mission is to reclaim the lost components.\n",
        "> Begin Operation: DIGITAL DRIFT.\n",
        "> FIRST STAGE: BIOS BLITZ.\n"
    },
    new string[]{
        "BOOTING SYSTEM...\n",
        "BIOS SUCCESSFULLY BOOTED\n",
        "MEMORY STATUS: CORRUPTED\n",
        "DISPLAY MODULE: GLITCHING\n",
        "THREAT LEVEL: HIGH\n",
        "> Good Job, Avatar. Continue reclaiming the lost components.\n",
        "> NEXT STAGE: RAM RUSH.\n"
    },
    new string[]{
        "BOOTING SYSTEM...\n",
        "BIOS SUCCESSFULLY BOOTED\n",
        "MEMORY STATUS: UPGRADED\n",
        "DISPLAY MODULE: GLITCHING\n",
        "THREAT LEVEL: MEDIUM\n",
        "> Good Job, Avatar. Reclaim the final components.\n",
        "> NEXT STAGE: MONITOR MANEUVER.\n"
    },
    new string[]{
        "BOOTING SYSTEM...\n",
        "SYSTEM ERROR: BIOS CHIP MISSING\n",
        "MEMORY STATUS: UPGRADED\n",
        "DISPLAY MODULE: FIXED\n",
        "THREAT LEVEL: LOW\n",
        "> Congratulations, Avatar. You have successfully reclaimed all components.\n",
        "> System Recovery Complete.\n",
        }};

    void Start()
    {
        
        mode = GameObject.FindGameObjectWithTag("mode").GetComponent<mode_controller>();
        scene = mode.cutscene; // Get the current scene index from the mode controller
        soundController = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundController>();
        
        if(scene ==3){
            soundController.playBackgroundMusic(5);
        }else{
            soundController.playBackgroundMusic(4);
        }
         // Play booting background music
        
        // Validate if the text field is assigned
        if (terminalText == null)
        {
            Debug.LogError("Terminal TextMeshProUGUI is not assigned in the Inspector!");
            return;
        }
        Time.timeScale = 1; // Ensure time scale is normal for the boot sequence
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        terminalText.text = "";
        string[] currentbootLines = bootLines[scene]; // Get the boot lines for the current scene
        foreach (string line in currentbootLines)
        {
            Debug.Log("Typing line: " + line);

            foreach (char c in line)
            {
                terminalText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }

            yield return new WaitForSeconds(lineSpacing); // Pause between lines
        }

        Debug.Log("Boot sequence complete. Waiting before scene load...");
        yield return new WaitForSeconds(2f); // Wait before loading level
        if(scene !=3){
            startButton.SetActive(true); // Enable the start button after the boot sequence
        }else{
            menuButton.SetActive(true); // Enable the menu button after the boot sequence
        }    
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene(5+scene); // Replace with your actual level name
    }
    public void loadMenu(){
        SceneManager.LoadScene(0); // Replace with your actual level name
    }
}
