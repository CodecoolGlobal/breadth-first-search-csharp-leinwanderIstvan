using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    class BreadthFirstSearch
    {

        public int DistanceBetweenUsers(UserNode from, UserNode to)
        {
            Queue<UserNode> searchInQueue = new Queue<UserNode>();
            List<UserNode> visited = new List<UserNode>();
            

            if (from.Equals(to))
            {
                return 0;
            }

            List<UserNode> temp = new List<UserNode>();
            int distance = 0;
            searchInQueue.Enqueue(from);
            while (searchInQueue.Count > 0)
            {
                UserNode nextUser = searchInQueue.Dequeue();
                if (nextUser.Equals(to))
                {
                    break;
                }

                if (visited.Contains(nextUser))
                {
                    continue;
                }

                visited.Add(nextUser);

                foreach (var friend in nextUser.Friends)
                {
                    if (!temp.Contains(friend))
                    {
                        temp.Add(friend);
                    }
                }

                if (searchInQueue.Count == 0 && temp.Count > 0)
                {
                    distance++;
                    foreach (var user in temp)
                    {
                        searchInQueue.Enqueue(user);
                    }
                    temp.Clear();
                }


            }

            return distance;
        }


        public void ListFriendsOfFriendsAtDistance(UserNode user, int distance)
        {
            Queue<UserNode> toVisit = new Queue<UserNode>();
            HashSet<UserNode> visited = new HashSet<UserNode>();
            Dictionary<UserNode, int> distanceFromRoot = new Dictionary<UserNode, int>();

            HashSet<UserNode> friendOfFriends = new HashSet<UserNode>();


            toVisit.Enqueue(user);
            visited.Add(user);
            distanceFromRoot.Add(user, 0);

            while (toVisit.Count > 0)
            {
                UserNode CurrentUser = toVisit.Dequeue();
                int currentDistance;
                distanceFromRoot.TryGetValue(CurrentUser, out currentDistance);

                if (currentDistance > distance) { break; }

                foreach (var friend in CurrentUser.Friends)
                {
                    if (!visited.Contains(friend))
                    {
                        toVisit.Enqueue(friend);
                        visited.Add(friend);
                        friendOfFriends.Add(friend);
                        distanceFromRoot.Add(friend, currentDistance + 1);
                    }
                }
            }


            foreach (var friend in friendOfFriends)
            {
                Console.WriteLine(friend.ToString());
            }

        }
    }
}
