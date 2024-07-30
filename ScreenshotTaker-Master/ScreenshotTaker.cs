using UnityEngine;
using System.IO;

public class ScreenshotTaker : MonoBehaviour
{
    private static ScreenshotTaker instance;

    // Public string for the screenshots folder
    public string screenshotsFolder = "Screenshots";

    // Enum for image type
    public enum ImageType
    {
        png,
        jpg
    }

    // Public variable for selecting the image type
    public ImageType imageType;

    private void Awake()
    {
        // Ensure that there's only one instance of ScreenshotTaker and it persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeScreenshot()
    {
        // Determine the folder path based on whether screenshotsFolder is set
        string folderPath;
        if (string.IsNullOrEmpty(screenshotsFolder))
        {
            folderPath = Application.dataPath;
        }
        else
        {
            folderPath = Path.Combine(Application.dataPath, screenshotsFolder);
        }

        // Ensure the directory exists, creating it if necessary
        Directory.CreateDirectory(folderPath);

        // Generate a file name with a timestamp and selected image type
        string extension = GetExtension(imageType);
        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + extension;
        string path = Path.Combine(folderPath, fileName);

        // Capture the screenshot and save it to the specified path
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Screenshot saved to: " + path);
    }

    private string GetExtension(ImageType type)
    {
        switch (type)
        {
            case ImageType.jpg:
                return ".jpg";
            default:
                return ".png";
        }
    }
}
