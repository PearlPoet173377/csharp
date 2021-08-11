using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexandr_safarov.Hometask_01
{
    interface IGameControl
    {
        void InicializeDeck() { }
        void InicializePlayers() { }
        void Mix() { }
        void Distribute() { }

    }
}