using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Canvas miniMap_Canvas = null;
    [SerializeField] Button dayNightButton = null;
    [SerializeField] Image dayNightImage = null;
    [SerializeField] Sprite dayImage = null;
    [SerializeField] Sprite duskImage = null;
    [SerializeField] Color dayColor;
    [SerializeField] Color duskColor;

    [SerializeField] Dropdown dropdown = null;
    GameManager gm;
    PlayerCamera pc;
    public static UIManager um;

    public bool isMain = true;

    bool isDayToggle = true;
    
    private bool toggle = false;
    public bool Toggle { get => toggle; set => toggle = value; }

    private void Awake()
    {
        #region Singleton

        if (um == null)
        {
            DontDestroyOnLoad(gameObject);
            um = this;
        }
        else if (um != null)
        {
            Destroy(gameObject);
        }
        #endregion
        gm = FindObjectOfType<GameManager>();
        gm.GetComponent<GameManager>();
        showMap(toggle);
        toggleMouse(toggle);
    }

    private void Start()
    {
        dayNightButton.image.color = duskColor;
        dayNightImage.sprite = duskImage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            toggle = !toggle;

        showMap(toggle);
        toggleMouse(toggle);
    }

    void showMap(bool toggle)
    {
        pc = FindObjectOfType<PlayerCamera>();
        if (toggle) 
        {
            canvas.SetActive(toggle);
            miniMapToggle(toggle);
            toggleMouse(toggle);
        }
        else
        {
            canvas.SetActive(toggle);
            miniMapToggle(toggle);
            toggleMouse(toggle);
        }
    }

    public void miniMapToggle(bool toggle)
    {
        if(toggle)
            miniMap_Canvas.enabled = !toggle;
        else
            miniMap_Canvas.enabled = !toggle;
    }

    void toggleMouse(bool toggle)
    {
        if (toggle)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void dayNightToggle()
    {
        isDayToggle = !isDayToggle;

        if (isDayToggle == true)
        {
            dayNightButton.image.color = duskColor;
            dayNightImage.sprite = duskImage;
            gm.LoadScene("Main");
            backToMainButtonReset();
        }
        else
        {
            dayNightButton.image.color = dayColor;
            dayNightImage.sprite = dayImage;
            gm.LoadScene("MainDusk");
            backToMainButtonReset();
        }
    }

    public void backToMainButtonReset()
    {
        if (isDayToggle)
        {
            gm.LoadScene("Main");
            dropdown.buttonReset();
        }
        else
        { 
            gm.LoadScene("MainDusk");
            dropdown.buttonReset();
        }
    }

}
