using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
    public class ViewModelApi
    {
        private ModelAbstractApi modelApi;
        public StartButtonCommand ButtonCommand {get; set;}
        private int _ilosc;
        public int Ilosc
        {
            get { return _ilosc; }
            set { 
                _ilosc = Convert.ToInt32(value);
            }
        }
        public ViewModelApi()
        {
            ButtonCommand = new StartButtonCommand(this);
            modelApi = new ModelApi();
        }
        public void Start()
        {
            this.modelApi.Start(_ilosc);
        }

        public void ButtonStartClick()
        {
            Start();
        }
    }
}