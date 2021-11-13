using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFirmType
{
    None,

    //Asia
    CarAsia,
    BankAsia,
    ConsoleAsia,
    PhoneAsia,
    fifthAsia,
    sixthAsia,

    //Europe
    CarEurope,
    ClothesEurope,
    FoodEurope,
    BankEurope,
    PhoneEurope,
    OperatorEurope,
    BeerEurope,
    eightsEurope,

    //America
    ITAmerica,
    BankAmerica,
    eShopAmerica,
    SodaAmerica,
    AppAmerica,
    FastFoodAmerica,
    ProcessorAmerica,
    CarAmerica,

    //Additionnal
    CinemaAmerica,
    FoodAmerica,
    PhotoStudioAmerica,
}


[CreateAssetMenu(fileName ="FirmInfo", menuName = "", order = 1)]
public class FirmInfoScriptableObject : ScriptableObject
{
    [SerializeField]
    private EFirmType _type;
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _cost;
    
    public Texture sprite;

    public EFirmType Type { get {return _type; } set { _type = value; } }
    public string Name {  get { return _name; } set { _name = value; } }

    public int Cost {  get { return _cost; } set { _cost = value; } }
    public int Rent { get { return _cost / 10; }  }

}
