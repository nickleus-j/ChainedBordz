using System.Security.Cryptography;
using System.Text;

namespace ChainedBordz.Entities
{
    public class Node
    {
        public object Data { get; set; }
        public string Name { get; set; }
        public string Hash { get; set; }
        public Node? PreviousNode { get; set; }
        public static Node CreateNode(object _data, string _name="", Node? prev = null)
        {
            return new Node(_data, _name, prev);
        }
        private Node(object _data,string _name,Node? prev=null)
        {
            Data = _data;
            Name = _name;
            Hash = CalculateHash();
            PreviousNode = prev;
        }
        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{Name}-{Data}{DateTime.UtcNow}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}