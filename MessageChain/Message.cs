using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageChain
{
    struct Message
    {
        string m_Origin;
        string m_Target;
        string m_Message;
        string m_Timestamp;

        public Message(string m_Origin, string m_Target, string m_Message) : this()
        {
            this.m_Origin = m_Origin;
            this.m_Target = m_Target;
            this.m_Message = m_Message;
            m_Timestamp = DateTime.Now.ToString();
        }

        public string ToString(string format)
        {
            if (format == "f")
            {
                return "Origin: " + m_Origin + ", Target: " + m_Target + "\nMessage: " + m_Message + "\nTime: " + m_Timestamp + "\n";
            }
            else
            {
                return m_Origin + m_Target + m_Message + m_Timestamp;
            }
        }
    }
}
