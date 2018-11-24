using System;
using CAFU.Core;
using Monry.Unity1Weeks.Binary.Application;
using Monry.Unity1Weeks.Binary.Application.Enum;
using Monry.Unity1Weeks.Binary.Structure;
using Monry.Unity1Weeks.Binary.Utility;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Monry.Unity1Weeks.Binary.Presentation.View.Main
{
    public class Spawner : MonoBehaviour, IView
    {
        [Inject] private IFactory<BitAttribute, Bit> BitFactory { get; set; }

        private void Start()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(0.5))
                .Subscribe(
                    _ => BitFactory.Create(
                        new BitAttribute
                        {
                            Digit = Random.Range(0, Const.TotalDigit + 1),
                            GravityScale = EnumUtility.GetRandom<GravityScale>(),
                            SpreadRange = EnumUtility.GetRandom<SpreadRange>(),
                        }
                    )
                );
        }
    }
}