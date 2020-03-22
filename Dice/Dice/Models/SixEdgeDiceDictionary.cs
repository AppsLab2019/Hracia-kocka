using System;
using System.Collections.Generic;
using System.Text;

namespace Dice.Models
{
    class SixEdgeDiceDictionary
    {
        public void ImageForSixEdgeDice()
        {
            Dictionary<int, string> sixEdgeDiceDictionary = new Dictionary<int, string>();
            sixEdgeDiceDictionary.Add(1, "/dravable/Dice1.jpg");
            sixEdgeDiceDictionary.Add(2, "/dravable/Dice2.jpg");
            sixEdgeDiceDictionary.Add(3, "/dravable/Dice3.jpg");
            sixEdgeDiceDictionary.Add(4, "/dravable/Dice4.jpg");
            sixEdgeDiceDictionary.Add(5, "/dravable/Dice5.jpg");
            sixEdgeDiceDictionary.Add(6, "/dravable/Dice6.jpg");
        }
    }
}
