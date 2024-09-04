using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// The base of our UI that both the menu and game inherit from.
/// This is because for our simple example, both UIs just had a single label and button.
/// In most use cases, you will not likely inherit your UI as all will be vastly different.
/// We require a "UI Document" component, so this ensures one exists in Unity.
/// Slides used in:
/// 5 - User Interfaces
/// </summary>
[RequireComponent(typeof(UIDocument))]
public class BaseUI : MonoBehaviour
{
    /// <summary>
    /// The scene number to load when the button is clicked.
    /// </summary>


    protected Label CoinLabel;

    protected Label timeLabel;

    protected Label BestLabel;



    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    protected virtual void Start()
    {
        // Get the component with our UI so we can they query it for the parts we want.
        UIDocument document = GetComponent<UIDocument>();

        // Start from the root of the UI and we can search for the other parts from there.
        VisualElement root = document.rootVisualElement;

        // Get the label for the score and high score.
        CoinLabel = root.Q<Label>("Coin");

        // Get the button for switching levels.
        timeLabel = root.Q<Label>("Timer");

        // Bind the button so every time it is clicked, it calls the "LoadLevel" method.
        BestLabel = root.Q<Label>("bestScore");



    }

    
    

    private void Update()
    {

    }
    
   

}