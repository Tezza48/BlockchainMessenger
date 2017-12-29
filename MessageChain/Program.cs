using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageChain
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain chain = new BlockChain();

            Queue<Message> messagePool = new Queue<Message>();

            messagePool.Enqueue(new Message("Will", "Rafa", "Hi Dude"));
            messagePool.Enqueue(new Message("Rafa", "Will", "sup"));
            messagePool.Enqueue(new Message("Will", "Rafa", "Lorem ipsum dolor sit amet, consectetur adipiscing elit"));
            messagePool.Enqueue(new Message("Rafa", "Will", "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."));
            messagePool.Enqueue(new Message("Will", "Rafa", "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."));
            messagePool.Enqueue(new Message("Rafa", "Will", "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."));
            messagePool.Enqueue(new Message("Will", "Rafa", "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."));

            chain.AddBlock(new Message[] { messagePool.Dequeue(), messagePool.Dequeue() });
            chain.AddBlock(new Message[] { messagePool.Dequeue(), messagePool.Dequeue(), messagePool.Dequeue() });
            chain.AddBlock(new Message[] { messagePool.Dequeue(), messagePool.Dequeue() });

            Console.WriteLine();

            Console.Write(chain.ToString());

            Console.ReadKey();
        }
    }
}
