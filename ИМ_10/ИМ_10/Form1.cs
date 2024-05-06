using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИМ_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        Dictionary<string, double> TeamParams = new Dictionary<string, double>();
        public int getValue(double lambda)
        {

            Random rnd = new Random();
            double a = rnd.NextDouble();
            int points = 0;
            double S = Math.Log(a);
            while (S > lambda)
            {
                points++;
                a = rnd.NextDouble();
                S += Math.Log(a);
            }
            return points;

        }

        public void Start()
        {
            TeamParams.Add("Japan", -4.5);
            label1.Text = "Japan";
            p1.Text = "0";

            TeamParams.Add("Italy", -3.7);
            label2.Text = "Italy";
            p2.Text = "0";

            TeamParams.Add("Spain", -3.5);
            label3.Text = "Spain";
            p3.Text = "0";

            TeamParams.Add("Russia", -1.3);
            label4.Text = "Russia";
            p4.Text = "0";

            TeamParams.Add("Brazil", -5.0);
            label5.Text = "Brazil";
            p5.Text = "0";

            TeamParams.Add("Poland", -2.5);
            label6.Text = "Poland";
            p6.Text = "0";

            TeamParams.Add("UK", -3.3);
            label7.Text = "UK";
            p7.Text = "0";

            TeamParams.Add("Portugal", -3.9);
            label8.Text = "Portugal";
            p8.Text = "0";

        }

        private void play(System.Windows.Forms.Label team1, System.Windows.Forms.Label team2, 
            System.Windows.Forms.Label PointsTeam1, System.Windows.Forms.Label PointsTeam2, System.Windows.Forms.Label winner)
        {
            double lambdaA = TeamParams[team1.Text];
            double lambdaB = TeamParams[team2.Text];
            int PointsA, PointsB;
            PointsA = getValue(lambdaA);
            PointsB = getValue(lambdaB);
            PointsTeam1.Text = "" + PointsA;
            PointsTeam2.Text = "" + PointsB;

            if (PointsA > PointsB) { winner.Text = team1.Text; }
            if (PointsA < PointsB) { winner.Text = team2.Text; }
            if (PointsA == PointsB) { play(team1, team2, PointsTeam1, PointsTeam2, winner); }

        }

        private void button1_play_Click(object sender, EventArgs e)
        {
            for (int day  = 0;  day < 3; day++) 
            {
                if (day == 0) 
                {
                    play(label1, label2, p1, p2, label9);
                    play(label3, label4, p3, p4, label10);
                    play(label5, label6, p5, p6, label11);
                    play(label7, label8, p7, p8, label12);
                }

                if (day == 1) 
                {
                    play(label9, label10, p9, p10, label13);
                    play(label11, label12, p11, p12, label14);
                }

                if (day == 2)
                {
                    play(label13, label14, p13, p14, label16);
                }
            }

        }

    }
}
