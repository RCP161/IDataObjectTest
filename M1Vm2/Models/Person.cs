using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1Vm2.Models
{
    public class Person : ModelBase
    {
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set
            {
                SetValue(NameProperty, value);
                if (Name == "Name")
                    State = "Unchanged";
                else
                    State = "Changed";
            }
        }
        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set{SetValue(CommentProperty, value);}
        }
        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));


        public string State
        {
            get { return GetValue<string>(StateProperty); }
            set
            {
                SetValue(StateProperty, value);
                System.Diagnostics.Trace.WriteLine("Model State set to : " + State);
            }
        }

        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(string));
    }
}
