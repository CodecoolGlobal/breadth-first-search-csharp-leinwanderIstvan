using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();
            BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            
            
            int distance = breadthFirstSearch.DistanceBetweenUsers(users[0], users[1]);
            Console.WriteLine("Distance between friends: " + distance);
            Console.WriteLine("Friends of Friends: ");
            breadthFirstSearch.FriendsOfFriendsAtGivenDistance(users[0], 10);
            Console.ReadKey();
            
        }
    }
}
