using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class MemoryZone
    {
        private Dictionary<string, object> store;
        private MemoryZone parentZone;


        public MemoryZone(MemoryZone parent = null)
        {
            Store = new Dictionary<string, object>();
            if (parent != null)
            {
                ParentZone = parent;
            }
        }

        public MemoryZone ParentZone {
            get => parentZone;
            set
            {
                parentZone = value;
                for(int i = 0; i < parentZone.Store.Count; i++)
                {
                    string key = parentZone.Store.Keys.ToList()[i];
                    this.Store.Add(key,null);
                    this.Store[key] = parentZone.Store[key];
                }
            }

        }

        public Dictionary<string, object> Store { get => store; set => store = value; }

        public bool AssignVar(string name, ExpressionComponent var)
        {
            if (!Store.ContainsKey(name))
            {
                Store.Add(name, var);
                return true;
            }
            return false;
        }

        public T GetVar<T>(string name)
        {
            if (Store.ContainsKey(name))
                return (T)(Store[name]);
            return (T)(new Operands.Null() as object);
        }

    }
}
