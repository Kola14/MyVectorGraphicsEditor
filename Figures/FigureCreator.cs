using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Figures;

namespace Figures
{
    [Serializable]
    public abstract class FigureCreator : ISerializable
    {
        public virtual Figure Create()
        {
            return null;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }
}
