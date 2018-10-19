namespace M1Vm2.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using M1Vm2.Models;
    using System;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Model = new Person()
            {
                Name = "Name",
                Comment = "Comment"
            };

            RevertCommand = new Command(Revert, () => true);

            Model.PropertyChanged += Model_PropertyChanged;
            PropertyChanged += CustomerVm_PropertyChanged;
        }

        private void CustomerVm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("VM: {0}", e.PropertyName));
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(String.Format("Model: {0}", e.PropertyName));
        }

        public override string Title { get { return "M1Vm2"; } }

        [Model]
        public Person Model
        {
            get { return GetValue<Person>(ModelProperty); }
            private set { SetValue(ModelProperty, value); }
        }
        public static readonly PropertyData ModelProperty = RegisterProperty(nameof(Model), typeof(Person));


        [ViewModelToModel]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly PropertyData NameProperty = RegisterProperty(nameof(Name), typeof(string));


        [ViewModelToModel]
        public string Comment
        {
            get { return GetValue<string>(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly PropertyData CommentProperty = RegisterProperty(nameof(Comment), typeof(string));


        [ViewModelToModel]
        public string State
        {
            get { return GetValue<string>(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(string));

        public Command RevertCommand { get; private set; }


        private void Revert()
        {
            CancelViewModelAsync();
        }


        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
