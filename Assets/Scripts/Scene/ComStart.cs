using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anchor.Unity;

public class ComStart : MonoBehaviour
{
    private void Start()
    {
        ResourceHelper.LoadAndGetBuiltInAsset((success) =>
        {
            if(success)
            {

            }
        });
    }
}
