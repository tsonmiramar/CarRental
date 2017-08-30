using Core.Contract;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Core
{
    public abstract class ObjectBase : NotificationObjectBase, IDirtyCapable, IExtensibleDataObject
    {
        #region IExtensibleDataObject Members
        public ExtensionDataObject ExtensionData { get; set; }
        #endregion

        //TODO: Implement the rest of member methods.
        #region IDirtyCapable Members

        protected bool _IsDirty = false;

        public virtual bool IsDirty
        {
            get { return _IsDirty; }
            set
            {
                _IsDirty = value;
                OnPropertyChanged(() => IsDirty);
            }
        }

        public void CleanAll()
        {
            throw new NotImplementedException();
        }

        public List<IDirtyCapable> GetDirtyObjects()
        {
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    bool exitWalk = false;

                    if (!exitWalk)
                    {
                        //TODO: need implementation
                    }
                }
            };

            return null;
        }

        public bool IsAnythingDirty()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PropertyChange Notification
        protected void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            base.OnPropertyChanged(propertyName);

            if (makeDirty)
            {
                IsDirty = true;
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(propertyName, true);
        }

        protected override void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }
        #endregion

        #region protected method
        
        #endregion
    }
}
