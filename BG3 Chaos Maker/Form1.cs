using System;

namespace BG3_Chaos_Maker
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Label resultLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // create and configure the result label
            resultLabel = new Label
            {
                AutoSize = true,
                Location = new Point(10, 70),
                Name = "resultLabel",
                Size = new Size(0, 13),
                TabIndex = 2
            };
            Controls.Add(resultLabel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // allows user to hit the "Enter" key or click the button for results
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;  // remove the "ding" sound
                GenerateRandomChoice();
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           GenerateRandomChoice();
        }

        // picks a random number based on what is entered into the text box and displays results or error message
        private void GenerateRandomChoice()
        {
            string value = textBox1.Text;
            if (!int.TryParse(value, out int maxChoice) || maxChoice <= 1)
            {
                resultLabel.Text = "Please enter a valid number greater than 1.";
                resultLabel.ForeColor = Color.Red;
                return;
            }

            int randomChoice = random.Next(1, maxChoice + 1);
            resultLabel.Text = $"Your random dialogue choice is: {randomChoice} out of {maxChoice}";
            resultLabel.ForeColor = Color.Black;

            // clear the textbox
            textBox1.Clear();
        }
    }
}