using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Figures;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    [Serializable]
    class PrototypeCreator : FigureCreator
    {
        public Figure prototype { get; set; }

        private static PrototypeCreator instance = null;

        private PrototypeCreator() { }

        public static PrototypeCreator GetInstance()
        {
            if (instance is null) instance = new PrototypeCreator();

            return instance;
        }

        public override Figure Create()
        {
            if (prototype is null) return null;
            return prototype.Clone();
        }

        protected PrototypeCreator(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new System.ArgumentNullException(nameof(info));
            prototype = (Figure)info.GetValue("prototype", typeof(Figure));
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));
            info.AddValue("prototype", prototype);
        }
    }
}
