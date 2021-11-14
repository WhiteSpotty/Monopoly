using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLayer : MonoBehaviour
{
    private static Button _confirmButton;
    private static Button _cancelButton;
    private static Dropdown _dropdown;
    private static Player _player;
    private List<Tile> _options = new List<Tile>();

    public delegate void SelectDelegate(ENameLayer layer);
    public SelectDelegate confirmedDelegate;

    public void Awake()
    {
        _dropdown = transform.Find("SelectLayerPanel/SelectLayerDropdown").gameObject.GetComponent<Dropdown>();

        _confirmButton = transform.Find("SelectLayerPanel/Confirm").gameObject.GetComponent<Button>();
        _confirmButton.onClick.AddListener(Confirm);

        _cancelButton = transform.Find("SelectLayerPanel/Cancel").gameObject.GetComponent<Button>();
        _cancelButton.onClick.AddListener(Cancel);
    }

    public void Create()
    {
        _dropdown.ClearOptions();
        _dropdown.AddOptions( new List<string>() { "America", "Europe", "Asia"});
    }

    public void Confirm()
    {
        ENameLayer layer = ENameLayer.Europe;
        switch (_dropdown.value)
        {
            case 0:
                layer = ENameLayer.America;
                break;
            case 1:
                layer = ENameLayer.Europe;
                break;
            case 2:
                layer = ENameLayer.Asia;
                break;
            default:
                Logs.PrintToLogs("Not found layer");
                break;
        }
        confirmedDelegate?.Invoke(layer);

        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }

    public void Cancel()
    {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
