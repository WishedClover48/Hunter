using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    [SerializeField] private TMP_InputField commandInputField;
    [SerializeField] private TMP_Text outputText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    void Start()
    {
        commandInputField.onSubmit.AddListener(delegate { ExecuteInputCommand(); });
    }

    public void ExecuteInputCommand()
    {
        string input = commandInputField.text.Trim();
        if (string.IsNullOrEmpty(input)) return;

        ParseAndExecuteCommand(input);
        commandInputField.text = ""; // Clear input field after execution
        if (commandInputField.gameObject.activeSelf)
        {
            commandInputField.ActivateInputField();
        }
    }

    private void ParseAndExecuteCommand(string input)
    {
        string[] args = input.Split(' '); // Split inputs by spaces
        if (args.Length == 0) return;
        string command = args[0].ToLower(); // Command name
        switch (command)
        {
            case "move":
                if (args.Length == 3)
                {
                    Vector3 direction = ParseDirection(args[1]);
                    if (direction == Vector3.zero)
                    {
                        AppendToOutput("Invalid direction. Use forward, back, left, or right.");
                        return;
                    }
                    float distance = float.Parse(args[2]);
                    ICommand moveCommand = new MoveCommand(player.transform, direction * distance);
                    moveCommand.Execute();
                    AppendToOutput($"Player moved {args[1]} by {args[2]} units.");
                }
                break;
            case "lives":
                ICommand livesCommand = new LivesCommand(player);
                livesCommand.Execute();
                AppendToOutput("Player lives refilled.");
                break;
            case "enemy":
                ICommand spawnEnemy = new SpawnEnemy(enemy, player);
                spawnEnemy.Execute();
                AppendToOutput("Enemy spawned.");
                break;
            case "help":
                DisplayHelp();
                break;
            default:
                AppendToOutput($"Unknown command: {input}.");
                break;
        }
    }
    private void DisplayHelp()
    {
        string helpText =
            "**Available Commands**:\n" +
            "- **move <direction> <distance>**: Moves the player in a specified direction by a given distance.\n" +
            "- **lives**: Refills player lives back to 3\n" +
            "- **enemy**: Spawns an enemy in front of the player\n" +
            "- **help**: Displays this list of available commands.";
        AppendToOutput(helpText);
    }

    private void AppendToOutput(string message)
    {
        outputText.text += $"{message}\n";
    }

    private Vector3 ParseDirection(string direction)
    {
        return direction.ToLower() switch
        {
            "forward" => Vector3.forward,
            "back" => Vector3.back,
            "left" => Vector3.left,
            "right" => Vector3.right,
            _ => Vector3.zero,
        };
    }
    private void Update()
    {
        // BackQuote is the '~' key
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            bool isActive = commandInputField.gameObject.activeSelf;
            commandInputField.gameObject.SetActive(!isActive);
            outputText.gameObject.SetActive(!isActive);
            if (!isActive)
            {
                GameManager.Instance.SwitchState(GameManager.gameState.Pause);
                commandInputField.text = "";
                commandInputField.ActivateInputField();
            }
            else
            {
                GameManager.Instance.SwitchState(GameManager.gameState.MainWorld);
            }
        }
    }
}
