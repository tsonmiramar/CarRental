using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Core
{
    public abstract class NotificationObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler _PropertyChanged;
        private HashSet<PropertyChangedEventHandler> propertyEventSubscribers;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!this.propertyEventSubscribers.Contains(value))
                {
                    _PropertyChanged += value;
                    propertyEventSubscribers.Add(value);
                }
            }
            remove
            {
                _PropertyChanged -= value;
                propertyEventSubscribers.Remove(value);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (_PropertyChanged != null)
            {
                _PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }

    }
}
