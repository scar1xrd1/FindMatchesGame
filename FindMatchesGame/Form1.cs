using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
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

        List<Button> buttons;
        int[] buttonImage;
        List<int> openedButtons;
        int[] freeImage;

        int clicks;
        int[] clickButton;

        int timer_tick = 0;
        int correct = 0;
        int currentLevel = 1;

        Random random = new Random();

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
            buttonStart.Click += ButtonStart_Click;
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
            // LABEL CURRENT LEVEL
            labelCurrentLevel.Text = "уровень";
            labelCurrentLevel.ForeColor = Color.FromArgb(255, 186, 216);
            labelCurrentLevel.Font = new Font(Kotlyarfont, 30);
            labelCurrentLevel.AutoSize = true;
            labelCurrentLevel.Visible = false;

            Controls.Add(buttonStart);
            Controls.Add(buttonSelectLevel);
            Controls.Add(buttonSettings);
            Controls.Add(buttonExit);
            Controls.Add(labelCurrentLevel);
        }

        void StartLevel(int level)
        {
            if(level == 1)
            {
                currentLevel = 1;
                Size = new Size(415, 440);

                buttons = new List<Button>(4);
                buttonImage = new int[4];
                freeImage = new int[2];
                openedButtons = new List<int>();
                int indexFreeImage = 0;
                clicks = 0;
                clickButton = new int[2];
                correct = 0;

                for (int i = 0; i < freeImage.Length; i++) { freeImage[i] = i + 1; }

                int x = 0;
                int y = 0;
                int raz = 0;

                for (int i = 0; i < 4; i++)
                {
                    buttons.Add(new Button());
                }

                for (int i = 0; i < buttons.Count; i++)
                {
                    if (raz++ == 2) { y += 200; x = 0; }

                    buttons[i].Size = new Size(200, 200);
                    buttons[i].Location = new Point(x, y);
                    buttons[i].BackColor = Color.AliceBlue;
                    buttons[i].FlatStyle = FlatStyle.Flat;
                    buttons[i].FlatAppearance.BorderColor = Color.FromArgb(255, 186, 216);
                    buttons[i].FlatAppearance.BorderSize = 1;
                    buttons[i].BackgroundImage = Image.FromFile("Images/Buttons/Closed.png");
                    buttons[i].BackgroundImageLayout = ImageLayout.Zoom;
                    buttons[i].Click += Buttons_Click;
                    Controls.Add(buttons[i]);

                    x += 200;
                }

                while(true)
                {
                    int buttonIndex = random.Next(0, buttonImage.Length);
                    if (buttonImage[buttonIndex] == 0)
                    {
                        buttonImage[buttonIndex] = freeImage[indexFreeImage];

                        while(true)
                        {
                            buttonIndex = random.Next(0, buttonImage.Length);
                            if (buttonImage[buttonIndex] == 0) { buttonImage[buttonIndex] = freeImage[indexFreeImage++]; break; }
                        }
                    }
                    if (indexFreeImage == freeImage.Length) break;
                }

                //for (int i = 0; i < buttonImage.Length; i++)
                //{
                //    MessageBox.Show(buttonImage[i].ToString());
                //}
            }
            else if(level == 2)
            {

            }
        }

        void DisableMenu()
        {
            buttonStart.Visible = false;
            buttonSelectLevel.Visible = false;
            buttonSettings.Visible = false;
            buttonExit.Visible = false;
        }
        void EnableMenu()
        {
            buttonStart.Visible = true;
            buttonSelectLevel.Visible = true;
            buttonSettings.Visible = true;
            buttonExit.Visible = true;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            int ii = 0;

            for (int i = 0; i < buttons.Count; i++)
            {
                if(button == buttons[i])
                {
                    ii = i;
                    clickButton[clicks++] = i;
                    button.BackgroundImage = ImageFromIndex(buttonImage[i]);
                    break;
                }
            }
            
            if(clicks == 2)
            {
                if (buttonImage[clickButton[0]] == buttonImage[clickButton[1]])
                {
                    openedButtons.Add(clickButton[0]);
                    openedButtons.Add(clickButton[1]);

                    clickButton = new int[2];
                    clicks = 0;
                    correct++;
                    HideButtons();

                    if (correct == 2) StopGame();
                }
                else
                {
                    clickButton = new int[2];
                    clicks = 0;
                    timer1.Start();
                }                
            }
            
        }

        private void HideButtons()
        {
            if(openedButtons.Count < 1)
            {
                foreach(var button in buttons) button.BackgroundImage = Image.FromFile("Images/Buttons/Closed.png");
            }
            else
            {
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (openedButtons.Contains(i)) continue;
                    else
                    {
                        buttons[i].BackgroundImage = Image.FromFile("Images/Buttons/Closed.png");
                    }
                }
            }
        }

        private void StopGame()
        {
            Size = new Size(400, 500);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Dispose();
            }
            EnableMenu();
            currentLevel++;
        }

        private Image ImageFromIndex(int index) => Image.FromFile($"Images/GameButtons/{index}.png");

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            DisableMenu();
            StartLevel(1);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_tick++;

            if(timer_tick == 50)
            {
                HideButtons();

                timer_tick = 0;
                timer1.Stop();
            }
        }
    }
}
