using GalaSoft.MvvmLight;
using Shared.BaseModels;
using Shared.Interfaces;
using Simulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingDojo3.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        private Simulator sim;
        public ObservableCollection<ItemVm> ActorList { get; set; }
        public ObservableCollection<ItemVm> SensorList { get; set; }
        private List<ItemVm> modelList = new List<ItemVm>();
        public ObservableCollection<string> ModeSelectionList { get; private set; }

        private string currentTime = DateTime.Now.ToLocalTime().ToShortTimeString();
        private string currentDate = DateTime.Now.ToLocalTime().ToShortDateString();

        public string CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; RaisePropertyChanged(); }
        }

        public string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; RaisePropertyChanged(); }
        }


        public MainViewModel()
        {
            SensorList = new ObservableCollection<ItemVm>();
            ActorList = new ObservableCollection<ItemVm>();
            ModeSelectionList = new ObservableCollection<string>();

            foreach (var item in Enum.GetNames(typeof(SensorModeType)))
            {
                ModeSelectionList.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(ModeType)))
            {
                ModeSelectionList.Add(item);

            }



        }
        private void LoadData()
        {
            Simulator sim = new Simulator(modelList);
            foreach (var item in sim.Items)
            {
                if (item.ItemType.Equals(typeof(ISensor)))
                    SensorList.Add(item);
                else if (item.ItemType.Equals(typeof(IActuator)))
                    ActorList.Add(item);
            }
            {

            }
        }
    }
}