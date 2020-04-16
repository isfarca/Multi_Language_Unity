using Polyglot;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LocalizationImporter.DownloadCustomSheet());
    }
}