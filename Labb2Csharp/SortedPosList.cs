using System;
using System.Collections.Generic;

namespace Labb2Csharp
{
    public class SortedPosList
    {
        private string FilePath { get; set; }
        private List<Position> PositionList { get; set; }
        public Position this[int index] 
        { 
            get
            {
                return PositionList[index];
            } 
        }

        public SortedPosList()
        {
            PositionList = new List<Position>();
        }

        public SortedPosList(string filePath)
        {
            PositionList = new List<Position>();
            Load(filePath);
            FilePath = filePath;
        }

        public int Count()
        {
            return PositionList.Count;
        }

        public void Add(Position pos)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (PositionList[i].Length() > pos.Length())
                {
                    PositionList.Insert(i, pos);
                    Save(FilePath);
                    return;
                }
            }
            PositionList.Insert(Count(), pos);
            Save(FilePath);
        }

        public bool Remove(Position pos)
        {
            for (int i = 0; i < Count(); i++)
            {
                if (pos.XPosition == PositionList[i].XPosition && pos.YPosition == PositionList[i].YPosition)
                {
                    PositionList.RemoveAt(i);
                    Save(FilePath);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList posList = new SortedPosList();
            foreach (Position position in PositionList)
            {
                posList.Add(position.Clone());
            }
            return posList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList circleContList = new SortedPosList();
            foreach (Position position in PositionList)
            {
                if (Math.Pow((position.XPosition - centerPos.XPosition), 2) + Math.Pow((position.YPosition - centerPos.YPosition), 2) < Math.Pow(radius, 2))
                {
                    circleContList.Add(position.Clone());
                }
            }
            return circleContList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList sortedPosList = new SortedPosList();
            LoopThroughAndAdd(sp1, sortedPosList);
            LoopThroughAndAdd(sp2, sortedPosList);
            return sortedPosList;
        }

        private static void LoopThroughAndAdd(SortedPosList sp, SortedPosList newSortedPosList)
        {
            foreach (Position position in sp.PositionList)
            {
                newSortedPosList.Add(position.Clone());
            }
        }

        public override string ToString()
        {
            return string.Join(",", PositionList);
        }

        public static SortedPosList operator -(SortedPosList s1, SortedPosList s2)
        { 
            for (int i = 0; i < s1.Count(); i++)
            {
                foreach (Position position2 in s2.PositionList)
                {
                    if (s1[i].Equals(position2))
                    {
                        s1.Remove(s1[i]);
                    }
                }
            }
            return s1;
        }

        private void Save(string filePath)
        {
            if (filePath != null)
            {
                System.IO.File.WriteAllText(filePath, ListToFileString());
            }
        }

        private void Load(string filePath)
        {
            try
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace("(", "");
                text = text.Replace(")", "");
                text = text.Trim();
                string[] spliText = text.Split("\n");
                StringTopList(spliText);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("File dosen't exist");
            }
        }

        private string ListToFileString()
        {
            string text = "";
            foreach (Position position in PositionList)
            {
                text += position + "\n";
            }
            return text;
        }

        private void StringTopList(string[] splitText)
        {
            List<Position> tempList = new List<Position>();
            foreach (string tt in splitText)
            {
                string[] cords = tt.Split(",");
                tempList.Add(new Position(int.Parse(cords[0]), int.Parse(cords[1])));
            }
            PositionList = tempList;
        }
    }
}
