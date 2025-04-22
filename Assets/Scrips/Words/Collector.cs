
using System;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    //Default value change on Unity's side.
    public string targetWord = "PEQUENO";
    private char[] collectedLetters;
    public TextMeshProUGUI wordDisplay;
    public bool wordCompleted = false;

    void Start()
    {
        collectedLetters = new string('-', targetWord.Length).ToCharArray();
        UpdateUI(collectedLetters, wordDisplay);
    }


    protected void UpdateUI(char[] collecterLetters, TextMeshProUGUI wordDisplay)
    {

        string updated = new string(collecterLetters);
        Debug.Log("Updating UI to: " + updated);

        if (wordDisplay == null)
        {
            Debug.LogError("❌ wordDisplay is NOT assigned!");
        }
        else
        {
            wordDisplay.text = updated;
        }
    }

    public void CollectLetter(char letter)
    {
        Debug.Log("Trying to collect: " + letter);

        for (int i = 0; i < targetWord.Length; i++)
        {
            Debug.Log($"Comparing targetWord[{i}] = {targetWord[i]} with letter = {letter}");

            if (char.ToUpper(targetWord[i]) == char.ToUpper(letter) && collectedLetters[i] == '-')
            {
                collectedLetters[i] = letter;
                Debug.Log("✅ Letter " + letter + " collected at position " + i);
                break;
            }
        }

        UpdateUI(collectedLetters, wordDisplay);

        if (string.Equals(new string(collectedLetters), targetWord, System.StringComparison.OrdinalIgnoreCase))
        {
            wordCompleted = true;
            Debug.Log("🎉 Word completed: " + targetWord);
        }
    }
}