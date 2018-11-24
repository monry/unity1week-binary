using CAFU.Core;
using Monry.Unity1Weeks.Binary.Application.Enum;

namespace Monry.Unity1Weeks.Binary.Structure
{
    public struct BitAttribute : IStructure
    {
        public int Digit;
        public SpreadRange SpreadRange;
        public GravityScale GravityScale;
    }
}