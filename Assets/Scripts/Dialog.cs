using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialog
{
    [SerializeField] List<string> lines;

    // Metoda pozwalaj¹ca na pobieranie ustawionych dialogów 
    public List<string> Lines
    {
        get { return lines; }
    }
}
