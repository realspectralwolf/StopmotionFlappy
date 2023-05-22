using UnityEditor;
using UnityEngine;
using System;

public class TextureImporterProcessor : AssetPostprocessor
{
    string folderPath = "Assets/Resources";

    bool IsInTargetFolder()
    {
        string path = assetPath.Replace("\\", "/"); // Normalize path separators
        return (path.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase));
    }

    void OnPreprocessTexture()
    {
        if (IsInTargetFolder())
        {
            TextureImporter importer = (TextureImporter)assetImporter;
            importer.textureCompression = TextureImporterCompression.Compressed;
            importer.crunchedCompression = true;
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Single;
        }        
    }

    void OnPostprocessTexture(Texture2D texture)
    {
        if (IsInTargetFolder())
        {
            UpdateFrameRendersOnScene(texture);
        }
    }

    void UpdateFrameRendersOnScene(Texture2D texture)
    {
        // Find all sprite renderers in the scene
        FramesRenderer[] frameRends = UnityEngine.Object.FindObjectsOfType<FramesRenderer>();

        // Delay the sprite update to the next frame to ensure the imported sprite is ready
        EditorApplication.delayCall += () =>
        {
            foreach (FramesRenderer script in frameRends)
            {
                script.LoadSpriteFrames();
            }
        };
    }
}