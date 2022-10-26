﻿using Proiect3.GUI;
using System;
using System.Windows.Forms;

namespace Proiect3
{
    public partial class Form1 : Form
    {
        GraphPanel graphPanel;
        DataPanel dataPanel;
        public Form1()
        {
            InitializeComponent();

            dataBtn.Click += (sender, e) => LoadDataPanel(sender, e);
            this.MaximizeBox = false;

        }

        private void LoadGraphPanel()
        {
            graphPanel = GraphPanel.Instance;

            this.Controls.Remove(dataPanel);
            this.Controls.Add(graphPanel);
        }

        private void LoadDataPanel(object sender, EventArgs e)
        {
            dataPanel = DataPanel.Instance;
            dataPanel.setForm(this.generateBtn);

            this.Controls.Remove(graphPanel);
            this.Controls.Add(dataPanel);
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            if (NeuralNetwork.NeuralNetwork.Instance.isGenerated == false)
            {
                GenerateNetwork generateNetwork = new GenerateNetwork();
                var result = generateNetwork.ShowDialog();
                if (result == DialogResult.OK) LoadGraphPanel();
            }
            else
            {
                LoadGraphPanel();
            }
        }
    }
}
