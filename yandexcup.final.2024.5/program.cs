using System;
using System.Collections.Generic;

namespace yandexcupfinal20245;

class Program
{
    const int TOTAL_PARTS = 18;
    const int SERVERS = 6;
    const int PARTS_PER_SERVER = 3;

    static int[] serverPossibleParts = new int[SERVERS];
    static int[] serverAssignedPartsCount = new int[SERVERS];
    static int[] serverAssignedParts = new int[SERVERS];

    static int[] partAssignedToServer = new int[TOTAL_PARTS];
    static int totalWays = 0;

    static void Main(string[] args)
    {

        for(int i = 0; i < SERVERS; i++)
        {
            serverPossibleParts[i] = (1 << TOTAL_PARTS) - 1;
            serverAssignedPartsCount[i] = 0;
            serverAssignedParts[i] = 0;
        }
        for(int i = 0; i < TOTAL_PARTS; i++)
        {
            partAssignedToServer[i] = -1;
        }

        int N = int.Parse(Console.ReadLine());
        for(int i = 0; i < N; i++)
        {
            string[] line = Console.ReadLine().Split();
            int si = int.Parse(line[0]) - 1;
            int ki = int.Parse(line[1]);
            for(int j = 0; j < ki; j++)
            {
                int sij = int.Parse(line[2 + 2 * j]);
                int pij = int.Parse(line[3 + 2 * j]);
                int partId = MapPartToId(sij, pij);
                AssignPartToServer(partId, si);
            }
        }

        // Read log entries
        int M = int.Parse(Console.ReadLine());
        for(int i = 0; i < M; i++)
        {
            string[] line = Console.ReadLine().Split();
            int s = int.Parse(line[0]) - 1;
            int r1 = int.Parse(line[1]);
            int r2 = int.Parse(line[2]);
            int r3 = int.Parse(line[3]);
            int t = int.Parse(line[4]) - 1;

            int[] requestedParts = new int[3];
            requestedParts[0] = MapPartToId(1, r1);
            requestedParts[1] = MapPartToId(2, r2);
            requestedParts[2] = MapPartToId(3, r3);

            ApplyLogConstraints(s, t, requestedParts);
        }


        Search(0, 0);

        Console.WriteLine(totalWays);
    }


    static int MapPartToId(int section, int part)
    {
        int baseId = (section - 1) * 6;
        return baseId + (part - 4);
    }

    static void AssignPartToServer(int partId, int server)
    {
        if(partAssignedToServer[partId] != -1 && partAssignedToServer[partId] != server)
        {

            Console.WriteLine(0);
            Environment.Exit(0);
        }
        partAssignedToServer[partId] = server;
        serverAssignedParts[server] |= (1 << partId);
        serverAssignedPartsCount[server]++;
        for(int i = 0; i < SERVERS; i++)
        {
            if(i != server)
            {
                serverPossibleParts[i] &= ~(1 << partId);
            }
        }
        serverPossibleParts[server] |= (1 << partId);
    }

    static void ApplyLogConstraints(int s, int t, int[] requestedParts)
    {

        int current = s;
        while(true)
        {
            current = (current + 1) % SERVERS;
            if(current == t)
                break;
            foreach(int partId in requestedParts)
            {
                serverPossibleParts[current] &= ~(1 << partId);
            }
        }

        if(s == t)
        {

            for(int i = 0; i < SERVERS; i++)
            {
                if(i != s)
                {
                    foreach(int partId in requestedParts)
                    {
                        serverPossibleParts[i] &= ~(1 << partId);
                    }
                }
            }
        }




        int possiblePartsMask = 0;
        foreach(int partId in requestedParts)
        {
            possiblePartsMask |= (1 << partId);
        }
        serverPossibleParts[t] &= possiblePartsMask;
    }

    static void Search(int serverIndex, int assignedPartsMask)
    {
        if(serverIndex == SERVERS)
        {
            totalWays++;
            return;
        }

        if(serverAssignedPartsCount[serverIndex] == PARTS_PER_SERVER)
        {

            Search(serverIndex + 1, assignedPartsMask);
            return;
        }


        int possibleParts = serverPossibleParts[serverIndex] & ~assignedPartsMask;


        int neededParts = PARTS_PER_SERVER - serverAssignedPartsCount[serverIndex];
        List<int> partsList = GetSetBits(possibleParts);
        if(partsList.Count < neededParts)
        {

            return;
        }

        IEnumerable<IEnumerable<int>> combinations = GetCombinations(partsList, neededParts);

        foreach(var combo in combinations)
        {
            int newAssignedMask = assignedPartsMask;
            foreach(int partId in combo)
            {
                newAssignedMask |= (1 << partId);
            }

            serverAssignedPartsCount[serverIndex] = PARTS_PER_SERVER;
            Search(serverIndex + 1, newAssignedMask);
            serverAssignedPartsCount[serverIndex] = PARTS_PER_SERVER - neededParts;
        }
    }

    static List<int> GetSetBits(int bitmask)
    {
        List<int> bits = new List<int>();
        for(int i = 0; i < TOTAL_PARTS; i++)
        {
            if((bitmask & (1 << i)) != 0)
                bits.Add(i);
        }
        return bits;
    }

    static IEnumerable<IEnumerable<int>> GetCombinations(List<int> list, int k)
    {
        int n = list.Count;
        if(k > n)
            yield break;
        int[] result = new int[k];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        while(stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();
            while(value < n)
            {
                result[index++] = list[value++];
                stack.Push(value);
                if(index == k)
                {
                    yield return result;
                    break;
                }
            }
        }
    }
}

