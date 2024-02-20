using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pars2012
{
    internal class Versenyző
    {
        string név;
        string csoport;
        string nemzetÉsKód;
        double d1;
        double d2;
        double d3;
        double eredmény;
        string nemzet;
        string kód;
        public Versenyző(string sor) 
        {
            if (!sor.Contains("Név;Csoport;NemzetÉsKód;D1;D2;D3") && sor != "")
            {
            List<string> eredmenyek = sor.Split(';').ToList();
            this.név = eredmenyek[0];
            this.csoport = eredmenyek[1];   
            this.nemzetÉsKód = eredmenyek[2];
                try
                {
                    this.d1 = double.Parse(eredmenyek[3]);
                }
                catch 
                {
                    if(eredmenyek[3] == "X")
                    {
                        this.d1 = -1.0;
                    }
                    else
                    {
                        this.d1 = -2.0;
                    }
                }
                try
                {
                    this.d2 = double.Parse(eredmenyek[4]);
                }
                catch
                {
                    if (eredmenyek[4] == "X")
                    {
                        this.d2 = -1.0;
                    }
                    else
                    {
                        this.d2 = -2.0;
                    }
                }
                try
                {
                    this.d3 = double.Parse(eredmenyek[5]);
                }
                catch
                {
                    if (eredmenyek[5] == "X")
                    {
                        this.d3 = -1.0;
                    }
                    else
                    {
                        this.d3 = -2.0;
                    }
                }
            }
        }

        public string Név { get => név; }
        public string Csoport { get => csoport; }
        public string NemzetÉsKód { get => nemzetÉsKód; }
        public double D1 { get => d1; }
        public double D2 { get => d2; }
        public double D3 { get => d3; }
        public double Eredmény { get => eredmény; set => eredmény = value; }
        public string Nemzet { get => nemzet; set => nemzet = value; }
        public string Kód { get => kód; set => kód = value; }
    }
}
