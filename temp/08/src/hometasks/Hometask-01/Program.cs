using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alexandr_safarov.Hometask_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10);
            while (game.winner==null)
            {
                game.Round();
            }

        }
    }
}