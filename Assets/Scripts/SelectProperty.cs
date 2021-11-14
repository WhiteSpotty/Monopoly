using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectProperty : MonoBehaviour
{
    private static Button _confirmButton;
    private static Button _cancelButton;
    private static Dropdown _dropdown;
    private static Player _player;
    private List<Tile> _options = new List<Tile>();

    public delegate void SelectDelegate(Tile selectedTile);
    public SelectDelegate confirmedDelegate;

    public void Awake()
    {
        _dropdown = transform.Find("SelectPropertyPanel/SelectPropertyDropdown").gameObject.GetComponent<Dropdown>();

        _confirmButton = transform.Find("SelectPropertyPanel/Confirm").gameObject.GetComponent<Button>();
        _confirmButton.onClick.AddListener(Confirm);
        
        _cancelButton = transform.Find("SelectPropertyPanel/Cancel").gameObject.GetComponent<Button>();
        _cancelButton.onClick.AddListener(Cancel);
    }

    public void Create(List<string> options)
    {
        _dropdown.ClearOptions();
        options.Insert(0, "None");
        _dropdown.AddOptions(options);
    }

    #region Property Filters
    public void notMortgagedProperty(Player p)
    {
        _player = p;
        List<string> res = new List<string>();
        foreach (CommonTile tile in _player.Property)
        {
            if (!tile.isMortgage)
            {
                res.Add($"{tile.Name} (+{tile.firmInfo.PledgedAmount}$)");
                _options.Add(tile);
            }
        }
        Create(res);

        Time.timeScale = 0;
    }
    public void mortgagedProperty(Player p)
    {
        _player = p;
        List<string> res = new List<string>();
        foreach (CommonTile tile in _player.Property)
        {
            if (tile.isMortgage)
            {
                res.Add($"{tile.Name} (-{tile.firmInfo.UnpledgedAmount}$)");
                _options.Add(tile);
            }
        }
        Create(res);

        Time.timeScale = 0;
    }
    #endregion


    public void Confirm()
    {
        if (_dropdown.value == 0) { Time.timeScale = 1f; Destroy(this.gameObject); return; }

        int ind = _dropdown.value - 1;
        Tile selectedTile = _options[ind];
        confirmedDelegate?.Invoke(selectedTile);

        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }

    public  void Cancel()
    {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
