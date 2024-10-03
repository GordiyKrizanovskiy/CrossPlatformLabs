namespace GK
{
    public class CityDistanceCalculator
    {
        public static double FindMinimumRadius(double[][] cities, int N)
        {
            List<Tuple<int, int, double>> edges = new List<Tuple<int, int, double>>();
        
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(cities[i][0] - cities[j][0], 2) + Math.Pow(cities[i][1] - cities[j][1], 2));
                    edges.Add(new Tuple<int, int, double>(i, j, distance));
                }
            }

            edges.Sort((x, y) => x.Item3.CompareTo(y.Item3));

            UnionFind uf = new UnionFind(N);
            double maxEdgeInMST = 0.0;

            foreach (var edge in edges)
            {
                if (!uf.Connected(edge.Item1, edge.Item2))
                {
                    uf.Union(edge.Item1, edge.Item2);
                    maxEdgeInMST = edge.Item3;

                    if (uf.Count == 1)
                    {
                        break;
                    }
                }
            }

            return maxEdgeInMST;
        }
    }

    public class UnionFind
    {
        private int[] parent;
        private int[] size;
        public int Count { get; private set; }

        public UnionFind(int n)
        {
            parent = new int[n];
            size = new int[n];
            Count = n;

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }
        }

        public int Find(int p)
        {
            if (p != parent[p])
            {
                parent[p] = Find(parent[p]);
            }
            return parent[p];
        }

        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP == rootQ) return;

            if (size[rootP] > size[rootQ])
            {
                parent[rootQ] = rootP;
                size[rootP] += size[rootQ];
            }
            else
            {
                parent[rootP] = rootQ;
                size[rootQ] += size[rootP];
            }

            Count--;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }
    }
}
