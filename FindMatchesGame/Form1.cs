using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using static FindMatchesGame.Classes;

namespace FindMatchesGame
{
    public partial class Form1 : Form
    {
        // objects menu
        CustomButton buttonStart = new CustomButton();
        CustomButton buttonSelectLevel = new CustomButton();
        CustomButton buttonSettings = new CustomButton();
        CustomButton buttonExit = new CustomButton();
        Label labelCurrentLevel = new Label();

        public Form1()
        {
            InitializeComponent();
            MyInitialize();
        }

        public void MyInitialize()
        {
            Size sizeButtons = new Size(350, 75);

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Fonts/Kotlyarfont-Regular.ttf");
            FontFamily Kotlyarfont = fontCollection.Families[0];

            // BUTTON START
            buttonStart.Font = new Font(Kotlyarfont, 25);
            buttonStart.Text = "Начать";
            buttonStart.ForeColor = Color.FromArgb(255, 186, 216);
            buttonStart.Size = sizeButtons;
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.FlatAppearance.BorderSize = 0;
            buttonStart.BackgroundImage = Image.FromFile("Images/Buttons/Button.png");
            buttonStart.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonPressed.png");
            buttonStart.mouseUpPNG = Image.FromFile("Images/Buttons/Button.png");
            buttonStart.BackgroundImageLayout = ImageLayout.Zoom;
            buttonStart.Location = new Point((Width - buttonStart.Width) / 2, 8);
            buttonStart.MouseDown += Button_MouseDown;
            buttonStart.MouseUp += Button_MouseUp;            
            // BUTTON SELECT LEVEL
            buttonSelectLevel.Font = new Font(Kotlyarfont, 20);
            buttonSelectLevel.Text = "Выбор уровня ";
            buttonSelectLevel.ForeColor = Color.FromArgb(255, 186, 216);
            buttonSelectLevel.Size = sizeButtons;
            buttonSelectLevel.FlatStyle = FlatStyle.Flat;
            buttonSelectLevel.FlatAppearance.BorderSize = 0;
            buttonSelectLevel.BackgroundImage = Image.FromFile("Images/Buttons/Button.png");
            buttonSelectLevel.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonPressed.png");
            buttonSelectLevel.mouseUpPNG = Image.FromFile("Images/Buttons/Button.png");
            buttonSelectLevel.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSelectLevel.Location = new Point((Width - buttonSelectLevel.Width) / 2, buttonStart.Bottom);
            buttonSelectLevel.MouseDown += Button_MouseDown;
            buttonSelectLevel.MouseUp += Button_MouseUp;
            // BUTTON SETTINGS
            buttonSettings.Font = new Font(Kotlyarfont, 25);
            buttonSettings.Text = "Настройки";
            buttonSettings.ForeColor = Color.FromArgb(255, 186, 216);
            buttonSettings.Size = sizeButtons;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.BackgroundImage = Image.FromFile("Images/Buttons/Button.png");
            buttonSettings.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonPressed.png");
            buttonSettings.mouseUpPNG = Image.FromFile("Images/Buttons/Button.png");
            buttonSettings.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSettings.Location = new Point((Width - buttonSettings.Width) / 2, buttonSelectLevel.Bottom);
            buttonSettings.MouseDown += Button_MouseDown;
            buttonSettings.MouseUp += Button_MouseUp;
            // BUTTON EXIT
            buttonExit.Font = new Font(Kotlyarfont, 25);
            buttonExit.Text = "Выйти";
            buttonExit.ForeColor = Color.FromArgb(255, 186, 216);
            buttonExit.Size = sizeButtons;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.BackgroundImage = Image.FromFile("Images/Buttons/Button.png");
            buttonExit.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonPressed.png");
            buttonExit.mouseUpPNG = Image.FromFile("Images/Buttons/Button.png");
            buttonExit.BackgroundImageLayout = ImageLayout.Zoom;
            buttonExit.Location = new Point((Width - buttonExit.Width) / 2, buttonSettings.Bottom);
            buttonExit.MouseDown += Button_MouseDown;
            buttonExit.MouseUp += Button_MouseUp;
            buttonExit.Click += ButtonExit_Click;

            Controls.Add(buttonStart);
            Controls.Add(buttonSelectLevel);
            Controls.Add(buttonSettings);
            Controls.Add(buttonExit);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private Image NumberImage(string number) { return Image.FromFile($"Images/Numbers/{number}.png"); }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Text = Size.ToString();

            buttonStart.Location = new Point((Width - buttonStart.Width) / 2, 8);
            buttonSelectLevel.Location = new Point((Width - buttonSelectLevel.Width) / 2, buttonStart.Bottom);
            buttonSettings.Location = new Point((Width - buttonSettings.Width) / 2, buttonSelectLevel.Bottom);
            buttonExit.Location = new Point((Width - buttonExit.Width) / 2, buttonSettings.Bottom);
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            CustomButton button = (CustomButton)sender;
            button.CustomButton_MouseUp(this, e);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            CustomButton button = (CustomButton)sender;
            button.CustomButton_MouseDown(this, e);
        }
    }
}
