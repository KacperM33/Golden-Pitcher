using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialog
{
    [SerializeField] List<string> lines;

    // Metoda pozwalająca na pobieranie ustawionych dialogów 
    public List<string> Lines
    {
        get { return lines; }
    }
}
