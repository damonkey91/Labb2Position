using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Labb2Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");

            // Tar bort lista1 från lista 3. Utskrift: (1,2), (3,6)
            SortedPosList list3 = new SortedPosList();
            list3.Add(new Position(3, 7));
            list3.Add(new Position(1, 2));
            list3.Add(new Position(3, 6));
            list3.Add(new Position(2, 3));
            Console.WriteLine((list3 - list1) + "subtract" + "\n");

            //Spara lista till fil. Utskrift: (2,1),(4,6),(5,8) list saved to file
            SortedPosList list4 = new SortedPosList("positionlist");
            list4.Add(new Position(2, 1));
            list4.Add(new Position(4, 6));
            list4.Add(new Position(5, 8));
            Console.WriteLine(list4 + " list saved to file" + "\n");

            //Ladda lista från fil. Utskrift: (2,1),(4,6),(5,8) list loaded from file
            SortedPosList list5 = new SortedPosList("positionlist");
            Console.WriteLine(list5 + " list loaded from file");
        }
    }
}
