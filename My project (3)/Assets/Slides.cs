using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slides : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    void Start()
    {
        // Add a listener for when the value of the slider changes
        _slider.onValueChanged.AddListener((x) =>
        {
            // Update the text to display the slider value
            _sliderText.text = x.ToString("0.00");
        });
    }

    void Update()
    {
        // You can add update logic here if needed
    }
}