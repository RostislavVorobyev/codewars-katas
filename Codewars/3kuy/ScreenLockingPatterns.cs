/*
 * Screen Locking Patterns: https://www.codewars.com/kata/585894545a8a07255e0002f1/train/csharp/62f96c46eb6d08003b68b5c0
 */
using System;
using System.Collections.Generic;

namespace Codewars
{
    public static class ScreenLockingPatterns
    {
        public static int CountPatternsFrom(char firstDot, int length)
        {
            var c = firstDot - 65;
            ScreenLogingPathFinder pathFinder = new ScreenLogingPathFinder(c);

            return pathFinder.CountPaths(c, length);
        }
    }

    public class ScreenLogingPathFinder
    {
        private Func<bool>[][] screenLocker;
        private readonly bool[] visited;
        private readonly List<int> localPath;

        public ScreenLogingPathFinder(int startingNode)
        {
            InitLockingMattrix();
            visited = new bool[9];
            localPath = new List<int>() { startingNode };
        }

        private void InitLockingMattrix()
        {
            screenLocker = new Func<bool>[9][] {
                new Func<bool>[] { () => false, () =>  true, () => localPath.Contains(1), () => true, () => true, () => true, () => localPath.Contains(3), () => true, () => localPath.Contains(4)  },
                new Func<bool>[] { () => true, () => false, () => true, () => true, () => true, () => true, () => true, () => localPath.Contains(4), () => true },

                new Func<bool>[] { () => localPath.Contains(1), () =>  true, () => false, () => true, () => true, () => true, () => localPath.Contains(4), () => true, () => localPath.Contains(5)  },
                new Func<bool>[] { () => true, () =>  true, () => true, () => false, () => true, () => localPath.Contains(4), () => true, () => true, () => true },

                new Func<bool>[] { () => true, () =>  true, () => true, () => true, () => false, () => true, () => true, () => true, () => true },

                new Func<bool>[] { () => true, () =>  true, () => true, () => localPath.Contains(4), () => true, () => false, () => true, () => true, () => true },

                new Func<bool>[] { () => localPath.Contains(3), () =>  true, () => localPath.Contains(4), () => true, () => true, () => true, () => false, () => true, () => localPath.Contains(7)  },
                new Func<bool>[] { () => true, () => localPath.Contains(4), () => true, () => true, () => true, () => true, () => true, () => false, () => true },
                new Func<bool>[] { () => localPath.Contains(4), () =>  true, () => localPath.Contains(5), () => true, () => true, () => true, () => localPath.Contains(7), () => true, () => false }
            };
        }

        public int CountPaths(int node, int limit)
        {
            int paths = 0;

            FindAllPaths(node, limit, ref paths);

            return paths;
        }

        public void FindAllPaths(int node, int limit, ref int pathCounter)
        {
            if (localPath.Count == limit)
            {
                pathCounter++;
                return;
            }

            visited[node] = true;

            for (int i = 0; i < screenLocker.Length; i++)
            {
                if (screenLocker[node][i]() && !visited[i])
                {
                    localPath.Add(i);
                    FindAllPaths(i, limit, ref pathCounter);

                    localPath.Remove(i);
                }
            }

            visited[node] = false;
        }
    }
}