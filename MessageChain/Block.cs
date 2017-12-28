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
        string m_PreveousHash;
        Message[] m_Messages;
        string m_ThisHash;

        public string Hash { get => m_ThisHash; }

        public Block(string prev, Message[] messages)
        {
            m_PreveousHash = prev;
            m_Messages = messages;
            m_ThisHash = CreateHash();
        }

        private string CreateHash()
        {
            SHA256 sha = new SHA256Managed();

            byte[] data = Encoding.ASCII.GetBytes(ToString());

            byte[] digest = sha.ComputeHash(data);

            return Encoding.ASCII.GetString(digest);
        }

        public string ToString(string format = "")
        {
            string output = "";

            if (format == "f")
            {
                output += "Parent: " + m_PreveousHash + "\n";
                output += "Messages:\n";
                foreach (Message message in m_Messages)
                {
                    output += message.ToString(format) + "\n";
                }
                output += "Hash: " + m_ThisHash + "\n";
            }
            else
            {
                output += m_PreveousHash;
                foreach (Message message in m_Messages)
                {
                    output += message.ToString();
                }


            }
            return output;
        }
    }
}
