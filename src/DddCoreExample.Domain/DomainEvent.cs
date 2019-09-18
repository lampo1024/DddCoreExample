using System;
using System.Collections.Generic;

namespace DddCoreExample.Domain
{
    public abstract class DomainEvent
    {
        public string Type
        {
            get { return this.GetType().Name; }
        }

        public DateTime Created { get; private set; }
        public Dictionary<string, object> Args { get; set; }
        public string CorrelationID { get; set; }

        public DomainEvent()
        {
            Created = DateTime.Now;
            Args = new Dictionary<string, object>();
        }

        public abstract void Flatten();
    }
}
