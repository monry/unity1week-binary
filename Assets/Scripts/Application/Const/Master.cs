using System.Collections.Generic;
using Monry.Unity1Weeks.Binary.Application.Enum;
using UnityEngine;

namespace Monry.Unity1Weeks.Binary.Application
{
    public static partial class Const
    {
        public static class Master
        {
            public static IDictionary<bool, Color> FilledDigitColorMap { get; } = new Dictionary<bool, Color>
            {
                {true, Color.black},
                {false, Color.clear},
            };

            public static IDictionary<SpreadRange, IDictionary<bool, Color>> SpreadRangeColorMap { get; } = new Dictionary<SpreadRange, IDictionary<bool, Color>>
            {
                {
                    SpreadRange.Single,
                    new Dictionary<bool, Color>
                    {
                        {false, new Color(1.0f, 0.75f, 0.0f, 1.0f)},
                        {true, new Color(1.0f, 0.75f, 0.0f, 0.25f)},
                    }
                },
                {
                    SpreadRange.Double,
                    new Dictionary<bool, Color>
                    {
                        {false, new Color(1.0f, 0.50f, 0.0f, 1.0f)},
                        {true, new Color(1.0f, 0.50f, 0.0f, 0.25f)},
                    }
                },
                {
                    SpreadRange.Triple,
                    new Dictionary<bool, Color>
                    {
                        {false, new Color(1.0f, 0.00f, 0.0f, 1.0f)},
                        {true, new Color(1.0f, 0.00f, 0.0f, 0.25f)},
                    }
                },
            };
        }
    }
}