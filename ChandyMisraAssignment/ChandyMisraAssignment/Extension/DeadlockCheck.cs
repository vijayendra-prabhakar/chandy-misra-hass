namespace ChandyMisraAssignment.Extension
{
    public class ChandyMisraHaas
    {
        private List<List<int>> graph;
        private int numProcesses;

        public ChandyMisraHaas(List<List<int>> g, int n)
        {
            graph = g;
            numProcesses = n;
        }

        public bool IsDeadlocked()
        {
            var marked = new bool[numProcesses];
            var requests = new List<Process>[numProcesses];
            var releases = new List<Process>[numProcesses];
            var visited = new bool[numProcesses];
            var stack = new Stack<int>();
            var current = 0;

            for (int i = 0; i < numProcesses; i++)
            {
                requests[i] = new List<Process>();
                releases[i] = new List<Process>();
            }

            while (current < numProcesses)
            {
                if (!visited[current])
                {
                    stack.Push(current);
                    visited[current] = true;

                    for (int i = 0; i < numProcesses; i++)
                    {
                        if (graph[current][i] > 0 && !visited[i])
                        {
                            stack.Push(i);
                            visited[i] = true;
                        }
                    }
                }

                while (stack.Any())
                {
                    var processId = stack.Pop();
                    var process = new Process { Id = processId, Marked = marked[processId] };

                    foreach (var r in releases[processId])
                    {
                        if (!marked[r.Id])
                        {
                            marked[r.Id] = true;
                            stack.Push(r.Id);
                        }
                    }

                    foreach (var r in requests[processId])
                    {
                        releases[r.Id].Add(process);
                    }

                    requests[processId].Clear();
                }

                current++;

                for (int i = 0; i < numProcesses; i++)
                {
                    if (!marked[i] && requests[i].Any())
                    {
                        marked[i] = true;
                        stack.Push(i);
                    }
                }
            }

            return marked.All(m => m);
        }
    }
}
