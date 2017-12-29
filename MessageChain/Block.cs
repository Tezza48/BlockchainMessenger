using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;

namespace MessageChain
{
    [Serializable]
    public class Block
    {

        public int m_Index;
        public byte[] m_PreveousHash;
        public Message[] m_Messages;
        public int m_Nonce;
        public byte[] m_ThisHash;

        public byte[] Hash { get => m_ThisHash; }
        public int Index { get => m_Index; }

        internal Block() { }

        public Block(int index, byte[] prev, Message[] messages)
        {
            m_Index = index;
            m_PreveousHash = prev;
            m_Messages = messages;
            m_Nonce = 0;
            m_ThisHash = new byte[0];
        }

        public void MineBlock(int difficulty)
        {
            Console.WriteLine("Mining block " + m_Index);
            var timer = Stopwatch.StartNew();
            bool[] check = Enumerable.Repeat<bool>(false, difficulty).ToArray();
            bool isValid = false;
            while (!isValid)
            {
                m_Nonce++;
                m_ThisHash = CalculateHash();

                BitArray rawBitArray = new BitArray(m_ThisHash);
                bool[] bits = new bool[rawBitArray.Length];
                rawBitArray.CopyTo(bits, 0);

                isValid = Enumerable.SequenceEqual(bits.Take(difficulty).ToArray(), check);
                
            }
            timer.Stop();
            Console.WriteLine("Elapsed Time: " + timer.Elapsed.TotalSeconds.ToString("n2"));
        }

        private byte[] CalculateHash()
        {
            SHA256 sha = new SHA256Managed();

            byte[] digest = sha.ComputeHash(getByteArray());

            return digest;
        }

        private byte[] getByteArray()
        {
            BinaryFormatter bf = new BinaryFormatter();

            using(MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public string ToString(string format = "")
        {
            string output = "";

            if (format == "f")
            {
                output += "Index: " + m_Index + "\n";
                output += "Parent: " + m_PreveousHash + "\n";
                output += "Messages:\n";
                foreach (Message message in m_Messages)
                {
                    output += message.ToString(format) + "\n";
                }
                output += "Nonce: " + m_Nonce + "\n";
                output += "Hash: " + m_ThisHash + "\n";
            }
            else
            {
                output += m_Index;
                output += m_PreveousHash;
                foreach (Message message in m_Messages)
                {
                    output += message.ToString();
                }
                output += m_Nonce;
            }
            return output;
        }
    }
}
