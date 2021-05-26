using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Data
{
    public abstract class AbstractEntity
    {
        public virtual long ID { get; set; }
    }
}
