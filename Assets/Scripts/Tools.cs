using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools 
{
    public static bool CheckIfFolderExists(string folderPath)
    {
        // Remove any leading or trailing slashes from the folder path
        //folderPath = folderPath.Trim('/');

        // Try to load an asset from the given folder path
        // If the folder doesn't exist, Resources.Load will return null
        var assets = Resources.LoadAll(folderPath);

        // Return true if the folder asset exists
        return assets.Length > 0;
    }
}
