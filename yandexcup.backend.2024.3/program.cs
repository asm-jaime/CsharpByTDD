using System;
using System.Collections.Generic;

namespace yandexcupbackend20243
{
    class AccessibleContainer
    {
        public int VillageNumber;
        public string LocationType;
        public int ShipIndex;
        public int StackIndex;
        public int PlatformSlot;

        public AccessibleContainer(int villageNumber, string locationType, int shipIndex = -1, int stackIndex = -1, int platformSlot = -1)
        {
            VillageNumber = villageNumber;
            LocationType = locationType;
            ShipIndex = shipIndex;
            StackIndex = stackIndex;
            PlatformSlot = platformSlot;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int h = int.Parse(input[1]);

            // Read li
            input = Console.ReadLine().Split();
            int[] li = new int[n];
            for (int i = 0; i < n; i++)
            {
                li[i] = int.Parse(input[i]);
            }

            List<List<Stack<int>>> ships = new List<List<Stack<int>>>();

            for (int i = 0; i < n; i++)
            {
                int numStacks = li[i];
                List<Stack<int>> shipStacks = new List<Stack<int>>();
                for (int j = 0; j < numStacks; j++)
                {
                    input = Console.ReadLine().Split();
                    int s = int.Parse(input[0]);
                    Stack<int> stack = new Stack<int>();
                    if (s > 0)
                    {
                        List<int> containers = new List<int>();
                        for (int k = 1; k <= s; k++)
                        {
                            int aj = int.Parse(input[k]);
                            containers.Add(aj);
                        }
                        containers.Reverse();
                        foreach (int aj in containers)
                        {
                            stack.Push(aj);
                        }
                    }
                    shipStacks.Add(stack);
                }
                ships.Add(shipStacks);
            }

            AccessibleContainer[] platform = new AccessibleContainer[4];

            List<int> cart = new List<int>();
            int cartVillageNumber = -1;

            while (true)
            {
                List<AccessibleContainer> accessibleContainers = new List<AccessibleContainer>();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < ships[i].Count; j++)
                    {
                        Stack<int> stack = ships[i][j];
                        if (stack.Count > 0)
                        {
                            int villageNumber = stack.Peek();
                            accessibleContainers.Add(new AccessibleContainer(villageNumber, "Ship", i, j));
                        }
                    }
                }

                for (int p = 0; p < 4; p++)
                {
                    if (platform[p] != null)
                    {
                        int villageNumber = platform[p].VillageNumber;
                        accessibleContainers.Add(new AccessibleContainer(villageNumber, "Platform", platformSlot: p));
                    }
                }

                if (accessibleContainers.Count == 0)
                {
                    break;
                }

                Dictionary<int, int> villageCounts = new Dictionary<int, int>();
                foreach (var ac in accessibleContainers)
                {
                    if (!villageCounts.ContainsKey(ac.VillageNumber))
                        villageCounts[ac.VillageNumber] = 0;
                    villageCounts[ac.VillageNumber]++;
                }

                int selectedVillage = -1;
                int maxCount = -1;
                foreach (var kvp in villageCounts)
                {
                    if (kvp.Value > maxCount)
                    {
                        selectedVillage = kvp.Key;
                        maxCount = kvp.Value;
                    }
                }

                cart.Clear();
                cartVillageNumber = selectedVillage;

                for (int p = 0; p < 4; p++)
                {
                    if (platform[p] != null && platform[p].VillageNumber == selectedVillage)
                    {
                        cart.Add(selectedVillage);
                        Console.WriteLine("2 {0}", p + 1);
                        platform[p] = null;
                        if (cart.Count == h)
                            break;
                    }
                }

                bool platformFull = false;
                bool actionTaken = true;

                while (cart.Count < h && actionTaken)
                {
                    actionTaken = false;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < ships[i].Count; j++)
                        {
                            Stack<int> stack = ships[i][j];
                            if (stack.Count > 0)
                            {
                                int topVillage = stack.Peek();
                                if (topVillage == selectedVillage)
                                {
                                    stack.Pop();
                                    cart.Add(topVillage);
                                    Console.WriteLine("1 {0} {1} 0", i + 1, j + 1);
                                    actionTaken = true;
                                    break;
                                }
                                else
                                {
                                    int platformSlot = -1;
                                    for (int p = 0; p < 4; p++)
                                    {
                                        if (platform[p] == null)
                                        {
                                            platformSlot = p;
                                            break;
                                        }
                                    }
                                    if (platformSlot != -1)
                                    {
                                        int containerVillage = stack.Pop();
                                        platform[platformSlot] = new AccessibleContainer(containerVillage, "Platform", platformSlot: platformSlot);
                                        Console.WriteLine("1 {0} {1} {2}", i + 1, j + 1, platformSlot + 1);
                                        actionTaken = true;
                                        if (stack.Count > 0 && stack.Peek() == selectedVillage && cart.Count < h)
                                        {
                                            stack.Pop();
                                            cart.Add(selectedVillage);
                                            Console.WriteLine("1 {0} {1} 0", i + 1, j + 1);
                                            if (cart.Count == h)
                                            {
                                                actionTaken = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        platformFull = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (platformFull || cart.Count == h)
                            break;
                    }
                }

                if (cart.Count > 0)
                {
                    Console.WriteLine("3");
                }
            }

            Console.WriteLine("0");
        }
    }
}

