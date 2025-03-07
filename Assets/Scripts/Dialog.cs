using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialog
{
    [SerializeField] List<string> lines;

    // Metoda pozwalaj�ca na pobieranie ustawionych dialog�w 
    public List<string> Lines
    {
        get { return lines; }
    }
}
