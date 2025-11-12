using UnityEngine;

public class Flowerbed : Interactable
{
    [SerializeField] private GameObject _flat;
    [SerializeField] private GameObject _hole;
    [SerializeField] private GameObject _convex;

    private FlowerbedState _flowerbedState = FlowerbedState.Flat;

    public void Initialize(FlowerbedState flowerbedState)
    {
        switch (flowerbedState)
        {
            case FlowerbedState.Flat:
                ToFlat();
                break;
            case FlowerbedState.Hole:
                ToHole();
                break;
            case FlowerbedState.Convex:
                ToConvex();
                break;
        }
    }

    public void ToHole()
    {
        _hole.SetActive(true);
        _flat.SetActive(false);
        _convex.SetActive(false);
        _flowerbedState = FlowerbedState.Hole;
    }

    public void ToConvex()
    {
        _hole.SetActive(false);
        _flat.SetActive(false);
        _convex.SetActive(true);
        _flowerbedState = FlowerbedState.Convex;
    }

    public void ToFlat()
    {
        _hole.SetActive(false);
        _flat.SetActive(true);
        _convex.SetActive(false);
        _flowerbedState = FlowerbedState.Flat;
    }

    public override string GetMessage()
    {
        switch (_flowerbedState)
        {
            case FlowerbedState.Flat:
                return "Вырыть лунку";
            case FlowerbedState.Hole:
                return "Закопать";
            case FlowerbedState.Convex:
                return "Полить";
        }

        return "";
    }

    public override void OnStartHover()
    {
        print(GetMessage());
    }

    public override void OnInteract()
    {
        switch (_flowerbedState)
        {
            case FlowerbedState.Flat:
                ToHole();
                break;
            case FlowerbedState.Hole:
                ToConvex();
                break;
            case FlowerbedState.Convex:
                break;
        }
    }
}