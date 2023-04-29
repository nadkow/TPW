﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Orb : IOrb
    {
        private double x;
        private double y;
        private int d = 10;
        private double xspeed;
        private double yspeed;
        private int period = 100;
        private Timer ChangePositionTimer;
        private Random rnd = new Random();

        public double X { get => x;}
        public double Y { get => y;}
        public int D { get => d;}
        public double XSpeed { get => xspeed;}
        public double YSpeed { get => yspeed;}
        public void SetSpeed(double x, double y)
        {
            xspeed = x;
            yspeed = y;
            CalculatePeriod();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Orb(double x, double y)
        {
            this.x = x;
            this.y = y;
            // losowa predkosc poczatkowa
            xspeed = rnd.NextDouble() * 4 - 2;
            yspeed = rnd.NextDouble() * 4 - 2;
            CalculatePeriod();
        }

        private void CalculatePeriod()
        {
            // TODO dostosowanie period (czas odswiezania) do predkosci
            // Timer.Change(period, period)
        }

        private void ChangePosition(object? state) //zeby mozna bylo uzyc changePosition w Timerze musi mieć argument object
        {   
            x += xspeed;
            y += yspeed;
            OnPropertyChanged();
        }

        public void Start()
        {
            ChangePositionTimer = new Timer(ChangePosition, null, 0, period);
        }

        public void DisposeTimer()
        {
            ChangePositionTimer.Dispose();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}