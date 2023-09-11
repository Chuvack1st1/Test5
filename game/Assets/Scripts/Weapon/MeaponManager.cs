using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Unity.VisualScripting;

public class MeaponManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;

    [SerializeField] private Weapon _startWeapon;

    private Weapon _currentWeapon;

    public static UnityAction OnShoot;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _weapons.Add(transform.GetChild(i).GetComponent<Weapon>());
            _weapons[i].gameObject.SetActive(false);
        }
        SetCurrentWeapon(1);
    }
    public void AddBonus(int value)
    {
        int newValue = 0;

        if (GetCurrentWeaponIndex() >= 0)
        {
            newValue = GetCurrentWeaponIndex() + value;
            newValue = Mathf.Clamp(newValue, 0, _weapons.Count - 1);
        }
        else
        {
            throw new InvalidOperationException();
        }
        SetCurrentWeapon(newValue);
    }
    private int GetCurrentWeaponIndex()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i] == _currentWeapon)
            {
                
                return i;
            }
        }
        return -1;
    }
    private void SetCurrentWeapon(int index)
    {
        if (_currentWeapon != null)
            _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = _weapons[index];
        _currentWeapon.gameObject.SetActive(true);
    }
    public void StartShoot()
    {
        OnShoot?.Invoke();
    }
}
