using System;
using System.Collections.Generic;
using System.IO;

namespace yandexcupfinal20244;


class Solution
{
    private long MAX_RPS;
    private Dictionary<string, int> ipMaxRPS = new Dictionary<string, int>();
    private Dictionary<long, int> totalRequestsPerSecond = new Dictionary<long, int>();
    private Queue<(long timestamp, string ip, bool isFiltered)> recentRequests = new Queue<(long, string, bool)>();
    private Dictionary<string, int> ipRecentFilteredCounts = new Dictionary<string, int>();
    private Dictionary<string, Queue<long>> ipRequestTimestamps = new Dictionary<string, Queue<long>>();
    private int totalAllowedRequests = 0;
    private int totalFilteredRequests = 0;
    private long currentSecond = -1;

    private const int WINDOW_SIZE = 30 * 1000;

    public void Initialize(string historicalDataPath)
    {
        using var reader = new StreamReader(historicalDataPath);
        string line;
        Dictionary<long, int> requestsPerSecond = new Dictionary<long, int>();

        while((line = reader.ReadLine()) != null)
        {
            var parts = line.Split(',');

            if(parts.Length != 3)
                continue;

            long timestamp = long.Parse(parts[0]);
            string ip = parts[1];

            long second = timestamp / 1000;

            if(!requestsPerSecond.ContainsKey(second))
                requestsPerSecond[second] = 0;

            requestsPerSecond[second]++;

            if(!ipMaxRPS.ContainsKey(ip))
                ipMaxRPS[ip] = 0;

            ipMaxRPS[ip]++;
        }

        MAX_RPS = 0;
        foreach(var kvp in requestsPerSecond)
        {
            if(kvp.Value > MAX_RPS)
                MAX_RPS = kvp.Value;
        }
    }

    public void ProcessCommands()
    {
        Console.WriteLine("START");
        Console.Out.Flush();

        string inputLine;
        while((inputLine = Console.ReadLine()) != null)
        {
            if(inputLine.StartsWith("REQ"))
            {
                var parts = inputLine.Split(' ');
                if(parts.Length != 4)
                    continue;

                long timestamp = long.Parse(parts[1]);
                string ip = parts[2];
                string payload = parts[3];

                bool isAllowed = ShouldAllowRequest(timestamp, ip);

                Console.WriteLine(isAllowed ? "OK" : "DDOS");
                Console.Out.Flush();
            }
            else if(inputLine == "SHUTDOWN")
            {
                Environment.Exit(0);
            }
        }
    }

    private bool ShouldAllowRequest(long timestamp, string ip)
    {
        long second = timestamp / 1000;

        if(currentSecond != second)
        {
            currentSecond = second;
            totalAllowedRequests = 0;
            totalFilteredRequests = 0;
        }

        // Update per-IP request timestamps
        if(!ipRequestTimestamps.ContainsKey(ip))
            ipRequestTimestamps[ip] = new Queue<long>();

        var ipTimestamps = ipRequestTimestamps[ip];

        ipTimestamps.Enqueue(timestamp);

        while(ipTimestamps.Count > 0 && timestamp - ipTimestamps.Peek() >= 1000)
        {
            ipTimestamps.Dequeue();
        }

        int ipRequestCount = ipTimestamps.Count;

        int ipHistoricalMaxRPS = ipMaxRPS.ContainsKey(ip) ? ipMaxRPS[ip] : 1; // Default to 1 if unknown IP

        if(ipRequestCount > ipHistoricalMaxRPS * 2)
        {
            totalFilteredRequests++;
            RecordFilteredRequest(timestamp, ip);
            return false;
        }

        totalAllowedRequests++;

        if(totalAllowedRequests > MAX_RPS * 2)
        {
            totalFilteredRequests++;
            RecordFilteredRequest(timestamp, ip);
            return false;
        }

        RecordAllowedRequest(timestamp, ip);
        return true;
    }

    private void RecordFilteredRequest(long timestamp, string ip)
    {
        recentRequests.Enqueue((timestamp, ip, true));
        UpdateRecentRequests(timestamp);
        UpdateFilteredCounts(ip, true);
    }

    private void RecordAllowedRequest(long timestamp, string ip)
    {
        recentRequests.Enqueue((timestamp, ip, false));
        UpdateRecentRequests(timestamp);
        UpdateFilteredCounts(ip, false);
    }

    private void UpdateRecentRequests(long currentTimestamp)
    {
        // Remove requests older than 30 seconds
        while(recentRequests.Count > 0 && currentTimestamp - recentRequests.Peek().timestamp >= WINDOW_SIZE)
        {
            var oldRequest = recentRequests.Dequeue();
            UpdateFilteredCounts(oldRequest.ip, oldRequest.isFiltered, remove: true);
        }
    }

    private void UpdateFilteredCounts(string ip, bool isFiltered, bool remove = false)
    {
        int delta = remove ? -1 : 1;

        if(isFiltered)
        {
            if(!ipRecentFilteredCounts.ContainsKey(ip))
                ipRecentFilteredCounts[ip] = 0;

            ipRecentFilteredCounts[ip] += delta;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string historicalDataPath = args[0];

        var solution = new Solution();
        solution.Initialize(historicalDataPath);
        solution.ProcessCommands();
    }
}
