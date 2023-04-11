using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
    public class ViewModelApi : INotifyPropertyChanged
    {
        private ModelAbstractApi modelApi;
        private ObservableCollection<Circle> balls = new ObservableCollection<Circle>();
        public StartButtonCommand ButtonCommand {get; set;}
        private int _ilosc;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Ilosc
        {
            get { return _ilosc; }
            set { 
                _ilosc = Convert.ToInt32(value);
            }
        }

        public ObservableCollection<Circle> Balls { get => balls; set => balls = value; }

        public ViewModelApi() : this(null) { }
        public ViewModelApi(ModelAbstractApi api)
        {
            ButtonCommand = new StartButtonCommand(this);
            if (api != null) { modelApi = api; }
            else { modelApi = ModelAbstractApi.CreateApi(); }
            modelApi.PropertyChanged += Update;
        }
        public void Start()
        {
            this.modelApi.Start(_ilosc);
            this.balls = modelApi.GetBalls();
            OnPropertyChanged(nameof(Balls));
        }

        public void Stop()
        {
            this.modelApi.Stop();
        }

        public void ButtonStartClick()
        {
            Start();
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Position")
            {
                // TODO tu bedzie update listy 
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}