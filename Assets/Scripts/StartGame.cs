using System;
using Drawer;
using UnityEngine;

namespace DefaultNamespace
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] LasDrawer LasDrawer;
        void Start()
        {
            LasDrawer.Show();
        }
    }
}