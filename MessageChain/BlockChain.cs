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

        public BlockChain()
        {
            m_Blocks = new List<Block>() { CreateGenesisBlock() };
        }

        private Block CreateGenesisBlock()
        {
            return new Block("0", new Message[] { new Message("All", "All", "Genesis Block") });
        }

        public void AddBlock(Message[] messages)
        {
            m_Blocks.Add(new Block(m_Blocks.Last().Hash, messages));
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
