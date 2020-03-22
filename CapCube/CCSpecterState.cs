using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapCube
{
    static class CCSpecterState
    {
        public enum State
        {
            Stand,
            Walk,
            CloseAttack,
            FarAttack,
            Hurt,
            Faint,
        }
    }
}
