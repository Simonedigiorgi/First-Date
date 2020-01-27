using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Girl", menuName = "Girls")]
public class Girl : ScriptableObject
{
    // Difficulty Settings

    public float maxIncreaseValue; // Max Speed value of the fillBar

    public float increaseValueAmount; // Add difficulty
    public float timeIncreaseDifficulty; // Increase difficulty every TOT seconds

}
