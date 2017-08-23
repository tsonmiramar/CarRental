using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Core.Common
{
    public class EntityBase : IExtensibleDataObject
    {
        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }
}
