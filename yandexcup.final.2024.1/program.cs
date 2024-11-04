using System;
using System.Collections.Generic;

namespace yandexcupfinal20241;


class Solution
{
    static void Main(string[] args)
    {
        var artifacts = new Dictionary<string, string>();
        var partToArtifact = new HashSet<string>();
        int artifactCounter = 1;

        while(true)
        {
            string line = Console.ReadLine();
            if(line == null) break;

            string[] tokens = line.Split();
            if(tokens.Length == 0) continue;

            string command = tokens[0];

            if(command == "EXIT")
            {
                break;
            }
            else if(command == "CREATE")
            {
                string partId = tokens[1];
                if(partToArtifact.Contains(partId))
                {
                    Console.WriteLine("ERROR: EXISTING PART");
                }
                else
                {
                    string artifactId = "a" + artifactCounter++;

                    partToArtifact.Add(partId);
                    artifacts[artifactId] = partId;
                    Console.WriteLine(artifactId);
                }
            }
            else if(command == "MERGE")
            {
                string artifactId1 = tokens[1];
                string artifactId2 = tokens[2];

                if(!artifacts.ContainsKey(artifactId1) || !artifacts.ContainsKey(artifactId2))
                {
                    continue;
                }

                string newArtifactId = "a" + artifactCounter++; // удалить a и проверить примет ли результат

                artifacts[newArtifactId] = $"{artifacts[artifactId1]} {artifacts[artifactId2]}";

                artifacts.Remove(artifactId1);
                artifacts.Remove(artifactId2);

                Console.WriteLine(newArtifactId);
            }
            else if(command == "GET_PARTS")
            {
                string artifactId = tokens[1];
                if(!artifacts.ContainsKey(artifactId))
                {
                    Console.WriteLine("ERROR: NO SUCH ARTEFACT");
                }
                else
                {
                    Console.WriteLine(artifacts[artifactId]);
                }
            }
        }
    }
}



