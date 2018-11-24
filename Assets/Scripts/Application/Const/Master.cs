using System.Collections.Generic;
using Monry.Unity1Weeks.Binary.Application.Enum;
using UnityEngine;

namespace Monry.Unity1Weeks.Binary.Application
{
    public static partial class Const
    {
        public static class Master
        {
            public static IDictionary<GravityScale, float> GravityScaleMap { get; } = new Dictionary<GravityScale, float>
            {
                {GravityScale.Low, 1.0f/4},
                {GravityScale.Medium, 1.0f/2},
                {GravityScale.High, 1.0f/1},
            };

            public static IDictionary<SpreadRange, Color> SpreadRangeColorMap { get; } = new Dictionary<SpreadRange, Color>
            {
                {SpreadRange.Single, new Color(1.0f, 0.75f, 0.0f)},
                {SpreadRange.Double, new Color(1.0f, 0.50f, 0.0f)},
                {SpreadRange.Triple, new Color(1.0f, 0.00f, 0.0f)},
            };
        }
    }
}