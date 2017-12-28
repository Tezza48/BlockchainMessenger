using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace MessageChain
{
    class Block
    {
        int m_Index;
        string m_PreveousHash;
        Message[] m_Messages;
        int m_Nonce;
        string m_ThisHash;

        public string Hash { get => m_ThisHash; }
        public int Index { get => m_Index; }

        public Block(int index, string prev, Message[] messages)
        {
            m_Index = index;
            m_PreveousHash = prev;
            m_Messages = messages;
            m_Nonce = 0;
            m_ThisHash = "";
        }

        public void MineBlock(int difficulty)
        {
            Console.WriteLine("Mining block " + m_Index);
            while (!m_ThisHash.StartsWith(new string('0', difficulty)))
            {
                m_Nonce++;
                m_ThisHash = CalculateHash();
            }
        }

        private string CalculateHash()
        {
            SHA256 sha = new SHA256Managed();

            byte[] data = Encoding.ASCII.GetBytes(ToString());

            byte[] digest = sha.ComputeHash(data);

            string hash = "";
            //foreach (byte item in digest)
            //{
            //    hash += Convert.ToString(item, 2).PadLeft(8, '0');
            //}

            return Encoding.ASCII.GetString(digest);
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
