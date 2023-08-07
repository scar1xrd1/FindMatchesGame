using System;
using System.Drawing;
using System.Windows.Forms;
using static FindMatchesGame.Classes;

namespace FindMatchesGame
{
    public partial class Form1 : Form
    {
        // objects
        CustomButton buttonStart = new CustomButton();
        CustomButton buttonSelectLevel = new CustomButton();
        CustomButton buttonSettings = new CustomButton();
        CustomButton buttonExit = new CustomButton();

        public Form1()
        {
            InitializeComponent();
            MyInitialize();
        }

        public void MyInitialize()
        {
            Size sizeButtons = new Size(350, 75);

            // BUTTON START
            buttonStart.Size = sizeButtons;
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.FlatAppearance.BorderSize = 0;
            buttonStart.BackgroundImage = Image.FromFile("Images/Buttons/ButtonStart.png");
            buttonStart.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonStartPressed.png");
            buttonStart.mouseUpPNG = Image.FromFile("Images/Buttons/ButtonStart.png");
            buttonStart.BackgroundImageLayout = ImageLayout.Zoom;
            buttonStart.Location = new Point(0, 0);            
            buttonStart.MouseDown += Button_MouseDown;
            buttonStart.MouseUp += Button_MouseUp;
            // BUTTON SELECT LEVEL
            buttonSelectLevel.Size = sizeButtons;
            buttonSelectLevel.FlatStyle = FlatStyle.Flat;
            buttonSelectLevel.FlatAppearance.BorderSize = 0;
            buttonSelectLevel.BackgroundImage = Image.FromFile("Images/Buttons/ButtonSelectLevel.png");
            buttonSelectLevel.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonSelectLevelPressed.png");
            buttonSelectLevel.mouseUpPNG = Image.FromFile("Images/Buttons/ButtonSelectLevel.png");
            buttonSelectLevel.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSelectLevel.Location = new Point(0, buttonStart.Bottom);
            buttonSelectLevel.MouseDown += Button_MouseDown;
            buttonSelectLevel.MouseUp += Button_MouseUp;
            // BUTTON SETTINGS
            buttonSettings.Size = sizeButtons;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.FlatAppearance.BorderSize = 0;
            buttonSettings.BackgroundImage = Image.FromFile("Images/Buttons/ButtonSettings.png");
            buttonSettings.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonSettingsPressed.png");
            buttonSettings.mouseUpPNG = Image.FromFile("Images/Buttons/ButtonSettings.png");
            buttonSettings.BackgroundImageLayout = ImageLayout.Zoom;
            buttonSettings.Location = new Point(0, buttonSelectLevel.Bottom);
            buttonSettings.MouseDown += Button_MouseDown;
            buttonSettings.MouseUp += Button_MouseUp;
            // BUTTON EXIT
            buttonExit.Size = sizeButtons;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.BackgroundImage = Image.FromFile("Images/Buttons/ButtonExit.png");
            buttonExit.mouseDownPNG = Image.FromFile("Images/Buttons/ButtonExitPressed.png");
            buttonExit.mouseUpPNG = Image.FromFile("Images/Buttons/ButtonExit.png");
            buttonExit.BackgroundImageLayout = ImageLayout.Zoom;
            buttonExit.Location = new Point(0, buttonSettings.Bottom);
            buttonExit.MouseDown += Button_MouseDown;
            buttonExit.MouseUp += Button_MouseUp;

            Controls.Add(buttonStart);
            Controls.Add(buttonSelectLevel);
            Controls.Add(buttonSettings);
            Controls.Add(buttonExit);
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
