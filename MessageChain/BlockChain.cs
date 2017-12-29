using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageChain
{
    [Serializable]
    public class BlockChain
    {
        public List<Block> m_Blocks;
        public int m_Difficulty = 20;

        public BlockChain()
        {
            m_Blocks = new List<Block>() { CreateGenesisBlock() };
            m_Blocks.Last().MineBlock(m_Difficulty);
        }

        private Block CreateGenesisBlock()
        {
            return new Block(0, new byte[0], new Message[] { new Message("All", "All", "Genesis Block") });
        }

        public void AddBlock(Message[] messages)
        {
            m_Blocks.Add(new Block(m_Blocks.Last().Index +1, m_Blocks.Last().Hash, messages));
            m_Blocks.Last().MineBlock(m_Difficulty);
        }

        public override string ToString()
        {
            XmlSerializer xml = new XmlSerializer(typeof(BlockChain));

            using(MemoryStream ms = new MemoryStream())
            {
                xml.Serialize(ms, this);
                var s = Encoding.Default.GetString(ms.ToArray());
                return Encoding.Default.GetString(ms.ToArray());
            }

            /*

            foreach (Block block in m_Blocks)
            {
                output += block.ToString("f") + "\n";
                output += "- - - - - - - - - - - - - - - - - - - -\n";
            }


            */
        }
    }
}
