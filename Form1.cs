using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Threading;



/// <summary>
/// The user interface and initialization of the mainloop
/// </summary>
namespace NSBN_V._2._1
{
    public partial class Form1 : Form
    {
        bool loaded = false; // indicates whether openTK is loaded
        World world; // the instance of the word
        float blockHeight; // the width of each of the blocks (agents or food) to be drawn
        float blockWidth; // the height of each of the blocks
        AgentHandler agentHandler; // the instance of the agenthandler
        int FoodChancePerCell = 100; // the chance of per cell per turn of food being added (out of 10000, so 100 equals 10%)
        int DrawSpeed = 3;
        bool SimulationActive = false;
        bool SimulationLoaded = false;
        static AutoResetEvent threadEvent; // used to synchronise the drawing of the world and the executing of the agents updates
        Thread mainLoopThread;

        public Form1()
        {
            InitializeComponent();
            lbox_KValues.SelectedItem = lbox_KValues.Items[5];
        }

        private void glControl1_Load_1(object sender, EventArgs e) // initialize the graphics
        {
            loaded = true;
            glControl1.Width = Convert.ToInt32(this.Width - 325);
            glControl1.Height = Convert.ToInt32(this.Height - 60);

            // calculate the width of the agents/food blocks depending on the width of the window
            blockHeight = (float)(glControl1.Height / num_WorldHeight.Value);
            blockWidth = (float)(glControl1.Width / num_WorldWidth.Value);

            GL.ClearColor(Color.WhiteSmoke);
            SetupViewport();
            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e) // when idle render the agents/food
        {
            while (glControl1.IsIdle & DrawSpeed < 4) // don't render when drawing speed is "no drawing"
            {
                Render();
            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render() // renders the graphics
        {
            if (!loaded | DrawSpeed == 4) // don't render if not loaded or drawing speed is "no drawing"
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Color3(Color.Yellow);

            if (SimulationLoaded) // if the simulation isn't started don't try to render agents/food etc
            {
                threadEvent.WaitOne(); // wait in case the agents are being updated
                for (int x = 0; x < world.worldWidth; x++)
                {
                    for (int y = 0; y < world.worldHeight; y++)
                    {
                        if (world.occupied(x, y)) // if there is an agent
                        {
                            if (world.getAgent(x, y).Age == 0) // if the agent is just born, draw him as black
                            {
                                GL.Color3(0.0, 0.0, 0.0);
                            }
                            else // otherwiser draw him according to his carnivor percentage
                            {
                                double percentageCarnivor = ((float)world.getAgent(x, y).CarnivorePercentage / 100.0);
                                GL.Color3(percentageCarnivor * 3, 0.3, 1.0 - 2 * percentageCarnivor);
                            }
                        }
                        else if (world.GetFood(x, y) > 30) // if there isn't an agent in the cell but there is a large amount of food
                        {
                            GL.Color3(0.4, 0.8, 0.4);
                        }
                        else if (world.GetFood(x, y) > 10) // if there is a small but still significant amount of food
                        {
                            GL.Color3(0.5, 1.0, 0.5);
                        }
                        else // if there is no agent and no significant amount of food
                        {
                            GL.Color3(Color.White);
                        }

                        // do the actual drawing
                        GL.Begin(PrimitiveType.Quads);
                        GL.Vertex2(x * blockWidth, y * blockHeight);
                        GL.Vertex2(x * blockWidth, blockHeight + y * blockHeight);
                        GL.Vertex2(blockWidth + x * blockWidth, blockHeight + y * blockHeight);
                        GL.Vertex2(blockWidth + x * blockWidth, y * blockHeight);
                        GL.End();
                    }
                }
                threadEvent.Set(); // release the threadevent so the agents can be updated
            }
            glControl1.SwapBuffers();
        }

        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        private void MainLoop() // handles the updating of the agents, runs in a seperatie thread
        {
            while (true)
            {
                if (SimulationActive) // if the simulation has been started
                {
                    if(DrawSpeed < 3) // add a delay if draw speed is slow
                    {
                        Thread.Sleep(1500);
                    }
                    threadEvent.WaitOne(); // wait in case the graphics are being rendered
                    world.AddFoodToWorld(FoodChancePerCell); // add new food to the world
                    agentHandler.ExecuteAgents(); // update the agents
                    threadEvent.Set(); // release the threadevent so that the world can be rendered
                    AppendTextGeneralBox(agentHandler.GetStepCounter().ToString() + ", " + agentHandler.GetAgentCount().ToString() + System.Environment.NewLine); // output turn and agent cound
                    if(DrawSpeed == 1)
                    {
                        SimulationActive = false;
                    }
                }
                else // release the processer a bit in case the simulation isn't active
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void btn_StartSimulation_Click(object sender, EventArgs e)
        {
            if(!SimulationLoaded) // if the simulation hasn't been loaded yet
            {
                world = new World((int)num_WorldWidth.Value, (int)num_WorldHeight.Value); // create world instance
                agentHandler = new AgentHandler(world, chbox_CarnivorPercentage.Checked, false, (int)num_RestartAfter.Value, chbox_strictK.Checked); // create agenthandler instance

                // pass all of the initial parameters to the agenthandler
                List<int> KValues = new List<int>();
                foreach (int i in lbox_KValues.SelectedIndices)
                {
                    KValues.Add(i);
                }
                agentHandler.SetKValues(KValues);
                agentHandler.SetAgentsPerKValue((int)numUD_AgentsPerKValue.Value);
                agentHandler.setNValue((int)num_NValue.Value);
               
                // calculate the widht of the agents/food to be drawn
                blockWidth = (float)(glControl1.Width / num_WorldWidth.Value);
                blockHeight = (float)(glControl1.Height / num_WorldHeight.Value);

                // add an initial amount of food to the world
                world.AddFoodToWorld(6000);

                // deactive initial simulation parameter controls
                SimulationLoaded = true;
                num_WorldHeight.Enabled = false;
                num_WorldWidth.Enabled = false;
                numUD_AgentsPerKValue.Enabled = false;
                num_NValue.Enabled = false;
                lbox_KValues.Enabled = false;
                threadEvent = new AutoResetEvent(true);
                mainLoopThread = new Thread(new ThreadStart(this.MainLoop));
                mainLoopThread.IsBackground = true;
                mainLoopThread.Start();
                btn_ClearRun.Enabled = true;
                chbox_CarnivorPercentage.Enabled = false;
                num_RestartAfter.Enabled = false;
                chbox_strictK.Enabled = false;
            }
            if(SimulationActive) // pause the simulation if it was loaded and started
            {
                SimulationActive = false;
                btn_StartSimulation.Text = "Start Simulation";
            }
            else // resume the simulation if it was already loaded and paused
            {
                SimulationActive = true;
                btn_StartSimulation.Text = "Pause Simulation";
            }
        }

        private void Form1_Resize(object sender, EventArgs e) // handles a resize of the window
        {
            glControl1.Width = Convert.ToInt32(this.Width - 325);
            glControl1.Height = Convert.ToInt32(this.Height - 60);
            blockWidth = (float)(glControl1.Width / num_WorldWidth.Value);
            blockHeight = (float)(glControl1.Height / num_WorldHeight.Value);
            SetupViewport();
        }

        private void glControl1_Resize(object sender, EventArgs e) // draw the aspact ratio of the graphics window
        {
            lbl_WindowRatioLabel.Text = glControl1.AspectRatio.ToString();
        }

        public void AppendTextGeneralBox(String text) // used to write to the textbox from different threads
        {
            try
            {
                if (chkbox_TextOutput.Checked)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action<string>(AppendTextGeneralBox), new object[] { text });
                        return;
                    }
                    if (RtxtB_MainTextOutput.Lines.Length > 1000)
                    {
                        RtxtB_MainTextOutput.Clear();
                    }
                    this.RtxtB_MainTextOutput.AppendText(text);
                }
            }
            catch
            { } //  the checkbox might have been removed when you are closing the application while the other thread is still active, this can be ignored
        }

        private void btn_NoDrawing_Click(object sender, EventArgs e)
        {
            DrawSpeed = 4;
            lbl_DrawSpeedIndicator.Text = "No Drawing";
        }

        private void btn_DrawFast_Click(object sender, EventArgs e)
        {
            DrawSpeed = 3;
            lbl_DrawSpeedIndicator.Text = "Draw Fast";
        }

        private void btn_DrawSlow_Click(object sender, EventArgs e)
        {
            DrawSpeed = 2;
            lbl_DrawSpeedIndicator.Text = "Draw Slow";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // abort mainloop thread when closing
        {
            if (SimulationLoaded) // only abort if the thread has been created
            {
                threadEvent.WaitOne(5000);
                mainLoopThread.Abort();
            }
        }

        private void btn_ClearRun_Click(object sender, EventArgs e) // abort the mainloop thread and reset al parameters
        {
            // abort the current mainloop thread
            threadEvent.WaitOne(5000);
            mainLoopThread.Abort();

            // reset parameter
            SimulationActive = false;
            SimulationLoaded = false;
            world = null;
            agentHandler = null;
            btn_StartSimulation.Text = "Start Simulation";
            num_WorldHeight.Enabled = true;
            num_WorldWidth.Enabled = true;
            numUD_AgentsPerKValue.Enabled = true;
            num_NValue.Enabled = true;
            lbox_KValues.Enabled = true;
            btn_ClearRun.Enabled = false;
            chbox_CarnivorPercentage.Enabled = true;
            num_RestartAfter.Enabled = true;
            chbox_strictK.Enabled = true;
        }

    }
}
