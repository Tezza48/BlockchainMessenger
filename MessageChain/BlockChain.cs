using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageChain
{
    class BlockChain
    {
        List<Block> m_Blocks;
        int m_Difficulty = 3;

        public BlockChain()
        {
            m_Blocks = new List<Block>() { CreateGenesisBlock() };
            m_Blocks.Last().MineBlock(m_Difficulty);
        }

        private Block CreateGenesisBlock()
        {
            return new Block(0, "0", new Message[] { new Message("All", "All", "Genesis Block") });
        }

        public void AddBlock(Message[] messages)
        {
            m_Blocks.Add(new Block(m_Blocks.Last().Index +1, m_Blocks.Last().Hash, messages));
            m_Blocks.Last().MineBlock(m_Difficulty);
        }

        public override string ToString()
        {
            string output = "";

            foreach (Block block in m_Blocks)
            {
                output += block.ToString("f") + "\n";
                output += "- - - - - - - - - - - - - - - - - - - -\n";
            }


            return output;
        }
    }
}
