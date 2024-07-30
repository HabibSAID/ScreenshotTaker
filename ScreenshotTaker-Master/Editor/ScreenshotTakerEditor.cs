using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScreenshotTaker))]
public class ScreenshotTakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScreenshotTaker screenshotTaker = (ScreenshotTaker)target;

        // Default button style
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

        if (GUILayout.Button("Take Screenshot", buttonStyle))
        {
            screenshotTaker.TakeScreenshot();
        }
    }
}
